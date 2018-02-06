using Xamarin.Forms;

namespace ListView
{
    public partial class ListViewPage : ContentPage
    {
        public ListViewPage()
        {
            InitializeComponent();
        }

        public static void ChangeButtonColor()
        {
          //NewYorkButton.BackgroundColor = Color.Red;// Polar;// "Red";
        }

        public void NewyorkButtonColor( )
        {

            NewyorkButton.BackgroundColor ="#ee00a2e8";// Color.Red;
            NewyorkButton.BackgroundColor = "Red";// "#ee00a2e8";// Color.Red;
            //Goingprice.TextColor = "#0000FF";
            //City.TextColor = "Green";

        }




    }
}
