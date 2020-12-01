using System;
using System.Collections.Generic;
using System.Text;

namespace SnilBot.Shared.models
{
    public struct PositionPair
    {
        public List<Position> pairPosition;
        public decimal red, green, blue;

        public PositionPair(Position pos1, Position pos2, decimal red, decimal green, decimal blue)
        {
            pairPosition = new List<Position>();
            pairPosition.Add(pos1);
            pairPosition.Add(pos2);
            this.red = red;
            this.green = green;
            this.blue = blue;
        }

        public Position GetFriendPosition(Position position)
        {
            if (pairPosition[0].IsEquality(position)) return pairPosition[1].GetPosition();  //Если это pos1 возвращаем pos2
            return pairPosition[0].GetPosition();                                            //Если это pos2 возвращаем pos1           
        }


    }

}
