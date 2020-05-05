using Microsoft.AspNetCore.SignalR;
using RemaCodeUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppChat.Hubs
{
    public class ChatHub : Hub
    {
        
        public void BroadcastMessage(string name, string message)
        {
            Clients.All.SendAsync("broadcastMessage", name, message);
            Console.WriteLine(Clients.All.SendAsync("broadcastMessage", name, message));
        }

        public async Task Echo(string name, string message)
        {
            await Clients.Client(Context.ConnectionId).SendAsync("echo", name, message + " (echo from server)");
            Console.WriteLine(Clients.Client(Context.ConnectionId).SendAsync("echo", name, message + " (echo from server)"));
        }

        public async Task JoinChat(string user)
        {
            await Clients.All.SendAsync("JoinChat", user);
            Console.WriteLine(Clients.All.SendAsync("JoinChat", user));
        }

        public async Task LeaveChat(string user)
        {
            await Clients.All.SendAsync("LeaveChat", user);
            Console.WriteLine(Clients.All.SendAsync("LeaveChat", user));
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task<string> CodeUnit(string customerID)
        {
            RemaCustomerCodeUnit_Port test = null;
            GetCustomerName_Result result = null;
            try
            {

                test = new RemaCustomerCodeUnit_PortClient();
                result = await test.GetCustomerNameAsync(new GetCustomerName(customerID));
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error: " + ex.Message);
            }



            Console.WriteLine(result.return_value);
            await Clients.All.SendAsync(result.return_value);
            return result.return_value;

            //await Clients.All.SendAsync("Message sent: " + test.ToString());

        }

    }
}
