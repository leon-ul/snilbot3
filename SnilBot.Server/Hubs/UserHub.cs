using Microsoft.AspNetCore.SignalR;
using SnilBot.Shared.models;
using SnilBot.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System.IO;
using Cake.Core.Scripting;
using System.Text.RegularExpressions;
using SnilBot.Shared.Data;

namespace SnilBot.Server.Hubs
{
    public class UserHub : Hub
    {
        public Map TestMap { get; set; }

        public DataMap dataMap;

        public async Task Solve(string solve)
        {
            dataMap = new DataMap();
            TestMap = new Map(dataMap.sizeMapX, dataMap.sizeMapY);
            Bot c = new Bot(TestMap);
            try
            {
                await CSharpScript.EvaluateAsync(solve, ScriptOptions.Default.WithEmitDebugInformation(true), new ScriptParams(c));
                await Clients.Caller.SendAsync(UserHubConstans.SolveResponse, c.ArrayJobCoord);
            }
            catch (Exception e)
            {
                await Clients.Caller.SendAsync(UserHubConstans.SolveResponse, null);
            }
            

        }
            

        public class ScriptParams {
            public Bot bot;
            public ScriptParams(Bot a)
            {
                bot = a;
            }
        
        }
    }
}
