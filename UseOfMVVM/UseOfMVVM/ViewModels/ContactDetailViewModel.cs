using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using ContactModel = UseOfMVVM.Models.Contact;

namespace UseOfMVVM.ViewModels
{
    public partial class ContactDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private ContactModel contact =new();
    }
}
