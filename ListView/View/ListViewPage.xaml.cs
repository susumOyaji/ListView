using Xamarin.Forms;

namespace ListView
{
    public partial class ListViewPage : ContentPage
    {
        public ListViewPage()
        {
            InitializeComponent();
             abc.TextColor = Color.Red;// Polar;// "Red";
        }

        public static void ChangeButtonColor()
        {
          //NewYorkButton.BackgroundColor = Color.Red;// Polar;// "Red";
        }

        public void NewyorkButtonColor( )
        {
            
            NewyorkButton.BackgroundColor = Color.Red;
            //Goingprice.TextColor = "#0000FF";
            //City.TextColor = "Green";

        }




    }
}
