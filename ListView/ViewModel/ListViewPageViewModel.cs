using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Forms;



namespace ListView
{
    /// <summary>
    /// ListView を表示する View の ViewModel
    /// </summary>
    class ListViewPageViewModel : ViewModelBase //INotifyPropertyChanged
    {
        public new event PropertyChangedEventHandler PropertyChanged;

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
        //public ICommand IndnButtonClick { protected set; get; }
        //public ICommand Ni255ButtonClick { protected set; get; }
        public ICommand ItemCommand { protected set; get; }
        public ICommand RefCommand { protected set; get; }
        // LiseViewのButtonにバインディングするCommand
        // ListViewを引っ張った時に実行させるコマンド
        public ICommand RefreshCommand { get; private set; }

        public ObservableCollection<Price> ItemList { get; set; }
        // public ObservableCollection<Price> ItemStd { get; set; }


        #region  OnPropertyChanged
        //private static decimal _currentStockPrice;
        //public decimal NewYorkStockPrice
        //{
        //    get { return _currentStockPrice; }
        //    set
        //    {
        //        _currentStockPrice = value;
        //        this.OnPropertyChanged(nameof(NewYorkStockPrice));
        //    }
        //}



        //private static string _currentStockPercent;
        //public string NewYorkStockPercent
        //{
        //    get { return _currentStockPercent; }
        //    set
        //    {
        //        _currentStockPercent = value;
        //        this.OnPropertyChanged(nameof(NewYorkStockPercent));
        //    }
        //}

        //private static decimal _currentTokyoStockPrice;
        //public decimal TokyoStockPrice
        //{
        //    get { return _currentTokyoStockPrice; }
        //    set
        //    {
        //        _currentTokyoStockPrice = value;
        //        this.OnPropertyChanged(nameof(TokyoStockPrice));
        //    }
        //}

        //private static string _currentTokyoStockPercent;
        //public string TokyoStockPercent
        //{
        //    get { return _currentTokyoStockPercent; }
        //    set
        //    {
        //        _currentTokyoStockPercent = value;
        //        this.OnPropertyChanged(nameof(TokyoStockPercent));
        //    }
        //}

    



        //private static string _gainColor;
        //public string GainColor
        //{
        //    get { return _gainColor; }
        //    set
        //    {
        //        _gainColor = value;
        //        this.OnPropertyChanged(nameof(GainColor));
        //    }
        //}




        //private static string _currentColor;
        //public string NYorkButtonColor
        //{
        //    get { return _currentColor; }
        //    set
        //    {
        //        _currentColor = value;
        //        this.OnPropertyChanged(nameof(NYorkButtonColor));
        //    }
        //}

        #endregion

        #region  PropertyChanged
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


        private static decimal _uptoAsset;
        public decimal UptoAsset
        {
            get { return _uptoAsset; }
            set
            {
                _uptoAsset = value;
                this.OnPropertyChanged(nameof(UptoAsset));
            }
        }


