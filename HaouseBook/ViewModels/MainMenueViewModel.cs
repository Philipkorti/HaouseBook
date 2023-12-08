using Common.Command;
using HaouseBook.Views;
using Microsoft.Practices.Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HaouseBook.ViewModels
{
    public class MainMenueViewModel : ViewModelBase
    {
        #region ------------------------- Properties, Indexers ------------------------------------------------------------
        public ICommand AddTransactionCommand { get; private set; }
        #endregion

        #region ------------------------- Constructors, Destructors, Dispose, Clone ---------------------------------------
        public MainMenueViewModel(IEventAggregator eventAggregator) : base(eventAggregator) 
        {
            this.AddTransactionCommand = new ActionCommand(this.AddTransactionCommandExecute, this.AddTransactionCommandCanExecute);
        }
        #endregion

        #region ------------------------- Commands ------------------------------------------------------------------------
        /// <summary>
        /// Determines wheter the add transaction command can be executed.
        /// </summary>
        /// <param name="parameter">Data used by the command.</param>
        /// <returns><c>true</c> if the command can be executed otherwise <c>false</c>.</returns>
        private bool AddTransactionCommandCanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Ocures when the user clicks the add transaction button.
        /// </summary>
        /// <param name="parameter">Data use by the command.</param>
        private void AddTransactionCommandExecute(object parameter)
        {
            AddTransaction addTransaction = new AddTransaction();
            AddTransactionViewModel addTransactionViewModel = new AddTransactionViewModel(this.EventAggregator);
            addTransaction.DataContext = addTransactionViewModel;
            addTransaction.ShowDialog();
        }
        #endregion

    }
}
