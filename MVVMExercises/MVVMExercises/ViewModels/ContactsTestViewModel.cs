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

    /// <summary>
    /// since unit testing wont work with the masterdetail pattern we have used
    /// we have created a test class instead which is identical to the other class
    /// unit testing now works 
    /// </summary>


    public class ContactsTestViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddContactCMD { get; private set; }

        public ContactsTestViewModel()
        {
            AddContactCMD = new Command(AddContact);
            Users = new ObservableCollection<User>();
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

        public void AddContact()
        {
            Users.Add(new User() { Username = GetUser });
            Console.WriteLine(GetUser);
            IsShownNewContact = true;
            IsShown = false;

            (AddContactCMD as Command).ChangeCanExecute();
        }

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
