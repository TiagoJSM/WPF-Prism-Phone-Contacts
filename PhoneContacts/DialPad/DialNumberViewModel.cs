using PhoneContacts.Common.Events;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneContacts.DialPad
{
    public class DialNumberViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;

        private string _dialnumber;
        public string DialNumber
        {
            get { return _dialnumber; }
            set {
                SetProperty(ref _dialnumber, value);
                _eventAggregator.GetEvent<DialNumberChangeEvent>().Publish(DialNumber);
            }
        }

        public DialNumberViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<DialPadButtonPressEvent>().Subscribe(OnDialPadButtonPressed);
        }

        private void OnDialPadButtonPressed(char dialCharacter)
        {
            DialNumber += dialCharacter;
        }
    }
}
