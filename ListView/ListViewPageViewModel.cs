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
    class ListViewPageViewModel : ViewModelBase //INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// View への参照
        /// </summary>
        public ListViewPage View { get; set; }

        /// <summary>
        /// ListView へ表示するデータ
        /// </summary>
        //ObservableCollection<string> ItemList { get; } = new ObservableCollection<string>(new[] { "item01", "item02", "item03", });

        



        /// <summary>
        /// ListView の各 Item 内の Button にバインディングする Command
        /// </summary>
        public ICommand ItemCommand { get; }
        //List<Price> price = new List<Price>();
        public ObservableCollection<Price> ItemList { get; set; }


        private static decimal _payAssetprice;
        public decimal PayAssetprice//保有数* 購入価格 = 投資総額
        {
            get { return _payAssetprice; }
            set
            {
                _payAssetprice = value;
                this.OnPropertyChanged(nameof(PayAssetprice));
            }
        }

        public static decimal _totalAsset;
        public decimal TotalAsset //現在評価額合計
        {
            get { return _totalAsset; }
            set
            {
                _totalAsset = value;
               this.OnPropertyChanged(nameof(TotalAsset));
            }

        }

        private static decimal _currentStockPrice;
        public decimal NewYorkStockPrice
        {
            get { return _currentStockPrice; }
            set
            {
                _currentStockPrice = value;
                this.OnPropertyChanged(nameof(NewYorkStockPrice));
            }
        }



        private static string _currentStockPercent;
        public string NewYorkStockPercent
        {
            get { return _currentStockPercent; }
            set
            {
                _currentStockPercent = value;
                this.OnPropertyChanged(nameof(NewYorkStockPercent));
            }
        }

        private static string _polar;
        public string Polar//(-)下落
        {
            get { return _polar; }
            set
            {
                _polar = value;
                // StockMvvmView.ChangeButtonColor(_polar);
                this.OnPropertyChanged(nameof(Polar));
            }
        }













        /// <summary>
        /// デフォルト コンストラクタ
        /// </summary>
        public ListViewPageViewModel()
        {
            ItemCommand = new CountUpCommand(OnItemCommand);

            ItemList = new ObservableCollection<Price>();

            Sample();
            DispSet();
        }




        #region メソッド

        private async void NewYorkStock()
        {
            //CurrentColor = MainModelS.NewyorkButtonColer(CurrentColor);
            var anser = await Models.Models.Getserchi("^DJI");
            NewYorkStockPrice = anser.Realprice;
            NewYorkStockPercent = anser.Prev_day;

            if (anser.Polar == "Green")
            {
                //NewYorkStockPercent = anser.Percent;
                Polar = anser.Polar;// "Green";
            }
            if (anser.Polar == "Red")
            {
                //NewYorkStockPercent = Dayratio;
                Polar = anser.Polar; //CurrentColor = "Red";
            }

        }

        private async void TokyoStock()
        {
            var anser = await Models.Models.Getserchi("998407");
            TokyoStockPrice = anser.Realprice;
            TokyoStockPercent = anser.Prev_day;

            if (anser.Polar == "-")
            {
                //NewYorkStockPercent = anser.Percent;
                CurrentColor = "Green";
            }
            if (anser.Polar == "+")
            {
                //NewYorkStockPercent = Dayratio;
                CurrentColor = "Red";
            }

        }

        #endregion



        /// <summary>
        /// ListView の Button 押下時の動作
        /// </summary>
        /// <param name="parameter"></param>
        private void OnItemCommand()
        {
            View.DisplayAlert("XSample", ItemCommand.ToString(), "OK");
           // View.ChangeButtonColor();
        }


     
               
        public void Sample()
        {
            ItemList = new ObservableCollection<Price>();


            ItemList.Add(new Price
            {
                Name = "SampleSony",
                Stocks = 100,
                Itemprice = 2015,
                Realprice = 1000,
                RealValue = 100,
                Percent = "5"
            });


        }

     





        public async void DispSet()
        {
            int i = 0;
            decimal TotalAssetAdd = 0;
            decimal PayAssetpriceAdd = 0;

            // UTF8のファイルの書き込み Edit. 
            string write = await StorageControl.PCLSaveCommand("6758,200,1665\n9837,200,712\n6976,200,1846");//登録データ書き込み
           // List<Price> prices = Finance.Parse(await StorageControl.PCLLoadCommand());//登録データ読み込み
            List<Price> pricesanser = await Models.PasonalGetserchi();//登録データの現在値を取得する

            

            foreach (Price item in pricesanser)
            {

                ItemList.Add(new Price
                {
                    Name = item.Name,// "Sony",
                    Stocks = item.Stocks,//保有数*
                    Itemprice = item.Itemprice,// 2015,
                    Realprice = item.Realprice,//現在値*// 1000,
                    RealValue = item.RealValue,// 100,
                    Percent = item.Percent//前日比％**// "5"
                });

                PayAssetpriceAdd = PayAssetpriceAdd + (pricesanser[i].Stocks * Convert.ToDecimal(pricesanser[i].Itemprice));//株数*購入単価の合計

                TotalAssetAdd = TotalAssetAdd + (pricesanser[i].Stocks * Convert.ToDecimal(pricesanser[i].Realprice));//現在評価額
                //Polar = pricesanser[i].Polar;

               // ItemList.Add(item);// item);

                i = ++i;
            }
            PayAssetprice = PayAssetpriceAdd;
            TotalAsset = TotalAssetAdd;




        }

    }
}