using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhoneContacts.DialPad
{
    /// <summary>
    /// Interaction logic for DialPadDigitButton.xaml
    /// </summary>
    public partial class DialPadDigitButton : UserControl
    {
        public char Digit
        {
            get { return (char)GetValue(DigitProperty); }
            set { SetValue(DigitProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Property1.  
        // This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DigitProperty
            = DependencyProperty.Register(
                  nameof(Digit),
                  typeof(char),
                  typeof(DialPadDigitButton),
                  new PropertyMetadata()
              );

        public ICommand ButtonPress
        {
            get { return (ICommand)GetValue(ButtonPressProperty); }
            set { SetValue(ButtonPressProperty, value); }
        }

        public static readonly DependencyProperty ButtonPressProperty
            = DependencyProperty.Register(
                  nameof(ButtonPress),
                  typeof(ICommand),
                  typeof(DialPadDigitButton),
                  new PropertyMetadata()
              );

        public DialPadDigitButton()
        {
            InitializeComponent();
        }
    }
}
