using Common.Command;
using Data;
using HaouseBook.Events;
using HaouseBook.Views;
using Microsoft.Practices.Prism.Events;
using Microsoft.Win32;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HaouseBook.ViewModels
{
    public class StartAddTransactionViewModel : ViewModelBase
    {
        public StartAddTransactionViewModel(IEventAggregator eventAggregator) : base(eventAggregator) 
        {
            this.SelectFileCommand = new ActionCommand(this.SelectFileCommandExecute, this.SelctFileCommandCanExecute);
            this.InputSideCommand = new ActionCommand(this.InputSideCommandExecute, this.InputSideCommandCanExecute);
        }

        public ICommand SelectFileCommand { get; private set; }
        public ICommand InputSideCommand { get; private set; }

        /// <summary>
        /// Determines wheter the File selection command can be executed.
        /// </summary>
        /// <param name="parameter">Data used by the command.</param>
        /// <returns><c>true</c> if the command can be executed otherwise <c>false</c>.</returns>
        private bool SelctFileCommandCanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Ocures when the user clicks the file selction button.
        /// </summary>
        /// <param name="parameter">Data use by the command.</param>
        private void SelectFileCommandExecute(object parameter)
        {
            Transaction transaction;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            if (openFileDialog.ShowDialog() == true)
            {
                transaction = PDFReader.ReadPDF(openFileDialog.FileName);
                FinishAddTransactionView finishAddTransactionView = new FinishAddTransactionView();
                FinishAddTransactionViewModel finishAddTransactionViewModel = new FinishAddTransactionViewModel(this.EventAggregator, transaction);
                finishAddTransactionView.DataContext = finishAddTransactionViewModel;
                this.EventAggregator.GetEvent<FinishAddTransactionViewChangeEvent>().Publish(finishAddTransactionView);
            }
        }
        /// <summary>
        /// Determines wheter the open input side command can be execute
        /// </summary>
        /// <param name="parameter">Data used by the command.</param>
        /// <returns><c>true</c> if the command can be executed otherwise <c>false</c></returns>
        public bool InputSideCommandCanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Ocures when the user click the open input side button.
        /// </summary>
        /// <param name="parameter">Data used by the command</param>
        private void InputSideCommandExecute(object parameter)
        {
            FinishAddTransactionView finishAddTransactionView = new FinishAddTransactionView();
            FinishAddTransactionViewModel finishAddTransactionViewModel = new FinishAddTransactionViewModel(this.EventAggregator);
            finishAddTransactionView.DataContext = finishAddTransactionViewModel;
            this.EventAggregator.GetEvent<FinishAddTransactionViewChangeEvent>().Publish(finishAddTransactionView);
        }
    }
}
