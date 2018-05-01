
using MapDemo.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MapDemo.Helper
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomPinView : ContentView
    {
        public CustomPinView(MapsViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}