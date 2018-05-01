using MapDemo.Annotations;
using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MapDemo.Models
{
    public class FavoriteLocations : BaseModel
    {
        private double _latitude;
        private int _locationId;
        private string _locationName;
        private double _longitude;
        private string _zipCode;

        [PrimaryKey]
        [AutoIncrement]
        public int LocationId
        {
            get => _locationId;
            set
            {
                _locationId = value;

                OnPropertyChanged(nameof(LocationId));
            }
        }

        public string LocationName
        {
            get => _locationName;
            set
            {
                _locationName = value;

                OnPropertyChanged(nameof(LocationName));
            }
        }

        public double Longitude
        {
            get => _longitude;
            set
            {
                _longitude = value;

                OnPropertyChanged(nameof(Longitude));
            }
        }

        public double Latitude
        {
            get => _latitude;
            set
            {
                _latitude = value;

                OnPropertyChanged(nameof(Latitude));
            }
        }

        public string ZipCode
        {
            get => _zipCode;
            set
            {
                _zipCode = value;

                OnPropertyChanged(nameof(ZipCode));
            }
        }
    }

    public class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}