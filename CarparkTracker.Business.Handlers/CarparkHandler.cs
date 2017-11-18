using CarparkTracker.Business.Entities.Carparks;
using CarparkTracker.Business.Handlers.Contracts;
using CarparkTracker.Business.Handlers.UrlBuilders;
using CarparkTracker.Data.Contracts.LocationTrackers;
using CarparkTracker.Data.Contracts.WebRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using CarparkTracker.Common.Entities.EventArguments;

namespace CarparkTracker.Business.Handlers
{
    public class CarparkHandler : ICarparkHandler
    {
        private List<Action<IEnumerable<CarparkDto>>> _subscribersOnCarparkChanges;
        private readonly IWebRequests _webRequests;
        private CarparkDto[] _lastCarparkCollection;
        private readonly Timer _timer;
        private ILocationTracker _locationTracker;

        public CarparkHandler(IWebRequests webRequests, ILocationTracker locationTracker)
        {
            _webRequests = webRequests;
            _subscribersOnCarparkChanges = new List<Action<IEnumerable<CarparkDto>>>();
            _timer = new Timer(20000);
            _timer.Elapsed += Timer_Elapsed;
            locationTracker.LocationUpdated += LocationTracker_LocationUpdated;
            //var test = locationTracker.GetCurrentLocationAsync();
        }

        private void LocationTracker_LocationUpdated(object sender, LocationChangedEventArgs e)
        {

        }

        private CarparkDto[] GetNewCarparks()
        {
            return _webRequests.GetJsonRequest<CarparkDto[]>(UrlBuilder.GetParkingsUrl());
        }

        public CarparkDto[] GetCarparks()
        {
            _lastCarparkCollection = GetNewCarparks();
            return _lastCarparkCollection;
        }

        public void SubscribeOnCarparkChanges(Action<IEnumerable<CarparkDto>> action)
        {
            if ( !_subscribersOnCarparkChanges.Contains(action) )
                _subscribersOnCarparkChanges.Add(action);

            if ( !_timer.Enabled )
                _timer.Start();
        }

        public void Unsubscribe(Action<IEnumerable<CarparkDto>> action)
        {
            if ( _subscribersOnCarparkChanges.Contains(action) )
                _subscribersOnCarparkChanges.Remove(action);

            if ( !_subscribersOnCarparkChanges.Any() )
                _timer.Stop();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CheckUpdatedCarparks();
        }

        private void CheckUpdatedCarparks()
        {
            var carParks = GetNewCarparks();
            var carparksToUpdate = new List<CarparkDto>();

            foreach ( var carpark in carParks )
            {
                var oldCarpark = _lastCarparkCollection.SingleOrDefault(lcp => lcp.Id == carpark.Id);

                if ( oldCarpark.CarparkStatus.LastModifiedDate == carpark.CarparkStatus.LastModifiedDate )
                    continue;

                carparksToUpdate.Add(carpark);
            }

            _lastCarparkCollection = carParks;

            if ( carparksToUpdate.Any() )
                NotifySubscribers(carparksToUpdate);
        }

        private void NotifySubscribers(IEnumerable<CarparkDto> updatedCarparks)
        {
            _subscribersOnCarparkChanges.ForEach(s => s.Invoke(updatedCarparks));
        }
    }
}