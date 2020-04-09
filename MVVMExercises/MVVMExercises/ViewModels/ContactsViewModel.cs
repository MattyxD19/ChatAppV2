using MVVMExercises.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace MVVMExercises.ViewModels
{
    class ContactsViewModel : BaseViewModel, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;



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
            isShownNewContact = true;
        }

        private ObservableCollection<User> users { get; set; }

        public ObservableCollection<User> Users
        {
            get { return users; }
            set { users = value; OnPropertyChanged(); }
        }

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged(); }
        }

        private bool isShown;

        public bool IsShown
        {
            get { return isShown; }
            set { isShown = value; OnPropertyChanged(); }
        }

        private bool isShownNewContact;

        public bool IsShownNewContact
        {
            get { return isShownNewContact; }
            set { isShownNewContact = value; OnPropertyChanged(); }
        }

        private string getUser;

        public string GetUser 
        {
            get { return getUser; }
            set { getUser = value; OnPropertyChanged(); }
        }

        public Command CreateContactCMD => new Command(async () =>
        {
            
            Users.Add( new User() { UserName = GetUser });
            Console.WriteLine(GetUser);
            IsShownNewContact = true;
            IsShown = false;
        });

        public Command ShowNewContactsCMD => new Command(async () =>
        {
            IsShown = true;
            IsShownNewContact = false;
            Console.WriteLine("add contact tapped!");
            Console.WriteLine(IsShown);
            
        });


        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
