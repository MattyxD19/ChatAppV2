using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MVVMExercises.ViewModels
{
    class ChatViewModel : BaseViewModel
    {
        private HubConnection hubConnection;
        private string _name;
        private string _message;
        private ObservableCollection<MessageModel> _messages;
        private bool _isConnected;
        async Task Connect()
        {
            await hubConnection.StartAsync();
            await hubConnection.InvokeAsync("JoinChat", Name);

            IsConnected = true;
        }
    }
}
