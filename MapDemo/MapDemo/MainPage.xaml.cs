using MapDemo.ViewModel;
using Xamarin.Forms;

namespace MapDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new WeatherViewModel(Navigation);
        }
    }
}
