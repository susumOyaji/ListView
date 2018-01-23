using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ListView
{
    /// <summary>
    /// ListView を表示する View の ViewModel
    /// </summary>
    class ListViewPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// View への参照
        /// </summary>
        public ListViewPage View { get; set; }

        /// <summary>
        /// ListView へ表示するデータ
        /// </summary>
        public ObservableCollection<string> ItemList { get; } = new ObservableCollection<string>(new[] { "item01", "item02", "item03", "item04" });


        List<Price> prices = new List<Price>(); //ｺﾝｽﾄﾗｸﾀ
        public ObservableCollection<string> PriceItemList { get; set; }
        public void Sample()
        {
            PriceItemList = new ObservableCollection<string>(new[] { "15", });

            //PriceItemList = new ObservableCollection<Price>() {
            //    new Price()
            //    {
            //        Name = "Sony",
            //        Stocks = 100,
            //        Itemprice = 2015,
            //        Realprice = 1000,
            //        RealValue = 100,
            //        Percent = "5"
            //    },
            //    new Price()
            //    {

            //    }


            //};


        }


      



    ////////////////////////
    public class MainViewModel
        {
            public ObservableCollection<string> ItemListSample { get; set; }
            public MainViewModel()
            {
                ItemListSample = new ObservableCollection<string>(new[] { "itemsample1","itemsample2" } );
            }

        }
      







        /// <summary>
        /// ListView の各 Item 内の Button にバインディングする Command
        /// </summary>
        public ICommand ItemCommand { get; }

        /// <summary>
        /// デフォルト コンストラクタ
        /// </summary>
        public ListViewPageViewModel()
        {
            ItemCommand = new CountUpCommand(OnItemCommand);
            
        }

        /// <summary>
        /// ListView の Button 押下時の動作
        /// </summary>
        /// <param name="parameter"></param>
        private void OnItemCommand( )
        {
            View.DisplayAlert("XSample", "parameter.ToString()", "OK");
        }
    }
}