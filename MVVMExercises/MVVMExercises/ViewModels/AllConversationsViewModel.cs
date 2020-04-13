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
    public class AllConversationsViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public AllConversationsViewModel()
        {
            conversations = new ObservableCollection<Conversation>(){
                new Conversation() { Username = "Mathias", LastMessage = "Sounds nice!" }
            };
        }

        #region --Bindings--

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged(); }
        }

        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }

        private string lastMessage;

        public string LastMessage
        {
            get { return lastMessage; }
            set { lastMessage = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Conversation> conversations { get; set; }

        public ObservableCollection<Conversation> Conversations
        {
            get { return conversations; }
            set { conversations = value; OnPropertyChanged(); }
        }
        #endregion

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
