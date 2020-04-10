using Microsoft.AspNetCore.SignalR.Client;
using MVVMExercises.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVMExercises.ViewModels
{
    class ChatViewModel : BaseViewModel
    {
        private string username;
        private string _text;
        private ObservableCollection<Message> _messages;
        private bool _isConnected;
        HubConnection hubConnection;

        public ChatViewModel()
        {
            Messages = new ObservableCollection<Message>();
            SendMessageCommand = new Command(async () => { await SendMessage(Username, Text); });
            ConnectCommand = new Command(async () => await Connect());
            DisconnectCommand = new Command(async () => await Disconnect());

            ConnectBool = true;
            DisconnectBool = false;

            IsConnected = false;

            hubConnection = new HubConnectionBuilder()
            .WithUrl($"http://chatdemosignalr.azurewebsites.net/chatHub")
            .Build();

            Username = "Mathias";

            hubConnection.On<string>("JoinChat", (user) =>
            {
                Messages.Add(new Message() { Username = Username, Text = $"{user} has joined the chat", IsSystemMessage = true, Date = DateTime.Now });
            });

            hubConnection.On<string>("LeaveChat", (user) =>
            {
                Messages.Add(new Message() { Username = Username, Text = $"{user} has left the chat", IsSystemMessage = true, Date = DateTime.Now });
            });

            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Messages.Add(new Message() { Username = Username, Text = message, IsSystemMessage = false, IsOwnMessage = Username == user, Date = DateTime.Now });
            });
          
        }

        private bool connectBool;

        public bool ConnectBool
        {
            get { return connectBool; }
            set { connectBool = value; OnPropertyChanged(); }
        }

        private bool disconnectBool;

        public bool DisconnectBool
        {
            get { return disconnectBool; }
            set { disconnectBool = value; OnPropertyChanged(); }
        }



        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }


        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Message> Messages
        {
            get
            {
                return _messages;
            }
            set
            {
                _messages = value;
            }
        }
        public bool IsConnected
        {
            get
            {
                return _isConnected;
            }
            set
            {
                _isConnected = value;
            }
        }

        public Command SendMessageCommand { get; }
        public Command ConnectCommand { get; }
        public Command DisconnectCommand { get; }




        async Task Connect()
        {
            try
            {
                await hubConnection.StartAsync();
                await hubConnection.InvokeAsync("JoinChat", Username);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            IsConnected = true;
            ConnectBool = false;
            DisconnectBool = true;
        }

        async Task SendMessage(string user, string message)
        {
            
            await hubConnection.InvokeAsync("SendMessage", user, message);
            Text = "";
        }

        async Task Disconnect()
        {
            await hubConnection.InvokeAsync("LeaveChat", Username);
            await hubConnection.StopAsync();

            IsConnected = false;
            DisconnectBool = false;
            ConnectBool = true;
        }
    }
}
