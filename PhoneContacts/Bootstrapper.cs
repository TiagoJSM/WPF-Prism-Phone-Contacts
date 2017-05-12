using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using PhoneContacts.DialPad;
using PhoneContacts.Common;
using PhoneContacts.ContactList;
using PhoneContacts.ContactManagement;
using PhoneContacts.Common.Data;
using PhoneContacts.ContactList.Models;

namespace PhoneContacts
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow.MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterTypeForNavigation<DialPadView>(Views.Dial);
            Container.RegisterTypeForNavigation<ContactListView>(Views.Contacts);
            Container.RegisterTypeForNavigation<ContactManagementView>(Views.Add);

            var contacts = new InMemoryRepository<Contact>();
            contacts.Add(
                new Contact()
                {
                    Photo = ImagesHelper.DefaultPhoto,
                    FirstName = "The",
                    LastName = "Dude"
                });
            contacts.Add(
                new Contact()
                {
                    Photo = ImagesHelper.DefaultPhoto,
                    FirstName = "Another",
                    LastName = "Guy"
                });
            Container.RegisterInstance<IInMemoryRepository<Contact>>(contacts);
        }
    }
}
