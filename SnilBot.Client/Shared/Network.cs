using Microsoft.AspNetCore.SignalR.Client;
using SnilBot.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnilBot.Client.Shared
{
    public class Network
    {

        public HubConnection hubConnection;

        public Network()
        {
            hubConnection = new HubConnectionBuilder()
            .WithUrl($"//194.1.236.136:5000/userhub{UserHubConstans.HubConnectedString}")
            .Build();
            hubConnection.StartAsync();
        }

        public async Task Solve(string solve) {         //Запрос на сервер
            await hubConnection.SendAsync(UserHubConstans.Solve, solve);
        }


    }
}
