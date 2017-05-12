using PhoneContacts.Common;
using PhoneContacts.Common.Data;
using PhoneContacts.Common.Events;
using PhoneContacts.ContactList.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneContacts.ContactList
{
    public class ContactListViewModel : BindableBase, INavigationAware
    {
        private IEventAggregator _eventAggregator;
        private IInMemoryRepository<Contact> _contactsRepo;

        private ObservableCollection<Contact> _contacts;
        public ObservableCollection<Contact> Contacts
        {
            get { return _contacts; }
            set { SetProperty(ref _contacts, value); }
        }

        public DelegateCommand<Contact> Call { get; private set; }

        public ContactListViewModel(IEventAggregator eventAggregator, IInMemoryRepository<Contact> contactsRepo)
        {
            _eventAggregator = eventAggregator;
            _contactsRepo = contactsRepo;
            Contacts = new ObservableCollection<Contact>(_contactsRepo.Get());

            Call = new DelegateCommand<Contact>(DoCall);
        }

        private void DoCall(Contact contact)
        {
            Debug.WriteLine("do call");
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Contacts = new ObservableCollection<Contact>(_contactsRepo.Get());
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
