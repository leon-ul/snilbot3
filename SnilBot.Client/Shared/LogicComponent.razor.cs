using BabylonJS;
using BabylonJS.GUI;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;
using SnilBot.Client.Model;
using SnilBot.Client.Shared.MapObject;
using SnilBot.Shared.Constants;
using SnilBot.Shared.Data;
using SnilBot.Shared.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace SnilBot.Client.Shared
{
    public partial class LogicComponent : IDisposable
    {

        [Inject]
        private Network network { get; init; }

        public DataMap Test;
        protected override void OnAfterRender(bool firstRender)
        {
            Test = new DataMap();
            LogicInit();
        }

        public void Dispose()
        { }

        public void LogicInit()
        {
            network.hubConnection.On<Dictionary<int, CoordJob>>(UserHubConstans.SolveResponse, HandleResponeSolveAsync);
        }


        public void Temp(Dictionary<int, CoordJob> response)
        {
            if (response == null)
            {
                throw new ArgumentNullException();
            }

        }

        private async Task HandleResponeSolveAsync(Dictionary<int, CoordJob> response) {       
            var Step = 0;

            try{
                Temp(response);
            }
            catch (Exception e)
            {
                if (!await JSRuntime.InvokeAsync<bool>("alert", default, new string[] { "Ошибка компиляции" }))
                return;
            }



            bot.ResetPosition(Test.positionBot.x, Test.positionBot.y, Test.positionBot.z);

            var timer = new System.Timers.Timer(1000);
            timer.AutoReset = true;
            timer.Elapsed += (sender, args) =>
            {
                bot.SetPosition(response[Step].x, response[Step].y, response[Step].z);     //Изменить на Z
                Step++;
                if (Step == response.Count()) { timer.Stop(); timer.Dispose(); }
            };
            timer.Start();

        }

    }
}