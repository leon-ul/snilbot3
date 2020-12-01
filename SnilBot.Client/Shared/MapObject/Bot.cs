using BabylonJS;
using SnilBot.Shared.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnilBot.Client.Shared.MapObject
{
    public class Bot
    {

        public int X;
        public int Y;
        public int Z;

        public BotView botView;

        public Bot()
        {
            X = 0;
            Y = 0;
            Z = 0;

        }
        public void SetLogicCoord(Position position)
        {
            X = position.x;
            Y = position.y;
            Z = position.z;
        }

        public void ResetPosition(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
            botView.ResetPosition(X, Y, Z);
        }


        public void SetPosition(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
            botView.ToPosition(X, Y, Z);
        }




    }
}
