using MVVMExercises.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

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
                    UserName = "Martin"
                },
                new User()
                {
                    ID = 2,
                    UserName = "Nicklas"
                },
                new User()
                {
                    ID = 3,
                    UserName = "Preben"
                },
                new User()
                {
                    ID = 4,
                    UserName = "Pippi"
                }

            };

        }

        private ObservableCollection<User> users { get; set; }

        public ObservableCollection<User> Users
        {
            get { return users; }
            set { users = value; OnPropertyChanged(); }
        }

        public  void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

      


    }
}
