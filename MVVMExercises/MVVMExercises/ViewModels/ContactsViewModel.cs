using MVVMExercises.Model;
using MVVMExercises.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MVVMExercises.ViewModels
{
    class ContactsViewModel : BaseViewModel
    {
        public ContactsViewModel()
        {
            contactsList.Add(new User() { ID = 0, UserName = "Mathias", Password = "test"});

        }
        ObservableCollection<User> contactsList = new ObservableCollection<User>();


    }
}
