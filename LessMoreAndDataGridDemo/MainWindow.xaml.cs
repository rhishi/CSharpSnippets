using System;
using System.Windows;
using System.Windows.Data;

namespace LessMoreAndDataGridDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var personInfos = new[]
            {
                new { FirstName = "Lorem", LastName = "Ipsum", Age = 33, Email = new Uri("mailto:lorem34s@gmail.com") },
                new { FirstName = "Labore", LastName = "Aliqua", Age = 35, Email = new Uri("mailto:labore.aliqua@gmail.com") },
                new { FirstName = "Aute", LastName = "Cillum", Age = 34, Email = new Uri("mailto:autecillum@gmail.com") },
                new { FirstName = "Veniam", LastName = "Proident", Age = 38, Email = new Uri("mailto:sedveniam@gmail.com") },
                new { FirstName = "Officia", LastName = "Adipiscing", Age = 32, Email = new Uri("mailto:offiscing@gmail.com") },
                new { FirstName = "Mollit", LastName = "Irure", Age = 30, Email = new Uri("mailto:iruremollit@gmail.com") },
                new { FirstName = "Amet", LastName = "Cupidatat", Age = 30, Email = new Uri("mailto:cupidatatamet@gmail.com") },
                new { FirstName = "Consec", LastName = "Tetur", Age = 30, Email = new Uri("mailto:consectetur@gmail.com") }
            };

            Grid1.ItemsSource = personInfos;
            Grid2.DataContext = personInfos;
            Grid3.DataContext = personInfos;
        }

        private void LessMoreButton_OnClick(object sender, RoutedEventArgs e)
        {
            ((MainWindowViewModel)this.DataContext).ToggleLessMore();
        }
    }

    /// <summary>
    /// Converts between "mailto:" URI and string that is just the email address.
    /// </summary>
    public class EmailConverter : IValueConverter
    {
        /// <summary>
        /// Converts from "mailto:" URI to string email address.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                var emailUri = value.ToString();
                var email = emailUri.Substring(7, emailUri.Length - 7);
                return email;
            }
            return String.Empty;
        }

        /// <summary>
        /// Converts string email address to "mailto:" URI.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var email = new Uri((string)value);
            return email;
        }
    }
}
