using System;

using Xamarin.Forms;

namespace ListView.View
{
    public class EntryPage : ContentPage
    {
        public EntryPage()
        {
            var usercode = new Entry { Placeholder = "Code", Keyboard = Keyboard.Text, };
            var usercost = new Entry { Placeholder = "株数", Keyboard = Keyboard.Numeric };
            var usershares = new Entry { Placeholder = "買価", Keyboard = Keyboard.Numeric };

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
                BackgroundColor = Color.White,
                VerticalOptions = LayoutOptions.Start,
                Children = { usercode, usercost, usershares,
                            new StackLayout
                            {
                                HorizontalOptions = LayoutOptions.Center,
                                Orientation = StackOrientation.Horizontal,
                                Children ={
                                    Save,Cancel,Edit
                                }
                             }
                        }
            };

           
        }
    }
}