        private static int _id;
        public int ButtonId//保有数*
        {
            get { return _id; }
            set
            {
                _id = value;
                this.OnPropertyChanged(nameof(ButtonId));
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


        public static string _percent;
        public string Percent
        {
            get { return _percent; }
            set
            {
                if (_percent != value)
                {
                    _percent = value;
                }
                _percent = value;
                this.OnPropertyChanged(nameof(Percent));
            }
        }


        public static string _prev_day;
        public string Prev_day
        {
            get { return _prev_day; }
            set
            {
                if (_prev_day != value)
                {
                    _prev_day = value;
                }
                _prev_day = value;
                this.OnPropertyChanged(nameof(Prev_day));
            }
        }



        public static decimal _realprice;
        public decimal Realprice
        {
            get { return _realprice; }
            set
            {
                if (_realprice != value)
                {
                    _realprice = value;
                }
                _realprice = value;
                this.OnPropertyChanged(nameof(Realprice));
            }
        }

        public static string _whichOn;
        public string WhichOne
        {
            get { return _whichOn; }
            set
            {
                if (_whichOn != value)
                {
                    _whichOn = value;
                }
                _whichOn = value;
                this.OnPropertyChanged(nameof(WhichOne));
            }
        }


        //Ni255

        public static string _Ni255percent;
        public string Ni255Percent
        {
            get { return _Ni255percent; }
            set
            {
                if (_Ni255percent != value)
                {
                    _Ni255percent = value;
                }
                _Ni255percent = value;
                this.OnPropertyChanged(nameof(Ni255Percent));
            }
        }




        public static string _Ni255prev_day;
        public string Ni255Prev_day
        {
            get { return _Ni255prev_day; }
            set
            {
                if (_Ni255prev_day != value)
                {
                    _Ni255prev_day = value;
                }
                _Ni255prev_day = value;
                this.OnPropertyChanged(nameof(Ni255Prev_day));
            }
        }



        public static decimal _Ni255realprice;
        public decimal Ni255Realprice
        {
            get { return _Ni255realprice; }
            set
            {
                if (_Ni255realprice != value)
                {
                    _Ni255realprice = value;
                }
                _Ni255realprice = value;
                this.OnPropertyChanged(nameof(Ni255Realprice));
            }
        }

        public static string _Ni255whichOn;
        public string Ni255WhichOne
        {
            get { return _Ni255whichOn; }
            set
            {
                if (_Ni255whichOn != value)
                {
                    _Ni255whichOn = value;
                }
                _Ni255whichOn = value;
                this.OnPropertyChanged(nameof(Ni255WhichOne));
            }
        }

      
        public static string _firstLastName;
        public string FirstLastName
        {
            get { return _firstLastName; }
            set
            {
                if (_firstLastName != value)
                {
                    _firstLastName = value;
                }
                _firstLastName = value;
                this.OnPropertyChanged(nameof(FirstLastName));
            }
        }

       
        public static string _Ni255firstLastName;
        public string Ni255FirstLastName
        {
            get { return _Ni255firstLastName; }
            set
            {
                if (_Ni255firstLastName != value)
                {
                    _Ni255firstLastName = value;
                }
                _Ni255firstLastName = value;
                this.OnPropertyChanged(nameof(Ni255FirstLastName));
            }
        }


        private static string _Ni255polar;
        public string Ni255Polar//(-)下落
        {
            get { return _Ni255polar; }
            set
            {
                _Ni255polar = value;
                // StockMvvmView.ChangeButtonColor(_polar);
                this.OnPropertyChanged(nameof(Ni255Polar));
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

        //public static string[] _pwhichOn;
        //public string[] PWhichOne
        //{
        //    get { return _pwhichOn; }
        //    set
        //    {
        //        if (_pwhichOn != value)
        //        {
        //            _pwhichOn = value;
        //        }
        //        _pwhichOn = value;
        //        this.OnPropertyChanged(nameof(PWhichOne));
        //    }
        //}




        // ListView.IsRefreshingと同期させるプロパティ
        //private bool isRefreshing;
        //public bool IsRefreshing
        //{
        //    get { return isRefreshing; }
        //    set
        //    {
        //        if (value == isRefreshing)
        //            return;
        //        isRefreshing = value;
        //        this.OnPropertyChanged(nameof(IsRefreshing));
        //    }
        //}




        #endregion



        /// <summary>
        /// デフォルト コンストラクタ
        /// </summary>
        public ListViewPageViewModel()
        {
            //IndnButtonClick = new CountUpCommand(Indnswitch);
            //Ni255ButtonClick = new CountUpCommand(Ni255switch);
           
            ItemList = new ObservableCollection<Price>();
        
            RefCommand = new CountUpCommand(IncrementData);

            RefreshCommand = new Command<string>((key) =>
            {
               Refresh(key);
            });
           
            ItemCommand = new Command<string>((key) =>
            {
               // Add the key to the input string.
               //InputString += key;
               OnItemCommand(key);
            });
                     
            StdStock();
            // Ni255Stock();
            //Sample();
            DispSet(false);

        }

        #region メソッド





        private async void Refresh(string key)
        {
            await View.DisplayAlert("XSample", "SelectItem-" + key, "OK");

            var index = Convert.ToInt32(key);

          

            List<Price> pricesanser = await Models.PasonalGetserchi();//登録データの現在値を取得する
            //pricesanser[index].PriceSwith();
            //ItemList[index].PriceSwith();

            ItemList[index] = (new Price
            {
                Name = pricesanser[index].Name,// "Sony",
                Stocks = pricesanser[index].Stocks,//保有数*
                Itemprice = pricesanser[index].Itemprice,//
                Prev_day = pricesanser[index].Percent,//前日比％**
                Realprice = pricesanser[index].Realprice,//現在値*// 1000,
                RealValue = pricesanser[index].RealValue,// 100,
                Percent = pricesanser[index].Percent,//前日比％**// "5"
                Gain = pricesanser[index].Gain,//損益
                ButtonId = index.ToString(),
                ButtonColor = pricesanser[index].Polar,
               
            });


        }




        private async void StdStock()
        {
            Price IndnAnser = await Models.Getserchi("^DJI");
            Price Ni255Anser = await Models.Getserchi("998407");


            //var IndnButton = new Button { BackgroundColor = Color.Brown };

            //Binding binding = new Binding(nameof(IndnAnser.Polar)) { Source = IndnAnser };
            //IndnButton.SetBinding(Button.BackgroundColorProperty, binding);
           

            //// Changes source value.
            //IndnAnser.ButtonColor = "Red";



            //// Binding Target (DependencyObject).
            //var Goingprice = new Label { Text = "Default" };
          

            //// Binds target to source.
            //var binding1 = new Binding(nameof(IndnAnser.Realprice)) { Source = IndnAnser };
            //Goingprice.SetBinding(Label.TextProperty, binding1);
        

            // Changes source value.
            //IndnAnser.Realprice = 99999;
          



            //XAML
            //< TextBox Height = "24"  Width = "120" Text = "{Binding Path=Name}" />

            //C#Code
            ////設定
            //Binding binding = new Binding("Name");
            //textBox1.SetBinding(TextBox.TextProperty, binding);



            // Name = IndnAnser.Name,
            Prev_day = IndnAnser.Prev_day;//前日比±**
            Realprice = IndnAnser.Realprice;//現在値*
            Percent = IndnAnser.Percent;//前日比％**// "5"
            FirstLastName = IndnAnser.FirstLastName;
            Polar = IndnAnser.Polar;
            //ButtonColor = IndnAnser.Polar;
            ButtonId = 0;
            //View.IndnButtonColor(IndnAnser.Polar);


            //Name = Ni255Anser.Name;// "Sony",
            //Itemprice = Ni255Anser.Itemprice;// 2015,
            Ni255Prev_day = Ni255Anser.Prev_day;//前日比±**
            Ni255Realprice = Ni255Anser.Realprice;//現在値*
            Ni255Percent = Ni255Anser.Percent;//前日比％**// "5"
            Ni255FirstLastName = Ni255Anser.FirstLastName;
            Ni255Polar = Ni255Anser.Polar;
            ButtonId = 1;
           // View.Ni255ButtonColor(Ni255Anser.Polar);

        }


        //private void Indnswitch()
        //{
        //    if (WhichOne == Percent)
        //    {
        //        WhichOne = Prev_day;
        //    }
        //    else
        //    {
        //        WhichOne = Percent;
        //    }
        //}

        //private void Ni255switch()
        //{
        //    if (Ni255WhichOne == Ni255Percent)
        //    {
        //        Ni255WhichOne = Ni255Prev_day;
        //    }
        //    else
        //    {
        //        Ni255WhichOne = Ni255Percent;
        //    }
        //}


        //private async void Ni255Stock()
        //{
        //    var anser = await Models.Getserchi("998407");

        //    TokyoStockPrice = anser.Realprice;
        //    TokyoStockPercent = anser.Prev_day;
        //    //View.Ni255ButtonColor(anser.Polar);


        //    if (anser.Polar == "-")
        //    {
        //        //NewYorkStockPercent = anser.Percent;
        //        NYorkButtonColor = "Green";
        //    }
        //    if (anser.Polar == "+")
        //    {
        //        //NewYorkStockPercent = Dayratio;
        //        NYorkButtonColor = "Red";
        //    }

        //}

        #endregion

        //public ICommand Loss { get; } //ListView の各 Item 内の Button にバインディングする Command




        /// <summary>
        /// ListView の Button 押下時の動作
        /// </summary>
        /// <param name="parameter"></param>
        private void OnItemCommand(string key)
        {
            View.DisplayAlert("XSample", "SelectItem-" + key, "OK");

            var index = Convert.ToInt32(key);


            //SettersExtensions(index, ItemList[0].Percent);
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
                ButtonId = "Sample",
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
                    Itemprice = item.Itemprice,//
                    Prev_day = item.Prev_day,//前日比±**
                    Realprice = item.Realprice,//現在値*// 1000,
                    RealValue = item.RealValue,// 100,
                    Percent = item.Percent,//前日比％**// "5"
                    Gain = item.Gain,//損益
                    ButtonId = i.ToString(),
                   // ButtonColor = item.Polar,
                    Polar= item.Polar
                    //FirstLastName = item.FirstLastName
                });


                PayAssetpriceAdd = PayAssetpriceAdd + (pricesanser[i].Stocks * Convert.ToDecimal(pricesanser[i].Itemprice));//株数*購入単価の合計
                TotalAssetAdd = TotalAssetAdd + (pricesanser[i].Stocks * Convert.ToDecimal(pricesanser[i].Realprice));//現在評価額
                //Gain = item.Realprice - item.Itemprice;
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
            StdStock();
            // Ni255Stock();
            DispSet(true);
        }
        
    }

    public class ButtonClickedTriggerAction : TriggerAction<Button>
    { 
        protected override void Invoke(Button sender)
        { 
            var SourceWord = (string)sender.CommandParameter;
            int index = SourceWord.LastIndexOf(",");
            var PercentWord = SourceWord.Substring(index + 1, (SourceWord.Length - index) - 1);

            index = SourceWord.LastIndexOf(",");
            var Prev_dayWord = SourceWord.Substring(index - index,index);

            if (sender.Text == Prev_dayWord)
            {
                sender.Text = PercentWord;
            }
            else
            { 
                sender.Text = Prev_dayWord;
            }
        }
    }



}