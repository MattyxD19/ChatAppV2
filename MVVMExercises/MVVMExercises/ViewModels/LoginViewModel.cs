using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using MVVMExercises.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVMExercises.ViewModels
{
   public class LoginViewModel : BaseViewModel
    {


        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged(); }
        }

        

        bool isBusy = false;
        public ICommand LoginCmd => new Command(async () => {

            await App.Current.MainPage.DisplayAlert("Notification", "Logged in as: " + Username, "Okay");
            await NavigationService.NavigateToAsync<ChatViewModel>(Username);

            //Outcommented for future use

            /*
            if (User.Username == "a" && User.Password == "b")
            {
              await  App.Current.MainPage.DisplayAlert("Notification", "Successfully Login", "Okay");
                // Open next page
                await NavigationService.NavigateToAsync<ContactsViewModel>();
            }
            else
            {
               await App.Current.MainPage.DisplayAlert("Notification", "Error Login", "Okay");
            }*/


        });

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
