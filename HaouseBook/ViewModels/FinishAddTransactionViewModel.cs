using Common.Command;
using Data;
using HaouseBook.Views;
using Microsoft.Practices.Prism.Events;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HaouseBook.ViewModels
{
    public class FinishAddTransactionViewModel : ViewModelBase
    {
        private string description;
        private string price;
        private DateTime dateTime;
        public FinishAddTransactionViewModel(IEventAggregator eventAggregator) : base(eventAggregator) { }
        public ICommand AddTransactionCommand { get; private set; }

        public FinishAddTransactionViewModel(IEventAggregator eventAggregator, Transaction transaction) : base(eventAggregator) 
        {
            AddTransactionCommand = new ActionCommand(this.AddTransactionCommandExecute, this.AddTransactionCommandCanExecute);
            this.Description = transaction.TransactionDescription;
            this.Price = transaction.SumPrice.ToString();
            this.DateTime = transaction.TransactionDate;
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                if(this.description != value)
                {
                    this.description = value;
                    this.OnPropertyChanged(nameof(this.Description));
                }
            }
        }
        public string Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if(this.price != value)
                {
                    this.price = value;
                    this.OnPropertyChanged(nameof(this.Price));
                }
            }
        }

        public DateTime DateTime
        {
            get
            {
                return this.dateTime;
            }
            set
            {
                if(this.dateTime != value)
                {
                    this.dateTime = value;
                    this.OnPropertyChanged(nameof(this.DateTime));
                }
            }
        }
        /// <summary>
        /// Determines wheter the Path selection command can be executed.
        /// </summary>
        /// <param name="parameter">Data used by the command.</param>
        /// <returns><c>true</c> if the command can be executed otherwise <c>false</c>.</returns>
        private bool AddTransactionCommandCanExecute(object parameter)
        {
            return true;
        }

        private void AddTransactionCommandExecute(object parameter)
        {
            Transaction transaction = new Transaction(Convert.ToDouble(this.Price), this.Description, this.DateTime);
            Setup.ReadInformation(out Config config);
            transaction.Save(config.Path);
        }
    }
}
