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
    public class ChatViewModel : BaseViewModel
    {
        private string _text;
        private ObservableCollection<Message> _messages;
        private bool _isConnected;
        HubConnection hubConnection;

        public bool isPlaying;

        public ChatViewModel()
        {
            Messages = new ObservableCollection<Message>();

            SendMessageCommand = new Command(async () => { await SendMessage(Username, Text); });
            ConnectCommand = new Command(async () => await Connect());
            DisconnectCommand = new Command(async () => await Disconnect());

            ConnectBool = true;
            DisconnectBool = false;

            //Connects to our website
            IsConnected = false;
            hubConnection = new HubConnectionBuilder()
            .WithUrl("http://chatdemosignalr.azurewebsites.net/chatHub")
            .Build();

            Username = (Application.Current as App).tempUser;

            hubConnection.On<string>("JoinChat", (user) =>
            {
                Messages.Add(new Message() { Username = user, Text = $"{user} has joined the chat", IsSystemMessage = true, Date = DateTime.Now });
            });

            hubConnection.On<string>("LeaveChat", (user) =>
            {
                Messages.Add(new Message() { Username = user, Text = $"{user} has left the chat", IsSystemMessage = true, Date = DateTime.Now });
            });


            //When the user recieves a message, a sound is played
            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                if (!user.Equals(Username))
                {
                    Messages.Add(new Message() { Username = user, Text = message, IsSystemMessage = false, IsOwnMessage = Username == user, Date = DateTime.Now });

                    var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                    if (isPlaying == true)
                    {
                        player.Stop();
                        player.Load("notification.mp3");
                        player.Play();
                        isPlaying = false;
                    }
                    else if (isPlaying == false)
                    {
                        player.Load("notification.mp3");
                        player.Play();
                        isPlaying = true;
                    }
                }
            });

            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                if (user.Equals(Username))
                {
                    Messages.Add(new Message() { Username = user, Text = message, IsSystemMessage = false, IsOwnMessage = Username == user, Date = DateTime.Now });
                }
                
            });
          
        }

        #region --Bindings--

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



        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged(); }
        }



        public string Text
        {
            get { return _text; }
            set { _text = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Message> Messages
        {
            get { return _messages; }
            set { _messages = value; }
        }

        public bool IsConnected
        {
            get { return _isConnected; }
            set { _isConnected = value; }
        }

        #endregion

        public Command SendMessageCommand { get; }
        public Command ConnectCommand { get; }
        public Command DisconnectCommand { get; }

        /// <summary>
        /// This method connects the user to the group conversation
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Handles the method for sending a message to the group conversation
        /// A sound is also played before sending a message to make it sound more instant
        /// since the plugin sounds to be a bit slow
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>

        async Task SendMessage(string user, string message)
        {
            //plugin is slow so sound is delayed
            var sendAudio = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            if (isPlaying == true)
            {
                sendAudio.Stop();
                sendAudio.Load("notification_sound.mp3");
                sendAudio.Play();
                isPlaying = false;
            }
            else if (isPlaying == false)
            {
                sendAudio.Load("notification_sound.mp3");
                sendAudio.Play();
                isPlaying = true;
            }

            await hubConnection.InvokeAsync("SendMessage", user, message + " " + DateTime.Now.ToString("HH:mm"));
            Text = "";
            
        }

        /// <summary>
        /// Disconnects the user from the group conversation
        /// </summary>
        /// <returns></returns>

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
