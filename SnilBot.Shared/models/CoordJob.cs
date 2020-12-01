using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnilBot.Shared.models
{
    public struct CoordJob
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }


        public CoordJob(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public CoordJob(Position position)
        {
            x = position.x;
            y = position.y;
            z = position.z;
        }


    }






}
