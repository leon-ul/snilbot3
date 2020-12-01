using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace SnilBot.Client.Shared
{
    public partial class InputComponent : IDisposable
    {
        [Inject]
        private Network network { get; init; }

        public void Dispose(){ }

        public async Task Start()
        {
            await network.Solve(await _editor.GetValue());     
        }


    }

}














