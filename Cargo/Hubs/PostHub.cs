using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Cargo.Models;

namespace Cargo.Hubs
{
    public class PostHub : Hub
    {
        public void addMessage(object Comments)
        {
            Clients.All.postMessage(Comments);
        }
    }
}