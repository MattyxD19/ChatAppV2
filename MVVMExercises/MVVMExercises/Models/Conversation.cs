using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MVVMExercises.Models
{
    public class Conversation
    {
        private int id;
        public int ID
        {
            get{return id;}
            set{id = value;}
        }
        public int UserId { get; set; }


        private string username;
        public string UserName
        {
            get{return username;}
            set{username = value;}
        }

        public string LastMessage { get; set; }

        public string MyId { get; set; }
    }
}
