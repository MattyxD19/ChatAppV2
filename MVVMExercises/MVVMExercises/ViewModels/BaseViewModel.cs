﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using MVVMExercises.Models;
using MVVMExercises.Services;

namespace MVVMExercises.ViewModels
{
    public abstract class BaseViewModel : ExtendedBindableObject, IWebService
    {
        protected readonly INavigationService NavigationService;

        internal static string UserName = "";

        public BaseViewModel()
        {
            NavigationService = ViewModelLocator.Resolve<INavigationService>();
            var settingsService = ViewModelLocator.Resolve<ISettingsService>();

        }
        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }

        public int SleepDuration { get; set; }

        public int MyUserID { get; set; } = 1;


       
        private Task Sleep()
        {
            return Task.Delay(SleepDuration);
        }
        public async Task<User> Login(string username, string password)
        {
            await Sleep();
            return new User { ID = MyUserID, Username = username };
        }

        public async Task<User> Register(User user)
        {
            await Sleep();
            return user;
        }
        public async Task<User[]> GetFriends(int userId)
        {
            await Sleep();

            return new[]
            {
                new User { ID = 2, Username = "Obama" }
               
            };
        }
        public async Task<User> AddFriend(
        int userId, string username)
        {
            await Sleep();
            return new User { ID = 5, Username = username };
        }

        public async Task<Conversation[]> GetConversations(int userId)
        {
            await Sleep();
            return new[]
            {
                new Conversation { ID = 1, UserId = 2, Username = "Obama", LastMessage = "Hi", },
                new Conversation { ID = 2, UserId = 3, Username = "Bush", LastMessage = "Pretty well, still coding C#", },
                new Conversation { ID = 3, UserId = 4, Username = "Clinton", LastMessage = "It's great!",  },
            };
        }

        //public async Task<Message[]> GetMessages(int conversationId)
        public async Task<ObservableCollection<Message>> GetMessages(int conversationId)
        {
            await Sleep();
            List<Message> messageList = new List<Message>();
            messageList.AddRange(
            new[]
            {
                new Message
                {
                    ID = 1,
                    ConversationId = conversationId,
                    UserId = 2,
                    Text = "Hi",
                    Date = DateTime.Now.AddMinutes(-15),
                    Incoming = true,
                },
                new Message
                {
                    ID = 2,
                    ConversationId = conversationId,
                    UserId = MyUserID,
                    Text = "Hi, how are you doing",
                    Date = DateTime.Now.AddMinutes(-10),
                    Incoming = false,
                },
                new Message
                {
                    ID = 3,
                    ConversationId = conversationId,
                    UserId = 2,
                    Text = "Pretty well, still coding C#",
                    Date = DateTime.Now.AddMinutes(-5),
                    Incoming = true,
                },
                new Message
                {
                    ID = 4,
                    ConversationId = conversationId,
                    UserId = MyUserID,
                    Text = "Same same, its great I like C#",
                    Date = DateTime.Now,
                    Incoming = false,
                },
            }
            );
            return new ObservableCollection<Message>(messageList);
        }

        public async Task<Message> SendMessage(Message message)
        {
            await Sleep();
            return message;
        }
    }
}
