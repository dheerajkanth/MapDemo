using MapDemo.ApiService;
using MapDemo.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MapDemo.ViewModel
{
    public class WeatherViewModel : BaseModel
    {
        public ICommand GetWeatherCommand { get; set; }

        public ICommand ShowFaviorateLocations { get; set; }

        private string _zipCode;
        public string ZipCode
        {
            get => _zipCode;
            set
            {
                _zipCode = value;

                OnPropertyChanged(nameof(ZipCode));
            }
        }

        private ObservableCollection<FavoriteLocations> _favoriteLocations;

        public ObservableCollection<FavoriteLocations> FavuFavoriteLocationses
        {
            get => _favoriteLocations;
            set
            {
                _favoriteLocations = value;

                OnPropertyChanged(nameof(FavuFavoriteLocationses));
            }
        }

        private INavigation _navigation;

        public WeatherViewModel(INavigation navigation)
        {
            _navigation = navigation;

            GetWeatherCommand = new Command(GetWeatherInfoByZipCode);

            ShowFaviorateLocations = new Command(FetchFaviorateLocations);
        }

        public void FetchFaviorateLocations()
        {
            FavuFavoriteLocationses = App.DbAccess.FetchFavoriteLocationses("select * from [FavoriteLocations]");
        }

        public void GetWeatherInfoByZipCode()
        {
            string key = "9748482533a3f0bd6f71a1971c1f313e";

            string queryString = "http://api.openweathermap.org/data/2.5/weather?zip=" + ZipCode + ",in&appid=" + key + "&units=imperial";

            RootObject rootObject = HttpClientHelper.GetWeatherDataByZipCode(queryString).Result;

            _navigation.PushAsync(new MapPage(rootObject, ZipCode));
        }
    }
}
