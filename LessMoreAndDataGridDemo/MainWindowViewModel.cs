using System.ComponentModel;

namespace LessMoreAndDataGridDemo
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Lorem Ipsum text taken from www.lipsum.com and Wikipedia
        /// </summary>
        public const string LoremIpsum =
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do " +
            "eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim " +
            "ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut " +
            "aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit " +
            "in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur " +
            "sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt " +
            "mollit anim id est laborum.";

        public MainWindowViewModel()
        {
            Text = LoremIpsum;
            ShowMore = true;
        }

        public string Text
        {
            get;
            private set;
        }

        public string LessMore => ShowMore ? "less" : "more";

        public bool ShowMore
        {
            get;
            private set;
        }

        public void ToggleLessMore()
        {
            ShowMore = !ShowMore;
            NotifyPropertyChanged("ShowMore");
            NotifyPropertyChanged("LessMore");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
