
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
        }




        //private ListViewPageViewModel VM
        //{
        //    get;set;
        //    //get { return this.DataContext as ViewModel; }
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
            DisplayAlert("More Context Action", e.ToString() + " more context action", "OK");
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
        }

        public void OnEdit(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new EntryPage());

            //var newPage = new ContentPage();
            //Navigation.PushAsync(newPage);
           
            //var poppedPage = Navigation.PopAsync();
          

            //var usercode = new Entry { Placeholder = "Code", Keyboard = Keyboard.Text, };

            //var Content = new StackLayout
            //{
            //    WidthRequest = 400,
            //    VerticalOptions = LayoutOptions.Center,
            //    HorizontalOptions = LayoutOptions.Center,
            //    Children =
            //    {
            //        usercode
            //            //Entryクラスのインスタンス生成
            //            new Entry(),

            //            //テキストの設定
            //            new Entry
            //            {
            //                Text = "あいうえおAIUEOaiueo曖昧模糊",
            //            },

            //             //フォントサイズを20に設定
            //            new Entry
            //            {
            //                Text = "あいうえおAIUEOaiueo曖昧模糊",
            //                FontSize = 20,
            //            },

            //    }
            //};

            //this.BindingContext = stackLayout;

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
            DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
            var lblSelected_Text = e.SelectedItem.ToString();
        }
        /// <summary>
        /// 項目タップ時に呼ばれる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            DisplayAlert("Item Tapped", e.Item.ToString(), "Ok");
            this.AddButton.Text = e.Item.ToString();
        }
             
    }

}
