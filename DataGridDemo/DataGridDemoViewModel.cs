using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace DataGridDemo
{
    public class DataGridDemoViewModel : INotifyPropertyChanged
    {
        public DataGridDemoViewModel()
        {
            EarlyComputers1 = new[]
            {
                new Computer1 { Model = "Colossus Mark 1", Maker = "Government", Country = "UK", Year = 1944, Description = "incididunt ut labore et dolore magna aliqua" },
                new Computer1 { Model = "Harvard Mark I", Maker = "Government", Country = "US", Year = 1944, Description = "Duis aute irure dolor in reprehenderit" },
                new Computer1 { Model = "Colossus Mark 2", Maker = "Government", Country = "UK", Year = 1944, Description = "in voluptate velit esse cillum dolore eu fugiat nulla pariatur" },
                new Computer1 { Model = "ENIAC", Maker = "Government", Country = "US", Year = 1946, Description = "sunt in culpa qui officia deserunt" },
                new Computer1 { Model = "EDSAC", Maker = "Government", Country = "UK", Year = 1949, Description = "sint occaecat cupidatat non proident" }
            };

            EarlyComputers2 = new[]
            {
                new Computer2 { Model = "Colossus Mark 1", Maker = "Government", Country = "UK", Year = 1944, Description = "incididunt ut labore et dolore magna aliqua" },
                new Computer2 { Model = "Harvard Mark I", Maker = "Government", Country = "US", Year = 1944, Description = "Duis aute irure dolor in reprehenderit" },
                new Computer2 { Model = "Colossus Mark 2", Maker = "Government", Country = "UK", Year = 1944, Description = "in voluptate velit esse cillum dolore eu fugiat nulla pariatur" },
                new Computer2 { Model = "ENIAC", Maker = "Government", Country = "US", Year = 1946, Description = "sunt in culpa qui officia deserunt" },
                new Computer2 { Model = "EDSAC", Maker = "Government", Country = "UK", Year = 1949, Description = "sint occaecat cupidatat non proident" }
            };

            EarlyComputers3 = new[]
            {
                new Computer3 { Model = "Colossus Mark 1", Maker = "Government", Country = "UK", Year = 1944, Description = "incididunt ut labore et dolore magna aliqua" },
                new Computer3 { Model = "Harvard Mark I", Maker = "Government", Country = "US", Year = 1944, Description = "Duis aute irure dolor in reprehenderit" },
                new Computer3 { Model = "Colossus Mark 2", Maker = "Government", Country = "UK", Year = 1944, Description = "in voluptate velit esse cillum dolore eu fugiat nulla pariatur" },
                new Computer3 { Model = "ENIAC", Maker = "Government", Country = "US", Year = 1946, Description = "sunt in culpa qui officia deserunt" },
                new Computer3 { Model = "EDSAC", Maker = "Government", Country = "UK", Year = 1949, Description = "sint occaecat cupidatat non proident" }
            };
        }

        public IEnumerable<Computer1> EarlyComputers1
        {
            get;
        }

        public IEnumerable<Computer2> EarlyComputers2
        {
            get;
        }

        public IEnumerable<Computer3> EarlyComputers3
        {
            get;
        }

        private bool _inSelectionMode = false;
        public bool InSelectionMode
        {
            get
            {
                return _inSelectionMode;
            }
            private set
            {
                if (_inSelectionMode != value)
                {
                    _inSelectionMode = value;
                    NotifyPropertyChanged(nameof(InSelectionMode));
                }
            }
        }

        private string _buyResult = String.Empty;
        public string BuyResult
        {
            get
            {
                return _buyResult;
            }
            private set
            {
                if (_buyResult != value)
                {
                    _buyResult = value;
                    NotifyPropertyChanged(nameof(BuyResult));
                }
            }
        }

        public void SelectButtonClicked()
        {
            BuyResult = String.Empty;
            InSelectionMode = true;
        }

        public void BuyButtonClicked()
        {
            var modelsBought = EarlyComputers3.Where(c => c.Include).Select(c => c.Model);
            var modelsBoughtCount = modelsBought.Count();
            var modelsBoughtString = String.Join("\r\n", modelsBought);

            foreach (var c in EarlyComputers3)
            {
                c.Include = false;
            }

            BuyResult = String.Format(CultureInfo.CurrentCulture, "Bought {0}\r\n{1}", modelsBoughtCount, modelsBoughtString);
            InSelectionMode = false;
        }

        public void CancelButtonClicked()
        {
            foreach (var c in EarlyComputers3)
            {
                c.Include = false;
            }

            BuyResult = String.Empty;
            InSelectionMode = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Computer1
    {
        public string Model;

        public string Maker;

        public string Country;

        public int Year;

        public string Description;
    }

    public class Computer2
    {
        public string Model { get; set; }

        public string Maker { get; set; }

        public string Country { get; set; }

        public int Year { get; set; }

        public string Description { get; set; }
    }

    public class Computer3 : Computer2, INotifyPropertyChanged
    {
        public bool Include { get; set; }

        public bool ShowMore { get; set; }

        public string LessMoreText => ShowMore ? "less" : "more";

        public void ToggleLessMore()
        {
            ShowMore = !ShowMore;
            NotifyPropertyChanged(nameof(ShowMore));
            NotifyPropertyChanged(nameof(LessMoreText));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
