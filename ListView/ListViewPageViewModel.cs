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
        //public ObservableCollection<string> ItemList { get; } = new ObservableCollection<string>(new[] { "item01", "item02", "item03", "item04" });



        /// <summary>
        /// ListView の各 Item 内の Button にバインディングする Command
        /// </summary>
        public ICommand ItemCommand { get; }
        List<Price> price = new List<Price>();

        /// <summary>
        /// デフォルト コンストラクタ
        /// </summary>
        public ListViewPageViewModel()
        {
            ItemCommand = new CountUpCommand(OnItemCommand);
            Sample();
            DispSet();
        }

        /// <summary>
        /// ListView の Button 押下時の動作
        /// </summary>
        /// <param name="parameter"></param>
        private void OnItemCommand()
        {
            View.DisplayAlert("XSample", ItemCommand.ToString(), "OK");
            View.ChangeButtonColor();
        }


     








        public ObservableCollection<Price> ItemList { get; set; }
       
        public void Sample()
        {
            //PriceItemList = new ObservableCollection<Price>();


            ItemList = new ObservableCollection<Price>() {
                new Price()
                {
                    Name = "Sony",
                    Stocks = 100,
                    Itemprice = 2015,
                    Realprice = 1000,
                    RealValue = 100,
                    Percent = "5"
                },
                new Price()
                {
                    Name = "Morito",
                    Stocks = 100,
                    Itemprice = 2015,
                    Realprice = 1000,
                    RealValue = 100,
                    Percent = "5"
                },


            };


        }

     

        private decimal _stocks { get; set; }
        public decimal Stocks
       {
            get { return _stocks; }
            set
            {
                _stocks = value;
               // this.OnPropertyChanged(nameof(Stocks));
            }

        }





        public async void DispSet()
        {
            int i = 0;
            decimal TotalAssetAdd = 0;
            decimal PayAssetpriceAdd = 0;




            // UTF8のファイルの書き込み Edit. 
            string write = await StorageControl.PCLSaveCommand("6758,200,1665\n9837,200,712\n6976,200,1846");//登録データ書き込み
            List<Price> prices = Finance.Parse(await StorageControl.PCLLoadCommand());//登録データ読み込み
            List<Price> pricesanser = await Models.PasonalGetserchi();//登録データの現在値を取得する





            foreach (Price item in prices)
            {
                Stocks = pricesanser[i].Stocks;//保有数*
                //Itemprice = pricesanser[i].Itemprice;//購入価格*
                //Realprice = pricesanser[i].Realprice;//現在値*
                //Percent = pricesanser[i].Percent;//前日比％**
                PayAssetpriceAdd = PayAssetpriceAdd + (pricesanser[i].Stocks * Convert.ToDecimal(pricesanser[i].Itemprice));//株数*購入単価の合計

                TotalAssetAdd = TotalAssetAdd + (pricesanser[i].Stocks * Convert.ToDecimal(pricesanser[i].Realprice));//現在評価額
                //Polar = pricesanser[i].Polar;

                ItemList.Add(pricesanser[i]);// item);

                i = ++i;
            }
            //PayAssetprice = PayAssetpriceAdd;
            //TotalAsset = TotalAssetAdd;




        }

    }
}