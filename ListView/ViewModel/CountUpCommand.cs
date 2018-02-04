using System;
using System.Windows.Input;

namespace ListView
{
    internal class CountUpCommand : ICommand
    {
        #region メンバ変数

        private readonly Action _action;

        #endregion

        #region イベント

        public event EventHandler CanExecuteChanged;

        #endregion

        #region コンストラクタ

        internal  CountUpCommand(Action action)
        {
            this._action = action;
        }

        #endregion

        #region メソッド

        /// <summary>
        /// ボタンクリック時に呼び出される
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// CanExecuteがtrueだったら呼び出される
        /// </summary>
        /// <param name="parameter"></param>
        ///コマンドで実行する処理の実体です。
        ///parameterにはXAML側でCommandParameterというのを指定すると渡されてきます。
        /// CommandParameterがXAML側で指定されていないと、nullが渡ってきます。
        public void Execute(object parameter)
        {
            this._action();
        }

        #endregion
    }




}