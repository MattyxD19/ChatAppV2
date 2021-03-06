﻿using MVVMExercises.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVMExercises.ViewModels
{
    public class ContactsViewModel : BaseViewModel, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public ContactsViewModel()
        {
            //Just to show some data
            Users = new ObservableCollection<User>() { 
                new User(){ Username = "Mathias"},
                new User(){ Username = "Martin"},
                new User(){Username = "Nicklas"}
            };
            isShownNewContact = true;
        }

        #region --Bindings--

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

        #endregion

        /// <summary>
        /// When the user presses "Add new contact" 
        /// the button will be replaced with a new button and an entry
        /// The user can then proceed to enter a username
        /// </summary>
        public Command ShowNewContactsCMD => new Command(async () =>
        {
            IsShown = true;
            IsShownNewContact = false;
        });

        /// <summary>
        /// When the user presses "Confirm" on the contactsView
        /// A new user is added to the list of contacts
        /// </summary>
        public Command AddNewContactCMD => new Command(async () =>
        {
            Users.Add(new User() { Username = GetUser });
            Console.WriteLine(GetUser);
            IsShownNewContact = true;
            IsShown = false;

        });


        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
