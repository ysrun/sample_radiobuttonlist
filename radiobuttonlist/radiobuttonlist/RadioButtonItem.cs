using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace radiobuttonlist
{
    public class RadioButtonItem : INotifyPropertyChanged
    {
        private bool _isChecked = false;

        /// <summary>
        /// Sets and gets the IsChecked property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }

            set
            {
                if (_isChecked == value)
                {
                    return;
                }

                _isChecked = value;
                RaisePropertyChanged();
            }
        }


        private string _title = null;

        /// <summary>
        /// Sets and gets the Title property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                if (_title == value)
                {
                    return;
                }

                _title = value;
                RaisePropertyChanged();
            }
        }


        #region INotifyPropertyChangedInterfaceの実装
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region 変更通知用メソッド
        public void RaisePropertyChanged([CallerMemberName]string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

    }
}