using System;
using System.Windows;
using System.Windows.Data;

namespace DataGridDemo
{
    /// <summary>
    /// Interaction logic for DataGridDemoWindow.xaml
    /// </summary>
    public partial class DataGridDemoWindow : Window
    {
        public DataGridDemoWindow()
        {
            InitializeComponent();
        }

        private void SelectButton_OnClick(object sender, RoutedEventArgs e)
        {
            ((DataGridDemoViewModel)DataContext).SelectButtonClicked();
        }

        private void BuyButton_OnClick(object sender, RoutedEventArgs e)
        {
            ((DataGridDemoViewModel)DataContext).BuyButtonClicked();
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            ((DataGridDemoViewModel)DataContext).CancelButtonClicked();
        }
    }

    /// <summary>
    /// Converter that inverts a Boolean value.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(bool))]
    public class InverseBooleanConverter : IValueConverter
    {
        /// <summary>
        /// Inverts a Boolean value.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }

        /// <summary>
        /// Inverts a Boolean value.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }
    }
}
