using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactModel = UseOfMVVM.Models.Contact;


// this is for the logical like seding data to model and handle date from View.
namespace UseOfMVVM.ViewModels
{
    public partial class ContactsViewModel: ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<ContactModel> contacts = new();

        [ObservableProperty]
        private ContactModel contact=new();

        [RelayCommand]
        private void Save()
        {
            if (string.IsNullOrWhiteSpace(Contact?.Name)||
                string.IsNullOrWhiteSpace(Contact?.Email))
            {
                return;
            }

            Contacts.Add(Contact);

            Contact = new ContactModel();
        }
    }
}
