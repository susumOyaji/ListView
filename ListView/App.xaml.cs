using Xamarin.Forms;

namespace ListView
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
          
            MainPage = MainPage = new NavigationPage(new ListViewPage()); //MainPage = new NavigationPage(new MainPage());
           
        }

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
