using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace radiobuttonlist
{
    public class RadioButtonList : ItemsControl
    {
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            //ItemTemplateをプロパティ値から動的に作成
            var elementFactory = new FrameworkElementFactory(typeof(RadioButton));
            if (!string.IsNullOrEmpty(TitleMemberPath))
            {
                elementFactory.SetValue(RadioButton.ContentProperty, new Binding(TitleMemberPath));
            }
            if (!string.IsNullOrEmpty(IsCheckedMemberPath))
            {
                elementFactory.SetValue(RadioButton.IsCheckedProperty, new Binding(IsCheckedMemberPath));
            }
            elementFactory.SetValue(RadioButton.GroupNameProperty, string.IsNullOrEmpty(GroupName) ? Guid.NewGuid().ToString() : GroupName);
            elementFactory.AddHandler(RadioButton.CheckedEvent, new RoutedEventHandler(CheckedMethod));
            this.ItemTemplate = new DataTemplate { VisualTree = elementFactory };
        }

        /// <summary>
        /// チェック時のイベントメソッド
        /// </summary>
        /// <param name="sender">チェックされたラジオボタン</param>
        /// <param name="e">イベント引数</param>
        private void CheckedMethod(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement)
            {
                CheckedItem = (sender as FrameworkElement).DataContext;
            }
        }

        #region Propeties

        public object CheckedItem
        {
            get { return (object)GetValue(CheckedItemProperty); }
            set { SetValue(CheckedItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CheckedItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CheckedItemProperty =
            DependencyProperty.Register("CheckedItem", typeof(object), typeof(RadioButtonList), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string GroupName { get; set; }

        public string TitleMemberPath { get; set; }

        public string IsCheckedMemberPath { get; set; }
        #endregion
    }
}
