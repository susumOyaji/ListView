using System;

using Xamarin.Forms;

namespace ListView.View
{
    public class EntryPage : ContentPage
    {
       
        public  EntryPage(ItemTappedEventArgs e)
        {
            var str = ((ItemTappedEventArgs)e).Item;

            object[] values = { false, 12.63m, new DateTime(2009, 6, 1, 6, 32, 15), 16.09e-12,
                    'Z', 15.15322, SByte.MinValue, Int32.MaxValue };

            string result;

            foreach (object value in values)
            {
                result = Convert.ToString(value);
                Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.",value.GetType().Name, value,
                                     result.GetType().Name, result);
            }




            //str.ToString();
            //string strId = ((MenuItem)sender).StyleId;
            //int StrId = Convert.ToInt16(strId);
            var i = 0;


            // ナビゲーションバーの右上にボタンを追加する。
            //ToolbarItems.Add(new ToolbarItem("Name", "icon.png", async () =>
            //{
            //    // 何か処理を記述
            //}));
            ToolbarItems.Add(new ToolbarItem
            { // <-2
                Text = "Cansel", // <-3
                Command = new Command(() => DisplayAlert("Selected", "menu1", "OK")) //<-4
            });
            ToolbarItems.Add(new ToolbarItem { Text = "Edit" });
            ToolbarItems.Add(new ToolbarItem { Text = "Save" });


            //NavigationPage.SetHasNavigationBar(this, false);
            var usercode = new Entry { Placeholder = (string)str, PlaceholderColor = Color.Red,TextColor =Color.White, Keyboard = Keyboard.Default };
            var usercost = new Entry { Placeholder = "株数", PlaceholderColor = Color.Red,Keyboard = Keyboard.Numeric };
            var usershares = new Entry { Placeholder = "買価", PlaceholderColor = Color.Red,Keyboard = Keyboard.Numeric };

            Button Save = new Button { BackgroundColor = Color.Gray, Text = "Save" };
            //Save.Clicked += Entry_Completed;

            Button Cancel = new Button { BackgroundColor = Color.Red, Text = "Cansel" };
            //Cancel.Clicked += Entry_Cancel;

            Button Edit = new Button { BackgroundColor = Color.Gray, Text = "Edit" };
            //Edit.Clicked += (object s, EventArgs f) => Edit_Completed(sender, e, StrId);
            Edit.IsEnabled = false;

            Content = new StackLayout
            {
                Padding = 20,
                BackgroundColor = Color.Black,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { usercode, usercost, usershares,
                            new StackLayout
                            {
                                HorizontalOptions = LayoutOptions.Center,
                                Orientation = StackOrientation.Horizontal,
                                Children ={
                                   // Save,Cancel,Edit
                                }
                             }
                        }
            };

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

