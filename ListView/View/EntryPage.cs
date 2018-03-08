using System;

using Xamarin.Forms;

namespace ListView.View
{
    public class EntryPage : ContentPage
    {
       
        public  EntryPage(object sender, SelectedItemChangedEventArgs e)
        {
            //var strId = ((MenuItem)sender).StyleId;
            //int StrId = Convert.ToInt16(strId);

         

            var itemname = ((Price)e.SelectedItem).Name;
            var itemstock = ((Price)e.SelectedItem).Stocks;
            var itemprice = ((Price)e.SelectedItem).Itemprice;

            
            //var i = 0;


            // ナビゲーションバーの右上にボタンを追加する。
            //ToolbarItems.Add(new ToolbarItem("Name", "icon.png", async () =>
            //{
            //    // 何か処理を記述
            //}));


           


            //NavigationPage.SetHasNavigationBar(this, false);
            var usercode = new Entry { Text = itemname, BackgroundColor=Color.Gray, TextColor =Color.White, Keyboard = Keyboard.Default };
            var usercost = new Entry { Text = itemstock.ToString(), TextColor = Color.White, Keyboard = Keyboard.Numeric };
            var usershares = new Entry { Text = itemprice.ToString(), TextColor = Color.White, Keyboard = Keyboard.Numeric };

            string SaveData = usercode.Text + "," + usercost.Text + "," + usershares.Text + "\n";

           
            Content = new StackLayout
            {
                Padding = 20,
                BackgroundColor = Color.Black,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { usercode, usercost, usershares,
                    
                }
            };


            ToolbarItems.Add(new ToolbarItem
            { // <-2
                Text = "Cansel", // <-3
                Command = new Command(() => Navigation.PopAsync())
            });
            ToolbarItems.Add(new ToolbarItem
            {
                Text = "Edit",
                Command = new Command(() => DisplayAlert("Selected", "Edit", "OK"))
            });
            ToolbarItems.Add(new ToolbarItem
            {
               
                Text = "Save",
                Command = new Command(() => DisplayAlert("Selected", SaveData, "OK"))
            });





            //if (str != "Add")
            //{
            //    Save.IsEnabled = false;
            //    Edit.IsEnabled = true;

            //    // UTF8のファイルの読み込み Edit.        
            //    string responce = await StorageControl.PCLLoadCommand();//登録データ読み込み
            //    List<Price> prices = Finance.Parse(responce);

            //    string[] responceAray = new string[prices.Count * 3];

            //    foreach (Price price in prices)
            //    {
            //        responceAray[0 + i] = price.Name;
            //        responceAray[1 + i] = Convert.ToString(price.Stocks);
            //        responceAray[2 + i] = Convert.ToString(price.Itemprice) + '\n';
            //        i = i + 3;
            //    }
            //    usercode.Text = responceAray[0 + StrId * 3];//price.Name;
            //    usercost.Text = responceAray[1 + StrId * 3];//price.Stocks;
            //    usershares.Text = responceAray[2 + StrId * 3];//price.Itemprice;
            //    //await DisplayAlert("Anser", "ID= " + strId + "    " + Convert.ToString(prices[StrId].Name), "Ok");
            //}


        }
    }
}

