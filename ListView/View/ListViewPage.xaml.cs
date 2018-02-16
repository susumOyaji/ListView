using System;
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

        async void OnDoThisClick(object sender, EventArgs ea)
        {
            await DisplayAlert("Do this", "alert displays as well as TriggerAction", "Cool");
        }

        async void OnDoThatClick(object sender, EventArgs ea)
        {
            await DisplayAlert("Do that", "alert displays as well as TriggerAction", "Cool");
        }





    }
}
