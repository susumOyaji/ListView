using System;
using Xamarin.Forms;

namespace ListView
{
    public partial class ListViewPage : ContentPage
    {
        /// <summary>
        /// ViewModel への参照
        /// </summary>
        private ListViewPageViewModel Vm { get; set; }
      


        public ListViewPage()
        {
            InitializeComponent();
        }

        //private dynamic Vm
        //{
        //    get { return this.DataContext; }
        //}

        //private ListViewPageViewModel Vm
        //{
        //    get { return this.DataContext as ListViewPageViewModel; }
        //}

       
        //async void OnDoThisClick(object sender, EventArgs ea)
        //{
        //    await DisplayAlert("Do this", "alert displays as well as TriggerAction", "Cool");
        //}

        //async void OnDoThatClick(object sender, EventArgs ea)
        //{
        //    await DisplayAlert("Do that", "alert displays as well as TriggerAction", "Cool");
        //}
        public void OnMore(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
        }

        public void OnEdit(object sender, EventArgs e)
        {
            MenuItem mi = ((MenuItem)sender);
            DisplayAlert("Edit Context Action", mi.CommandParameter + " edit context action", "OK");
            Vm.OnLabelClicked(mi);

        }

        internal void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }
            DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
            //((ListView)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.
           //var Q = Vm.OnLabelClicked();
            //var a = Vm.OnLabelClicked();
        }
      
    }
}
