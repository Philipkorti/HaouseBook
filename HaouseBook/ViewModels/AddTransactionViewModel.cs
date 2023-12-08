using Common.Command;
using HaouseBook.Views;
using Microsoft.Practices.Prism.Events;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using HaouseBook.Events;

namespace HaouseBook.ViewModels
{
    public class AddTransactionViewModel : ViewModelBase
    {
        private UserControl userControl;
        public AddTransactionViewModel(IEventAggregator eventAggregator) : base(eventAggregator) 
        {
            this.EventAggregator.GetEvent<FinishAddTransactionViewChangeEvent>().Subscribe(this.OnFinidhAddTransactionViewDataChange, ThreadOption.UIThread);
            StartAddTransactionView startAddTransactionView = new StartAddTransactionView();
            StartAddTransactionViewModel startAddTransactionViewModel = new StartAddTransactionViewModel(this.EventAggregator);
            startAddTransactionView.DataContext = startAddTransactionViewModel;
            this.UserControl = startAddTransactionView;
        }

        public UserControl UserControl
        {
            get
            {
                return userControl;
            }
            set
            {
                if(this.userControl!= value)
                {
                    this.userControl = value;
                    this.OnPropertyChanged(nameof(this.UserControl));
                }
            }
        }

        private void OnFinidhAddTransactionViewDataChange(FinishAddTransactionView finishAddTransactionView)
        {
            this.UserControl = finishAddTransactionView;
        }

       
       
    }
}
