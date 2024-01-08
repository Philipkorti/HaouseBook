using Microsoft.Practices.Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaouseBook.ViewModels
{
    public class OverViewViewModel : ViewModelBase
    {
        public OverViewViewModel(IEventAggregator eventAggregator) : base(eventAggregator) 
        {
        }
    }
}
