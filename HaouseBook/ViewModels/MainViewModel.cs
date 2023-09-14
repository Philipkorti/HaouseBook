using Data;
using HaouseBook.Events;
using HaouseBook.Views;
using Microsoft.Practices.Prism.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HaouseBook.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region ------------------------- Fields, Constants, Delegates, Events --------------------------------------------
        private UserControl userControl;
        #endregion
        #region  ------------------------- Constructors, Destructors, Dispose, Clone ---------------------------------------
        public MainViewModel(IEventAggregator eventAggregator) : base(eventAggregator) 
        {
            this.EventAggregator.GetEvent<MainMenueViewChangeEvent>().Subscribe(this.OnMainMenueViewDataChanged, ThreadOption.UIThread);
            startProgramm();
        }
        #endregion
        #region ------------------------- Properties, Indexers ------------------------------------------------------------
        public UserControl UserControl 
        { 
            get { return this.userControl; }
            set
            {
                if(this.userControl != value)
                {
                    this.userControl = value;
                    this.OnPropertyChanged(nameof(this.UserControl));
                }
            }
        }
        #endregion
        #region ------------------------- Private helper ------------------------------------------------------------------
        private void startProgramm()
        {
            // Check whether the progremm is already set up
            if (!Directory.Exists(ConstData.FolderPath))
            {
                // Opens the setup page
                FirstFurnishingsView firstFurnishingsView= new FirstFurnishingsView();
                FirstFurnishingsViewModel firstFurnishingsViewModel= new FirstFurnishingsViewModel(this.EventAggregator);
                firstFurnishingsView.DataContext= firstFurnishingsViewModel;
                this.UserControl = firstFurnishingsView;
            }
            else
            {
                // Opens the main menue page
                MainMenueView mainMenueView = new MainMenueView();
                MainMenueViewModel mainMenueViewModel = new MainMenueViewModel(this.EventAggregator);
                mainMenueView.DataContext= mainMenueViewModel;
                this.UserControl = mainMenueView;
            }
            
        }
        private void OnMainMenueViewDataChanged(MainMenueView mainMenueView)
        {
            this.UserControl = mainMenueView;
        }
        #endregion
    }
}
