
using System;
using ListView.View;
using Xamarin.Forms;

namespace ListView
{
    public partial class ListViewPage : ContentPage
    {
       // internal ListViewPageViewModel Vm { get; set; }


        public object SelectedItem { get; private set; }

        public ListViewPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }




        

       

        internal void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }
            DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
            ((ListViewPage)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.
          
        }

       
        /// <summary>
        /// ListViewの項目選択時に呼ばれる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            this.Navigation.PushAsync(new EntryPage(e));
            //DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
            
        }
        /// <summary>
        /// 項目タップ時に呼ばれる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            //mi.CommandParameter as ContactHistoryItem
            //MenuItem mi = ((MenuItem)sender);
            //this.Navigation.PushAsync(new EntryPage(e));

           // DisplayAlert("Item Tapped", e.Item.ToString(), "Ok");
            //this.AddButton.Text = e.Item.ToString();
        }
             
    }

}
