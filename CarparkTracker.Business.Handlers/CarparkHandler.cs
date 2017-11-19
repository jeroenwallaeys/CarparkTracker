﻿using CarparkTracker.Business.Entities.Carparks;
using CarparkTracker.Business.Handlers.Contracts;
using CarparkTracker.Business.Handlers.UrlBuilders;
using CarparkTracker.Data.Contracts.LocationTrackers;
using CarparkTracker.Data.Contracts.WebRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using CarparkTracker.Common.Entities.EventArguments;
using CarparkTracker.Common.Entities;
using CarparkTracker.Business.Entities.EventArguments;

namespace CarparkTracker.Business.Handlers
{
    public class CarparkHandler : ICarparkHandler
    {
        private List<Action<IEnumerable<CarparkDto>>> _subscribersOnCarparkChanges;
        private List<Action<Coordinate>> _subscribersOnLocationChanges;

        private readonly IWebRequests _webRequests;
        private CarparkDto[] _lastCarparkCollection;
        private Timer _timer;
        private ILocationTracker _locationTracker;

        public event EventHandler<CarparksChangedEventArgs> CarparksChanged;
        public event EventHandler<LocationChangedEventArgs> LocationChanged;

        public CarparkHandler(IWebRequests webRequests, ILocationTracker locationTracker)
        {
            _webRequests = webRequests;
            _subscribersOnCarparkChanges = new List<Action<IEnumerable<CarparkDto>>>();
            _subscribersOnLocationChanges = new List<Action<Coordinate>>();
            _locationTracker = locationTracker;

            InitializeTimer();
            InitializeLocationTracker();
        }

        public CarparkDto[] GetCarparks()
        {
            _lastCarparkCollection = GetNewCarparks();
            return _lastCarparkCollection;
        }

        private void InitializeLocationTracker()
        {
            _locationTracker.LocationUpdated += LocationTracker_LocationUpdated;
        }

        private void InitializeTimer()
        {
            _timer = new Timer(20000);
            _timer.Elapsed += Timer_Elapsed;
            _timer.Start();
        }

        private void LocationTracker_LocationUpdated(object sender, LocationChangedEventArgs e)
        {
            LocationChanged?.Invoke(this, e);
        }

        private CarparkDto[] GetNewCarparks()
        {
            return _webRequests.GetJsonRequest<CarparkDto[]>(UrlBuilder.GetParkingsUrl());
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
                CarparksChanged?.Invoke(this, new CarparksChangedEventArgs(carparksToUpdate));
        }
    }
}