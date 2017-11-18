using CarparkTracker.Common.Entities;
using CarparkTracker.Presentation.Entities.Base;

namespace CarparkTracker.Presentation.Entities
{
    public class Carpark : PropertyChangedBase
    {
        private string _name;
        private int _availableSpaces;
        private double _colorFactor;
        private bool _isOpen;

        public int Id { get; set; }
        public int MaximumSpaces { get; set; }
        public Coordinate Coordinate { get; set; }

        public string Name
        {
            get { return _name; }
            set
            {
                if ( _name == value )
                    return;

                _name = value;
                OnPropertyChanged();
            }
        }

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


        public int? DistanceTo { get; set; }
    }
}