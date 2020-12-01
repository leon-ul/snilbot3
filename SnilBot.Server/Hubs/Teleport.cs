using SnilBot.Shared.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnilBot.Server.Hubs
{
    public class Teleport
    {
        public PositionPair position { get; set; } // Teleport [ pos1 <===> pos2 ]

        public Teleport(PositionPair pos)
        {
            position = pos;
        }

    }
}
