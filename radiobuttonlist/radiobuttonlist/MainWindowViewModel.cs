using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace radiobuttonlist
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            Items.Add(new RadioButtonItem() { IsChecked = true, Title = "test1" });
            Items.Add(new RadioButtonItem() { IsChecked = false, Title = "test2" });
            Items.Add(new RadioButtonItem() { IsChecked = false, Title = "test2" });
            Items.Add(new RadioButtonItem() { IsChecked = false, Title = "test2" });
            Items.Add(new RadioButtonItem() { IsChecked = false, Title = "test2" });
            Items.Add(new RadioButtonItem() { IsChecked = false, Title = "test2" });
            Items.Add(new RadioButtonItem() { IsChecked = false, Title = "test2" });
            Items.Add(new RadioButtonItem() { IsChecked = false, Title = "test2" });
            Items.Add(new RadioButtonItem() { IsChecked = false, Title = "test2" });
            Items.Add(new RadioButtonItem() { IsChecked = false, Title = "test2" });
        }

        private ObservableCollection<RadioButtonItem> _items = new ObservableCollection<RadioButtonItem>();

        /// <summary>
        /// Sets and gets the Items property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<RadioButtonItem> Items
        {
            get
            {
                return _items;
            }

            set
            {
                if (_items == value)
                {
                    return;
                }

                _items = value;
                RaisePropertyChanged();
            }
        }


        private RadioButtonItem _checkedItem = null;

        /// <summary>
        /// Sets and gets the CheckedItem property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public RadioButtonItem CheckedItem
        {
            get
            {
                return _checkedItem;
            }

            set
            {
                if (_checkedItem == value)
                {
                    return;
                }

                _checkedItem = value;
                RaisePropertyChanged();
                RaisePropertyChanged("CheckedItemText");
            }
        }

        public string CheckedItemText
        {
            get { return _checkedItem?.Title; }
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
