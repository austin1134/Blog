using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Messaging;

namespace Blog
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            //Call the broadcastMessage method to updagte clients.
            Clients.All.broadcastMessage(name, message);
        }
    }
}