using Microsoft.Practices.Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;
using Common.Command;
using Services;
using Data;
using System.Runtime.CompilerServices;
using System.Windows;
using HaouseBook.Events;

namespace HaouseBook.ViewModels
{
    public class FirstFurnishingsViewModel : ViewModelBase
    {
        #region ------------------------- Fields, Constants, Delegates, Events --------------------------------------------
        private Config config;
        private Visibility visibilityForthmonthsalaryDate;
        private Visibility visibilityMonthsalaryDate;
        private List<string> countrys;
        private List<string> curentcys;
        #endregion
        #region ------------------------- Constructors, Destructors, Dispose, Clone ---------------------------------------
        public FirstFurnishingsViewModel(IEventAggregator eventAggregator) : base(eventAggregator) 
        {
            this.PathSelectionCommand = new ActionCommand(this.PathSelectionCommandExecuted, this.PathSelevtionCommandCanExecute);
            this.SaveFurnishingsCommand = new ActionCommand(this.SaveFurnishingsCommandExecute, this.SaveFurnishingsCommandCanExecute);
            this.config = new Config();
            this.Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            this.VisibilityForthmonthsalaryDate = Visibility.Collapsed;
            this.VisibilityMonthsalaryDate= Visibility.Collapsed;
            this.Countrys = new List<string>
            {
                "Austria",
                "Germany",
                "United State of America"
            };
            this.Curentcys = new List<string>
            {
                "Euro",
                "USDoller"
            };
            this.config.MonthsalaryDate = DateTime.Now;
            this.config.ForthmonthsalaryDate= DateTime.Now;

        }
        
        #endregion
        #region ------------------------- Properties, Indexers ------------------------------------------------------------
        public ICommand PathSelectionCommand { get; private set; }
        public ICommand SaveFurnishingsCommand { get; private set; }
        public List<string> Countrys
        {
            get { return this.countrys; }
            set
            {
                this.countrys = value;
                this.OnPropertyChanged(nameof(this.Countrys));
            }
        }
        public List<string> Curentcys
        {
            get { return this.curentcys; }
            set
            {
                this.curentcys = value;
                this.OnPropertyChanged(nameof(this.Curentcys));
            }
        }
        public string Path
        {
            get { return this.config.Path; }
            set
            {
                if (this.config.Path != value) 
                {
                    this.config.Path = value;
                    this.OnPropertyChanged(nameof(this.Path));
                }
            }
        }

        public string Country
        {
            get { return this.config.Country; }
            set 
            { 
                if(this.config.Country != value) 
                { 
                    this.config.Country = value;
                } 
                this.OnPropertyChanged(nameof(this.Country)); 
            }
        }

        public string Curentcy
        {
            get { return this.config.Curentcy; }
            set 
            { 
                if(this.config.Curentcy != value)
                {
                    this.config.Curentcy = value; 
                    this.OnPropertyChanged(nameof(this.Curentcy)); 
                }
            }
        }

        public string Income
        {
            get { return this.config.Income;}
            set
            {
                if(this.config.Income != value)
                {
                    this.config.Income = value;
                    this.OnPropertyChanged(nameof(this.Income));
                }
            }
        }

        public bool Forthmonthsalary
        {
            get { return this.config.Forthmonthsalary; }
            set
            {
                if(this.config.Forthmonthsalary != value)
                {
                    this.config.Forthmonthsalary = value;
                    if (this.Forthmonthsalary == true)
                    {
                        this.VisibilityForthmonthsalaryDate = Visibility.Visible;
                    }
                    else
                    {
                        this.VisibilityForthmonthsalaryDate = Visibility.Collapsed;
                    }
                    this.OnPropertyChanged(nameof(this.Forthmonthsalary));
                }
            }
        }
        public bool Monthsalary
        {
            get { return this.config.Monthsalary;}
            set 
            {
                if(this.config.Monthsalary != value)
                {
                    this.config.Monthsalary = value;
                    if(this.Monthsalary == true)
                    {
                        this.VisibilityMonthsalaryDate = Visibility.Visible;
                    }
                    else
                    {
                        this.VisibilityMonthsalaryDate= Visibility.Collapsed;
                    }
                    this.OnPropertyChanged(nameof(this.Monthsalary));
                }
            }
        }
        public DateTime ForthmonthsalaryDate
        {
            get { return this.config.ForthmonthsalaryDate; }
            set
            {
                if(this.config.ForthmonthsalaryDate != value)
                {
                    this.config.ForthmonthsalaryDate = value;
                    this.OnPropertyChanged(nameof(this.ForthmonthsalaryDate));
                }
            }
        }
        public DateTime MonthsalaryDate
        {
            get { return this.config.MonthsalaryDate; }
            set
            {
                if (this.config.MonthsalaryDate != value)
                {
                    this.config.MonthsalaryDate= value;
                    this.OnPropertyChanged(nameof(this.MonthsalaryDate));
                }
            }
        }

        public Visibility VisibilityForthmonthsalaryDate
        {
            get { return this.visibilityForthmonthsalaryDate; }
            set
            {
                if(this.visibilityForthmonthsalaryDate != value)
                {
                    this.visibilityForthmonthsalaryDate = value;
                    this.OnPropertyChanged(nameof(this.VisibilityForthmonthsalaryDate));
                }
            }
        }
        public Visibility VisibilityMonthsalaryDate
        {
            get { return this.visibilityMonthsalaryDate;}
            set
            {
                if(this.visibilityMonthsalaryDate!= value)
                {
                    this.visibilityMonthsalaryDate = value;
                    this.OnPropertyChanged(nameof(this.VisibilityMonthsalaryDate));
                }
            }
        }

        #endregion
        #region  ------------------------- Commands ------------------------------------------------------------------------
        /// <summary>
        /// Determines wheter the Path selection command can be executed.
        /// </summary>
        /// <param name="parameter">Data used by the command.</param>
        /// <returns><c>true</c> if the command can be executed otherwise <c>false</c>.</returns>
        private bool PathSelevtionCommandCanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Ocures when the user clicks the path selection button.
        /// </summary>
        /// <param name="parameter">Data use by the command.</param>
        private void PathSelectionCommandExecuted(object parameter)
        {
            // Create an INstance of  FolderBrowserDialog
            FolderBrowserDialog openFileFialog = new FolderBrowserDialog();
            // Open the File Dialog
            openFileFialog.ShowDialog();
            this.Path = openFileFialog.SelectedPath;
        }

        /// <summary>
        /// Determines wheter the Save furnishings command can be execute.
        /// </summary>
        /// <param name="parameter">Data used by the command.</param>
        /// <returns><c>true</c> if the command can be exevuted otherwise <c>false</c>.</returns>
        private bool SaveFurnishingsCommandCanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Ocures when the user clicks the save furnishings button.
        /// </summary>
        /// <param name="parameter">Data use by the command.</param>
        private void SaveFurnishingsCommandExecute(object parameter)
        {
            
            if (this.Path != Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
            {
                Setup.SetUp("");
                Setup.SetUp(this.Path);
            }
            else
            {
                Setup.SetUp(this.Path);
            }
            Setup.SaveInformation(config);
            MainMenueView mainMenueView = new MainMenueView();
            MainMenueViewModel mainMenueViewModel = new MainMenueViewModel(this.EventAggregator);
            mainMenueView.DataContext = mainMenueViewModel;
            this.EventAggregator.GetEvent<MainMenueViewChangeEvent>().Publish(mainMenueView);
        }
        #endregion
    }
}
