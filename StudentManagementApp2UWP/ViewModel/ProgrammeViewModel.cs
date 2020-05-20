using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using StudentManagementApp2UWP.Common;
using StudentManagementApp2UWP.Model;
using StudentManagementApp2WebAPI;

namespace StudentManagementApp2UWP.ViewModel
{
    class ProgrammeViewModel : INotifyPropertyChanged
    {
        private ProgrammeCatalogSingleton programmeCatalog;

        private ObservableCollection<Programme> _programmes;

        private string _searchText;
        private string _searchYearOfBeginning;
        private string _searchMonthOfBeginning;
        private string _searchYearOfEnd;
        private string _searchMonthOfEnd;

        private Programme _selectedProgramme;

        public ProgrammeViewModel()
        {
            programmeCatalog = ProgrammeCatalogSingleton.Instance;

            Programmes = programmeCatalog.Programmes;
        }

        public ObservableCollection<Programme> Programmes
        {
            get { return _programmes; }
            set
            {
                _programmes = value;
                OnPropertyChanged();
            }

        }

        public string SearchText
        {
            get
            {
                if (_searchText == null)
                {
                    return String.Empty;
                }
                return _searchText;
            }
            set
            {
                _searchText = value;
                OnPropertyChanged();
                UpdateListOnSearch();
            }
        }
        public string SearchYearOfBeginning
        {
            get
            {
                if (_searchYearOfBeginning == null)
                {
                    return String.Empty;
                }
                return _searchYearOfBeginning;
            }
            set
            {
                _searchYearOfBeginning = value;
                OnPropertyChanged();
                UpdateListOnSearch();
            }
        }
        public string SearchMonthOfBeginning
        {
            get
            {
                if (_searchMonthOfBeginning == null)
                {
                    return String.Empty;
                }
                return _searchMonthOfBeginning;
            }
            set
            {
                _searchMonthOfBeginning = value;
                OnPropertyChanged();
                UpdateListOnSearch();
            }
        }
        public string SearchYearOfEnd
        {
            get
            {
                if (_searchYearOfEnd == null)
                {
                    return String.Empty;
                }
                return _searchYearOfEnd;
            }
            set
            {
                _searchYearOfEnd = value;
                OnPropertyChanged();
                UpdateListOnSearch();
            }
        }
        public string SearchMonthOfEnd
        {
            get
            {
                if (_searchMonthOfEnd == null)
                {
                    return String.Empty;
                }
                return _searchMonthOfEnd;
            }
            set
            {
                _searchMonthOfEnd = value;
                OnPropertyChanged();
                UpdateListOnSearch();
            }
        }

        public Programme SelectedProgramme
        {
            get { return _selectedProgramme; }
            set
            {
                _selectedProgramme = value;
                StaticObjects.StaticSelectedProgramme = value;
                OnPropertyChanged();
            }

        }

        public string[] BeginningMonthArray { get; } =
        {
            "Any",
            "February",
            "September"
        };
        public string[] EndMonthArray { get; } =
        {
            "Any",
            "January",
            "June"
        };

        public void UpdateListOnSearch()
        {
            var tempProgrammes = new ObservableCollection<Programme>();

            foreach (var programme in programmeCatalog.Programmes)
            {
                if (SearchText != String.Empty)
                {
                    if (!programme.Name.ToLower().Trim().Contains(SearchText.ToLower().Trim()))
                    {
                        continue;
                    }
                }

                if (SearchYearOfBeginning != String.Empty)
                {
                    if (!programme.Year_Of_Beginning.Year.ToString().Contains(SearchYearOfBeginning.Trim()))
                    {
                        continue;
                    }
                }

                if (SearchMonthOfBeginning != String.Empty && SearchMonthOfBeginning != "Any")
                {
                    if (programme.Year_Of_Beginning.ToString("MMMM") != SearchMonthOfBeginning)
                    {
                        continue;
                    }
                }

                if (SearchYearOfEnd != String.Empty)
                {
                    if (!programme.Year_Of_End.Year.ToString().Contains(SearchYearOfEnd.Trim()))
                    {
                        continue;
                    }
                }

                if (SearchMonthOfEnd != String.Empty && SearchMonthOfEnd != "Any")
                {
                    if (programme.Year_Of_End.ToString("MMMM") != SearchMonthOfEnd)
                    {
                        continue;
                    }
                }

                tempProgrammes.Add(programme);
            }

            Programmes = tempProgrammes;

            if (SearchText == String.Empty && SearchYearOfBeginning == String.Empty
                                           && SearchYearOfEnd == String.Empty
                                           && (SearchMonthOfBeginning == String.Empty || SearchMonthOfBeginning == "Any")
                                           && (SearchMonthOfEnd == String.Empty || SearchMonthOfEnd == "Any"))
            {
                Programmes = programmeCatalog.Programmes;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
