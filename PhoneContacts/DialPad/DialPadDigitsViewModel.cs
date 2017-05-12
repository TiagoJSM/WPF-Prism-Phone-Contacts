using PhoneContacts.Common.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneContacts.DialPad
{
    public class DialPadDigitsViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;

        public DelegateCommand<char?> CharacterButtonPress { get; private set; }

        public DialPadDigitsViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            CharacterButtonPress = new DelegateCommand<char?>(OnButtonPressHandler);
        }

        private void OnButtonPressHandler(char? character)
        {
            if(character != null)
            {
                _eventAggregator.GetEvent<DialPadButtonPressEvent>().Publish(character.Value);
            }
        }
    }
}
