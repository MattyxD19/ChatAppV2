using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using MVVMExercises.Models;

namespace MVVMExercises.Services
{
    interface IWebService
    {
        Task<User> Login(string username, string password);
        Task<User> Register(User user);
        Task<User[]> GetFriends(int userId);
        Task<User> AddFriend(int userId, string username);
        Task<Conversation[]> GetConversations(int userId);
        //Task<Model.Message[]> GetMessages(int conversationId);
        Task<ObservableCollection<Message>> GetMessages(int conversationId);
        Task<Message> SendMessage(Message message);
    }
}
