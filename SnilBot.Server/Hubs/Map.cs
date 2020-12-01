using SnilBot.Shared.Data;
using SnilBot.Shared.Enum;
using SnilBot.Shared.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnilBot.Server.Hubs
{
    public class Map
    {
        public Dictionary<Position, Cell> TestMap;      //Массив непроходимых препятствий
        public List<PositionPair> tempDataTeleport;     //Массив телепортов

        public int globalSizeX;                         //Глобальный размер карты
        public int globalSizeY;

        public Map(int sizeX, int sizeY)
        {

            DataMap dataMap = new DataMap();        //Получение данных из шаблона


            TestMap = new Dictionary<Position, Cell>();                 //Массив непроходимых препятствий
            List<Position> tempDataBarrier = dataMap.positionBarrier;   //Массив барьеров(кубики)

            tempDataTeleport = new List<PositionPair>();        //Массив координат связных ТП
            tempDataTeleport = dataMap.teleport;                //Получили координаты ТП из БД

            foreach (var item in tempDataBarrier)
            {
                TestMap.Add(new Position(item), new Cell(ObjectMap.Coub));  //Заполняем барьеры
            }

            globalSizeX = sizeX;
            globalSizeY = sizeY;
        }


        public bool Step(Position nextPosition)
        {                                           //Проверка. Может ли бот сделать шаг избегая препятствия       
            if (TestMap.ContainsKey(nextPosition))
            {                                         //Если существует на следующем шагу обьект
                if (TestMap[nextPosition].typeObject == ObjectMap.Coub) { return false; }   //Если обьект не проходимый
            }
            if (!IsBorderMap(nextPosition))
            {                                                //Если выходим за пределы карты
                return false;
            }
            nextPosition.z--;
            if (TestMap.ContainsKey(nextPosition))      //Если под ногами есть земля
            {
                return true;
            }
            return false;
        }

        public Position UseTeleport(Position currPosition)
        {
            //Говнокод
            if (tempDataTeleport.Any(s => s.pairPosition[0].IsEquality(currPosition)))
            {     
                PositionPair abc = new PositionPair();
                abc = tempDataTeleport.FirstOrDefault(s => s.pairPosition[0].IsEquality(currPosition));
                return abc.pairPosition[1];
            }

            if (tempDataTeleport.Any(s => s.pairPosition[1].IsEquality(currPosition))) //Если существует в 2 ячейке pair  
            {     
                PositionPair abc = new PositionPair();
                abc = tempDataTeleport.FirstOrDefault(s => s.pairPosition[1].IsEquality(currPosition));
                return abc.pairPosition[0];
            }

            return currPosition;

        }

        public bool IsBorderMap(Position nextPosition)
        {
            if (nextPosition.x < globalSizeX && nextPosition.x >= 0 && nextPosition.y < globalSizeY && nextPosition.y >= 0) return true;
            return false;

        }

    }
}
