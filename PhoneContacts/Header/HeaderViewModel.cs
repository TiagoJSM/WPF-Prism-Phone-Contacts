using PhoneContacts.Common;
using PhoneContacts.DialPad;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneContacts.Header
{
    public enum Menu
    {
        Dial,
        Contacts,
        Add
    }

    public class HeaderViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        private Menu _selectedMenu;
        public Menu SelectedMenu
        {
            get { return _selectedMenu; }
            set { SetProperty(ref _selectedMenu, value); }
        }

        public DelegateCommand<string> NavigateCommand { get; set; }

        public HeaderViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(Navigate);
            regionManager.RegisterViewWithRegion(Regions.Content, typeof(DialPadView));
        }

        private void Navigate(string uri)
        {
            _regionManager.RequestNavigate(Regions.Content, uri);
        }
    }
}
