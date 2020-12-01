using BabylonJS;
using SnilBot.Shared.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnilBot.Client.Shared.MapObject.Block
{
    public class Block
    {

        public Position position;

        public BlockView blockView;

        public Block(Scene scene, Position pos)
        {
            position = pos;
            blockView = new BlockView(scene, position.x, position.y, position.z, position.keyColor);
        }

    }
}
