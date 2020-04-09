using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using MVVMExercises.Models;

namespace MVVMExercises.Services
{
    
        public interface IWebService
        {
            Task<Models.User> Login(string username, string password);
            Task<Models.User> Register(Models.User user);
            Task<Models.User[]> GetFriends(int userId);
            Task<Models.User> AddFriend(int userId, string username);
            Task<Models.Conversation[]> GetConversations(int userId);
            //Task<Model.Message[]> GetMessages(int conversationId);
            Task<ObservableCollection<Models.Message>> GetMessages(int conversationId);
            Task<Models.Message> SendMessage(Models.Message message);
        }
    
}
