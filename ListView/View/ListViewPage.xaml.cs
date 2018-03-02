
using System;

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
            DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
        }

        public void OnEdit(object sender, EventArgs e)
        {
            // this.Navigation.PushAsync(new EntryPage());

            var usercode = new Entry { Placeholder = "Code", Keyboard = Keyboard.Text, };

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



            MenuItem mi = ((MenuItem)sender);
            var par = mi.CommandParameter;
            var selectedText =  this.DisplayActionSheet(
                                    "Edit", "Close", "Chancel",
                                    new string[] { Convert.ToString(par), "すいか", "ぶどう" });
            var ans = Convert.ToString(par);

            if (selectedText != null)
            {
                //buttonDialog2.Text = selectedText;
            }

            // DisplayAlert("Edit Context Action", par.ToString() + " edit context action", "OK");

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
      
    }
}
