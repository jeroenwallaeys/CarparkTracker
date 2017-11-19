using CarparkTracker.Common.Entities;
using CarparkTracker.Presentation.Entities.Base;

namespace CarparkTracker.Presentation.Entities
{
    public class Carpark : PropertyChangedBase
    {
        private int _availableSpaces;
        private double _colorFactor;
        private bool _isOpen;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactDetails { get; set; }
        public string Address { get; set; }
        public int MaximumSpaces { get; set; }
        public Coordinate Coordinate { get; set; }
        public int? DistanceTo { get; set; }

        public int AvailableSpaces
        {
            get { return _availableSpaces; }
            set
            {
                if ( _availableSpaces == value )
                    return;

                _availableSpaces = value;
                OnPropertyChanged();
            }
        }

        public double ColorFactor
        {
            get { return _colorFactor; }
            set
            {
                if ( _colorFactor == value )
                    return;

                _colorFactor = value;
                OnPropertyChanged();
            }
        }

        public bool IsOpen
        {
            get { return _isOpen; }
            set
            {
                if ( _isOpen == value )
                    return;

                _isOpen = value;
                OnPropertyChanged();
            }
        }
    }
}