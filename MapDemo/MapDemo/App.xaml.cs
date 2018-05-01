
using MapDemo.Models;
using Xamarin.Forms;

namespace MapDemo
{
    public partial class App : Application
    {
        static DataAccess dataAccess;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public static DataAccess DbAccess => dataAccess ?? (dataAccess = new DataAccess());

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
