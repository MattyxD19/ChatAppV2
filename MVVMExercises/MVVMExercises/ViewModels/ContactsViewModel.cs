using MVVMExercises.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MVVMExercises.ViewModels
{
    class ContactsViewModel : BaseViewModel, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string UserName { get; set; }

        public ContactsViewModel()
        {
            Users = new ObservableCollection<User>(){
                new User()
                {
                    ID = 0,
                    UserName = "Mathias"
                },
                new User()
                {
                    ID = 1,
                    UserName = "test1"
                },
                new User()
                {
                    ID = 2,
                    UserName = "test2"
                },
                new User()
                {
                    ID = 3,
                    UserName = "test3"
                },
                new User()
                {
                    ID = 4,
                    UserName = "test4"
                }

            };

        }

        private ObservableCollection<User> users { get; set; }

        public ObservableCollection<User> Users
        {
            get { return users; }
            set { users = value; OnPropertyChanged(); }
        }

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
