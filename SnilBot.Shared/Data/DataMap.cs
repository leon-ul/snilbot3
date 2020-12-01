using SnilBot.Shared.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnilBot.Shared.Data
{
    public class DataMap    //Статические данные для демоверсии
    {
        public int sizeMapX;
        public int sizeMapY;

        public Position positionBot;
        public List<Position> positionBarrier;      //Массив кубиков
        public List<PositionPair> teleport;

        public DataMap()
        {
            positionBot = new Position(0, 0, 1);            //Бот
            positionBarrier = new List<Position>();         //Массив барьеров
            teleport = new List<PositionPair>();            //Массив телепортов

            sizeMapX = 15;                                  //Размеры карты
            sizeMapY = 15;

            for (int i = 0; i < sizeMapX; i++)
            {             //Рисуем "Землю"
                for (int j = 0; j < sizeMapY; j++)
                {
                    positionBarrier.Add(new Position(i, j, 0, "Ground"));
                }
            }

            positionBarrier.Add(new Position(3, 0, 1, "Box"));
            positionBarrier.Add(new Position(3, 1, 1, "Box"));
            positionBarrier.Add(new Position(3, 2, 1, "Box"));
            positionBarrier.Add(new Position(3, 3, 1, "Box"));
            positionBarrier.Add(new Position(4, 4, 1, "Box"));
            positionBarrier.Add(new Position(2, 3, 1, "Box"));
            positionBarrier.Add(new Position(1, 3, 1, "Box"));
            positionBarrier.Add(new Position(0, 3, 1, "Box"));

            positionBarrier.Add(new Position(3, 5, 1, "Box"));
            positionBarrier.Add(new Position(2, 6, 1, "Box"));
            positionBarrier.Add(new Position(1, 7, 1, "Box"));
            positionBarrier.Add(new Position(0, 8, 1, "Box"));

            positionBarrier.Add(new Position(0, 7, 5, "Box"));
            positionBarrier.Add(new Position(0, 8, 5, "Box"));
            positionBarrier.Add(new Position(0, 9, 5, "Box"));
            positionBarrier.Add(new Position(0, 10, 5, "Box"));

            positionBarrier.Add(new Position(4, 9, 1, "Box"));
            positionBarrier.Add(new Position(5, 8, 1, "Box"));
            positionBarrier.Add(new Position(6, 7, 1, "Box"));
            positionBarrier.Add(new Position(7, 6, 1, "Box"));

            positionBarrier.Add(new Position(8, 7, 1, "Box"));
            positionBarrier.Add(new Position(9, 8, 1, "Box"));
            positionBarrier.Add(new Position(10, 9, 1, "Box"));

            positionBarrier.Add(new Position(10, 11, 1, "Box"));
            positionBarrier.Add(new Position(9, 12, 1, "Box"));
            positionBarrier.Add(new Position(8, 13, 1, "Box"));
            positionBarrier.Add(new Position(7, 14, 1, "Box"));

            positionBarrier.Add(new Position(6, 13, 1, "Box"));
            positionBarrier.Add(new Position(5, 12, 1, "Box"));
            positionBarrier.Add(new Position(4, 11, 1, "Box"));

            positionBarrier.Add(new Position(5, 5, 1, "Box"));
            positionBarrier.Add(new Position(5, 6, 1, "Box"));

            positionBarrier.Add(new Position(11, 9, 1, "Box"));
            positionBarrier.Add(new Position(12, 9, 1, "Box"));
            positionBarrier.Add(new Position(13, 9, 1, "Box"));
            positionBarrier.Add(new Position(14, 9, 1, "Box"));

            positionBarrier.Add(new Position(4, 10, 3, "Box"));
            positionBarrier.Add(new Position(4, 11, 3, "Box"));
            positionBarrier.Add(new Position(4, 9, 3, "Box"));
            positionBarrier.Add(new Position(4, 11, 2, "Box"));
            positionBarrier.Add(new Position(4, 9, 2, "Box"));

            positionBarrier.Add(new Position(5, 10, 3, "Box"));
            positionBarrier.Add(new Position(5, 11, 3, "Box"));
            positionBarrier.Add(new Position(5, 9, 3, "Box"));

            positionBarrier.Add(new Position(6, 10, 3, "Box"));
            positionBarrier.Add(new Position(6, 11, 3, "Box"));
            positionBarrier.Add(new Position(6, 9, 3, "Box"));

            positionBarrier.Add(new Position(7, 10, 3, "Box"));
            positionBarrier.Add(new Position(7, 11, 3, "Box"));
            positionBarrier.Add(new Position(7, 9, 3, "Box"));

            positionBarrier.Add(new Position(8, 10, 3, "Box"));
            positionBarrier.Add(new Position(8, 11, 3, "Box"));
            positionBarrier.Add(new Position(8, 9, 3, "Box"));

            positionBarrier.Add(new Position(9, 10, 3, "Box"));
            positionBarrier.Add(new Position(9, 11, 3, "Box"));
            positionBarrier.Add(new Position(9, 9, 3, "Box"));


            positionBarrier.Add(new Position(10, 10, 3, "Box"));
            positionBarrier.Add(new Position(10, 11, 3, "Box"));
            positionBarrier.Add(new Position(10, 9, 3, "Box"));
            positionBarrier.Add(new Position(10, 11, 2, "Box"));
            positionBarrier.Add(new Position(10, 9, 2, "Box"));

            positionBarrier.Add(new Position(7, 10, 4, "Win"));


            teleport.Add(new PositionPair(new Position(2, 2, 1), new Position(3, 4, 1), 1, 1, 0));     //
            teleport.Add(new PositionPair(new Position(0, 7, 1), new Position(0, 7, 6), 1, 0, 1));     //
            teleport.Add(new PositionPair(new Position(0, 10, 6), new Position(0, 10, 1), 1, 0, 0));
            teleport.Add(new PositionPair(new Position(8, 14, 1), new Position(4, 0, 1), 0, 1, 0));

            teleport.Add(new PositionPair(new Position(14, 0, 1), new Position(7, 10, 5), 0, 0, 0));

        }

    }
}
