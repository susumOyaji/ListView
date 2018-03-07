﻿
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



        public void OnEdit(object sender, EventArgs e)
        {

        var newPage = new ContentPage();
        Navigation.PushAsync(newPage);

        var poppedPage = Navigation.PopAsync();


        var usercode = new Entry { Placeholder = "Code", Keyboard = Keyboard.Text, };



        //mi.CommandParameter as ContactHistoryItem

        MenuItem mi = ((MenuItem)sender);
        var par = mi.CommandParameter;
        var selectedText =  this.DisplayActionSheet("Edit", "Close", "Chancel", new string[] {"qqqq", "すいか", "ぶどう"});

        if (selectedText != null)
        {
            //buttonDialog2.Text = selectedText;
        }

        DisplayAlert("Edit Context Action", e.ToString() + " edit context action", "OK");

        //ListViewPageViewModel.OnLabelClicked(mi);


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
            this.Navigation.PushAsync(new EntryPage(sender,e));
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
