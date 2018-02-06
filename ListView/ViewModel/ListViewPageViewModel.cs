using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;



namespace ListView
{
    /// <summary>
    /// ListView を表示する View の ViewModel
    /// </summary>
    class ListViewPageViewModel : ViewModelBase //INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        bool Flag = true;
        
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
        public ICommand IndnButtonClick { protected set; get; }
        public ICommand ItemCommand { protected set; get; }
        public ICommand RefCommand { protected set; get; }

        #region
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

        private static decimal _currentTokyoStockPrice;
        public decimal TokyoStockPrice
        {
            get { return _currentTokyoStockPrice; }
            set
            {
                _currentTokyoStockPrice = value;
                this.OnPropertyChanged(nameof(TokyoStockPrice));
            }
        }

        private static string _currentTokyoStockPercent;
        public string TokyoStockPercent
        {
            get { return _currentTokyoStockPercent; }
            set
            {
                _currentTokyoStockPercent = value;
                this.OnPropertyChanged(nameof(TokyoStockPercent));
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


        private static string _currentColor;
        public string NYorkButtonColor
        {
            get { return _currentColor; }
            set
            {
                _currentColor = value;
                this.OnPropertyChanged(nameof(NYorkButtonColor));
            }
        }


        private static decimal _uptoAsset;
        public decimal UptoAsset
        {
            get { return _uptoAsset;}
            set
            {
                _uptoAsset = value;
                this.OnPropertyChanged(nameof(UptoAsset));
            }
        }


        private static string _id;
        public string ButtonId//保有数*
        {
            get { return _id; }
            set
            {
                _id = value;
                this.OnPropertyChanged(nameof(ButtonId));
            }
        }

        private static string _buttonColor;
        public string ButtonColor
        {
            get { return _buttonColor; }
            set
            {
                _buttonColor = value;
                this.OnPropertyChanged(nameof(ButtonColor));
            }
        }



        private static string _gainColor;
        public string GainColor
        {
            get { return _gainColor; }
            set
            {
                _gainColor = value;
                this.OnPropertyChanged(nameof(GainColor));
            }
        }


        private static string inputString = "";
        // Public properties
        public string InputString
        {
            get { return inputString; }
            set
            {
                if (inputString != value)
                {
                    inputString = value;
                }
                inputString = value;
                this.OnPropertyChanged(nameof(InputString));
            }
         }


#endregion



        /// <summary>
        /// デフォルト コンストラクタ
        /// </summary>
        public ListViewPageViewModel()
        {
            IndnButtonClick = new CountUpCommand(Indnswitch);
            //ItemCommand = new CountUpCommand(OnItemCommand);
            ItemList = new ObservableCollection<Price>();
            RefCommand = new CountUpCommand(IncrementData);

            ItemCommand  = new Command<string>((key) =>
            {
                // Add the key to the input string.
                //InputString += key;
                OnItemCommand(key);
            });
         

            IndnStock();
            Ni255Stock();

            //Sample();
            DispSet(false);
        }



        #region メソッド

        Price anser;
       
        private async void IndnStock()
        {
            anser = await Models.Getserchi("^DJI");

            NewYorkStockPrice = anser.Realprice;
            NewYorkStockPercent = anser.Prev_day;
            View.IndnButtonColor(anser.Polar);
        }


        private void Indnswitch()
        {
            if (Flag == false)
            {
                //Flag = !Flag;
                NewYorkStockPercent = anser.Prev_day+Flag;

            }

            if (Flag == true)
            {
                //Flag = !Flag;
                NewYorkStockPercent = anser.Percent+Flag;
               
            }

        }


        private async void Ni255Stock()
        {
            var anser = await Models.Getserchi("998407");

            TokyoStockPrice = anser.Realprice;
            TokyoStockPercent = anser.Prev_day;
            View.Ni255ButtonColor(anser.Polar);


            if (anser.Polar == "-")
            {
                //NewYorkStockPercent = anser.Percent;
                NYorkButtonColor = "Green";
            }
            if (anser.Polar == "+")
            {
                //NewYorkStockPercent = Dayratio;
                NYorkButtonColor = "Red";
            }

        }

        #endregion

        //public ICommand Loss { get; } //ListView の各 Item 内の Button にバインディングする Command
     



        /// <summary>
        /// ListView の Button 押下時の動作
        /// </summary>
        /// <param name="parameter"></param>
        private void OnItemCommand(string key)
        {
            View.DisplayAlert("XSample", "SelectItem-"+key, "OK");

            var index = Convert.ToInt32(key);
          

            ItemList[index].ButtonColor = "Green";

        }

             
               
        private void Sample()
        {
            //ItemList = new ObservableCollection<Price>();
            //TopList = new ObservableCollection<CityPrice>();


            ItemList.Add(new Price
            {
                Name = "SampleSony",
                Stocks = 100,
                Itemprice = 2015,
                Realprice = 1000,
                RealValue = 100,
                ButtonId = "sample",
                ButtonColor = "Red",
                Percent = "5"
            });

        }

     





        public async void DispSet(bool Refresh)
        {
            int i = 0;
            decimal TotalAssetAdd = 0;
            decimal PayAssetpriceAdd = 0;

            // UTF8のファイルの書き込み Edit. 
            string write = await StorageControl.PCLSaveCommand("6758,200,1665\n9837,200,712\n6976,200,1846");//登録データ書き込み
           // List<Price> prices = Finance.Parse(await StorageControl.PCLLoadCommand());//登録データ読み込み
            List<Price> pricesanser = await Models.PasonalGetserchi();//登録データの現在値を取得する

            if (Refresh == true)
            {
                ItemList.Clear();// 全て削除
            }

            foreach (Price item in pricesanser)
            {

                ItemList.Add(new Price
                {
                    Name = item.Name,// "Sony",
                    Stocks = item.Stocks,//保有数*
                    Itemprice = item.Itemprice,// 2015,
                    Prev_day = item.Prev_day,//前日比±**
                    Realprice = item.Realprice,//現在値*// 1000,
                    RealValue = item.RealValue,// 100,
                    Percent = item.Percent,//前日比％**// "5"
                    ButtonId = i.ToString(),
                    ButtonColor = item.Polar
                });

                PayAssetpriceAdd = PayAssetpriceAdd + (pricesanser[i].Stocks * Convert.ToDecimal(pricesanser[i].Itemprice));//株数*購入単価の合計
                TotalAssetAdd = TotalAssetAdd + (pricesanser[i].Stocks * Convert.ToDecimal(pricesanser[i].Realprice));//現在評価額
               
                i = ++i;
            }
            PayAssetprice = PayAssetpriceAdd;
            TotalAsset = TotalAssetAdd;
            UptoAsset = TotalAsset - PayAssetprice;



        }


        public async void RefDispSet()
        {
            int i = 0;
            decimal TotalAssetAdd = 0;
            decimal PayAssetpriceAdd = 0;

            // UTF8のファイルの書き込み Edit. 
            string write = await StorageControl.PCLSaveCommand("6758,200,1665\n9837,200,712\n6976,200,1846");//登録データ書き込み
           // List<Price> prices = Finance.Parse(await StorageControl.PCLLoadCommand());//登録データ読み込み
            List<Price> priceanser = await Models.PasonalGetserchi();//登録データの現在値を取得する


            foreach (Price item in priceanser)
            {
                ItemList.Add(new Price
                {
                    Name = item.Name,// "Sony",
                    Stocks = item.Stocks,//保有数*
                    Itemprice = item.Itemprice,// 2015,
                    Prev_day = item.Prev_day,//前日比±**
                    Realprice = item.Realprice,//現在値*// 1000,
                    RealValue = item.RealValue,// 100,
                    Percent = item.Percent,//前日比％**// "5"
                    ButtonId = i.ToString(),
                    ButtonColor = item.Polar

                });
                PayAssetpriceAdd = PayAssetpriceAdd + (priceanser[i].Stocks * Convert.ToDecimal(priceanser[i].Itemprice));//株数*購入単価の合計
                TotalAssetAdd = TotalAssetAdd + (priceanser[i].Stocks * Convert.ToDecimal(priceanser[i].Realprice));//現在評価額

                i = ++i;
            }

            PayAssetprice = PayAssetpriceAdd;
            TotalAsset = TotalAssetAdd;
            UptoAsset = TotalAsset - PayAssetprice;

        }



        public void IncrementData()
        {
            IndnStock();
            Ni255Stock();
            DispSet(true);
        }





    }
}