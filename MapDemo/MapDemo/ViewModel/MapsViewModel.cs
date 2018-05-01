using MapDemo.Models;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace MapDemo.ViewModel
{
    public class MapsViewModel : BaseModel
    {
        private INavigation _navigation;

        private RootObject _rootObject;

        public RootObject PropRootObject
        {
            get => _rootObject;
            set
            {
                _rootObject = value;

                OnPropertyChanged(nameof(PropRootObject));
            }
        }

        private Main _main;

        public Main PropMain
        {
            get => _main;

            set
            {
                _main = value;

                OnPropertyChanged(nameof(PropMain));
            }
        }

        private Wind _wind;

        public Wind PropWind
        {
            get => _wind;
            set
            {
                _wind = value;
                OnPropertyChanged(nameof(PropWind));
            }
        }

        private Coord _coord;

        public Coord PropCoord
        {
            get => _coord;
            set
            {
                _coord = value;
                OnPropertyChanged(nameof(PropCoord));
            }
        }

        private Sys _sys;

        public Sys PropSys
        {
            get => _sys;
            set
            {
                _sys = value;
                OnPropertyChanged(nameof(PropSys));
            }
        }

        private Weather _weather;

        public Weather PropWeather
        {
            get => _weather;
            set
            {
                _weather = value;
                OnPropertyChanged(nameof(Weather));
            }
        }

        public ICommand FaviorateLocationCommand { get; set; }

        public string ZipCode { get; set; }

        public MapsViewModel(INavigation navigation, RootObject rootObject, string zipCode)
        {
            _navigation = navigation;

            ZipCode = zipCode;

            PropRootObject = rootObject;

            PropCoord = rootObject.coord;

            PropSys = rootObject.sys;

            PropMain = rootObject.main;

            PropWind = rootObject.wind;

            PropWeather = rootObject.weather.SingleOrDefault();

            FaviorateLocationCommand = new Command(MakeYourLocationAsFaviorate);
        }
        public void MakeYourLocationAsFaviorate()
        {
            FavoriteLocations favoriteLocation = new FavoriteLocations
            {
                Latitude = PropCoord.lat,
                Longitude = PropCoord.lon,
                LocationName = PropSys.country,
                ZipCode = ZipCode
            };

            int value = App.DbAccess.SaveFaviorateLocation(favoriteLocation);
        }
    }
}
