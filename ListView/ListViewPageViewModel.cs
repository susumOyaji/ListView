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
        public ObservableCollection<string> ItemList { get; } = new ObservableCollection<string>(new[] { "item01", "item02", "item03" });

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
        private void OnItemCommand()
        {
            View.DisplayAlert("XSample", "parameter.ToString()", "OK");
        }
    }
}