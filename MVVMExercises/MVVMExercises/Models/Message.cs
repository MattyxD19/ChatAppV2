using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MVVMExercises.Models
{
   public class Message : BindableObject
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; base.OnPropertyChanged(); }
        }
        public int ConversationId { get; set; }
        public int UserId { get; set; }

        private string username;
        public string Username
        { 
            get { return username; } 
            set { username = value; base.OnPropertyChanged(); }
        }

        private string text;
        public string Text 
        { 
            get { return text; } 
            set { text = value; base.OnPropertyChanged(); }
        }

        private bool isSystemMessage;

        public bool IsSystemMessage
        {
            get { return isSystemMessage; }
            set { isSystemMessage = value; base.OnPropertyChanged(); }
        }

        private bool isOwnMessage;

        public bool IsOwnMessage
        {
            get { return isOwnMessage; }
            set { isOwnMessage = value; base.OnPropertyChanged(); }
        }


        public DateTime Date { get; set; }

        private bool incoming;

        public bool Incoming
        {
            get { return incoming; }
            set { incoming = value; }
        }

    }
}
