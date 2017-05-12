using PhoneContacts.Common.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneContacts.DialPad
{
    public class DialControlsViewModel : BindableBase
    {
        private string _number;
        private IEventAggregator _eventAggregator;

        public DelegateCommand Dial { get; private set; }

        public DialControlsViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            Dial = new DelegateCommand(DialNumber, ValidateDial);
            _eventAggregator.GetEvent<DialNumberChangeEvent>().Subscribe(OnDialNumberChanged);
        }

        private void OnDialNumberChanged(string number)
        {
            _number = number;
            Dial.RaiseCanExecuteChanged();
        }

        private void DialNumber()
        {
            Debug.WriteLine("DialNumber");
        }

        private bool ValidateDial()
        {
            return !string.IsNullOrWhiteSpace(_number);
        }
    }
}
