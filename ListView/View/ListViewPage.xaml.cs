using Xamarin.Forms;

namespace ListView
{
    public partial class ListViewPage : ContentPage
    {
        public ListViewPage()
        {
            InitializeComponent();
        }

       

        public void IndnButtonColor(string color)
        {
            if(color == "Red")
            {
                IndnButton.BackgroundColor = Color.Red;
            }

            if(color == "Green")
            {
                IndnButton.BackgroundColor = Color.Green;
            }
        }


        public void Ni255ButtonColor(string color)
        {
            if (color == "Red")
            {
                Ni255Button.BackgroundColor = Color.Red;
            }

            if (color == "Green")
            {
                Ni255Button.BackgroundColor = Color.Green;
            }
        }

        public void Sw()
        {
            //UptoButton.Text = "";
        }

    }
}
