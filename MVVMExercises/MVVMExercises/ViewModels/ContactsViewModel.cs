using MVVMExercises.Models;
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

        //public Command AddNewUserCMD = new Command(async () => await AddContact());

        public ICommand AddContactCMD { get; private set; }

        //public Command AddNewUserCMD { get; } => new Command(AddContact);


        public ContactsViewModel()
        {
            AddContactCMD = new Command(AddContact);
            Users = new ObservableCollection<string>();
            isShownNewContact = true;
        }

        private ObservableCollection<string> users { get; set; }

        public ObservableCollection<string> Users
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
            set { getUser = value; this.OnPropertyChanged(); }
        }

        public void AddContact()
        {
            Users.Add(GetUser);
            Console.WriteLine(GetUser);
            IsShownNewContact = true;
            IsShown = false;

            (AddContactCMD as Command).ChangeCanExecute();
        }

        //public Command CreateContactCMD => new Command(async () =>
        //{
           
        //});

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
