using PhoneContacts.Common;
using PhoneContacts.Common.Data;
using PhoneContacts.Common.Events;
using PhoneContacts.ContactList.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneContacts.ContactManagement
{
    public class ContactManagementViewModel : BindableBase
    {
        private IEventAggregator _eventAggregator;
        private IInMemoryRepository<Contact> _contactsRepo;

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { SetProperty(ref _phoneNumber, value); }
        }

        public DelegateCommand SaveNew { get; private set; }

        public ContactManagementViewModel(IEventAggregator eventAggregator, IInMemoryRepository<Contact> contactsRepo)
        {
            _eventAggregator = eventAggregator;
            _contactsRepo = contactsRepo;

            SaveNew = 
                new DelegateCommand(SaveNewHandler, CanSave)
                    .ObservesProperty(() => FirstName)
                    .ObservesProperty(() => LastName)
                    .ObservesProperty(() => PhoneNumber);
        }

        private void SaveNewHandler()
        {
            _contactsRepo.Add(
                new Contact()
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Photo = ImagesHelper.DefaultPhoto,
                    PhoneNumber = PhoneNumber
                });

            FirstName = string.Empty;
            LastName = string.Empty;
            PhoneNumber = string.Empty;
        }

        private bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName) && !string.IsNullOrWhiteSpace(PhoneNumber);
        }
    }
}
