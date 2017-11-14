using CarparkTracker.Presentation.Entities.Base;

namespace CarparkTracker.Presentation.Entities
{
    public class Carpark : PropertyChangedBase
    {
        private string _name;
        private int _availableSpaces;

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

        public int? DistanceTo { get; set; }
    }
}