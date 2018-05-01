using MapDemo.Helper;
using MapDemo.Models;
using MapDemo.ViewModel;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace MapDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {

        public RootObject _rootObject;

        public MapsViewModel ViewModel;
        public MapPage(RootObject rootObject, string ZipCode)
        {
            InitializeComponent();

            _rootObject = rootObject ?? new RootObject();

            ViewModel = new MapsViewModel(Navigation, rootObject ?? new RootObject(), ZipCode);

            var position = new Position(ViewModel.PropCoord.lat, ViewModel.PropCoord.lon); // Latitude, Longitude

            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Address = ViewModel.PropRootObject.name,
                Label = ViewModel.PropRootObject.name
            };

            MyMap.MoveToRegion(
                MapSpan.FromCenterAndRadius(position, Distance.FromMiles(1)));

            MyMap.Pins.Add(pin);


            DataLayout.Children.Add(GetCustomPinInterface());

            BindingContext = ViewModel;
        }

        private View GetCustomPinInterface()
        {
            PopupPage popupPage = new PopupPage
            {
                WidthRequest = 200,
                HeightRequest = 200
            };

            CustomPinView view = new CustomPinView(ViewModel);

            return popupPage.Content = view;
        }
    }
}