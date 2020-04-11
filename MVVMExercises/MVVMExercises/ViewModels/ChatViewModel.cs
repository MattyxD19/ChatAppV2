﻿using Microsoft.AspNetCore.SignalR.Client;
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
        private string _Username;
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

            
            

            IsConnected = false;

            hubConnection = new HubConnectionBuilder()
            .WithUrl("http://chatdemosignalr.azurewebsites.net/chatHub")
            .Build();

            Username = (Application.Current as App).currenUser;


            hubConnection.On<string>("JoinChat", (user) =>
            {
                Messages.Add(new Message() { Username = user, Text = $"{user} has joined the chat", IsSystemMessage = true });
            });

            hubConnection.On<string>("LeaveChat", (user) =>
            {
                Messages.Add(new Message() { Username = user, Text = $"{user} has left the chat", IsSystemMessage = true });
            });

            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Messages.Add(new Message() { Username = user, Text = message, IsSystemMessage = false, IsOwnMessage = Username == user });
            });
          
        }

        public string Username
        {
            get
            {
                return _Username;
            }
            set
            {
                _Username = value;
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
                Console.WriteLine("Not connected :(");
                Console.WriteLine(e.Message);
            }
            
           

            IsConnected = true;
            Console.WriteLine("Connected!!");
        }

        async Task SendMessage(string user, string message)
        {
            
            Console.WriteLine("Send Btn pressed!!");
            await hubConnection.InvokeAsync("SendMessage", user, message);
        }

        async Task Disconnect()
        {
            await hubConnection.InvokeAsync("LeaveChat", Username);
            await hubConnection.StopAsync();

            IsConnected = false;
        }
    }
}
