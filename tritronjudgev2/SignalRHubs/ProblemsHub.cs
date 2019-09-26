using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace tritronAPI.SignalRHubs
{
    public class ProblemsHub:Hub
    {
        public Task SendMessege(string problems)
        {
            return Clients.All.SendAsync("Send","hello");
        }
    }
}
