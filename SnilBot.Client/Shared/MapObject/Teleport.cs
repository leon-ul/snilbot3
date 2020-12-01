using BabylonJS;
using SnilBot.Shared.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnilBot.Client.Shared.MapObject.Block
{
    public class Teleport
    {

        public PositionPair position;

        public TeleportView teleportView;

        public Teleport(Scene scene, PositionPair pos)
        {
            position = pos;
            teleportView = new TeleportView(scene, position);
        }

    }
}
