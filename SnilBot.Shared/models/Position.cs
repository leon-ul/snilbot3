using System;
using System.Collections.Generic;
using System.Text;

namespace SnilBot.Shared.models
{
    public struct Position        //Массив препятствий в виде кубиков
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }

        public string keyColor { get; set; }

        public Position(int x, int y, int z, string keyCol = null)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            keyColor = keyCol;
        }

        public Position(Position position, string keyCol = null)
        {
            x = position.x;
            y = position.y;
            z = position.z;
            keyColor = keyCol;
        }

        ///////////
        ///////////
        ///////////

        public bool IsEquality(Position pos)        //Равенство  position1 == position2
        {
            if (pos.x == x && pos.y == y && pos.z == z) return true;
            return false;
        }

        public Position GetPosition()           //Получить позицию в виде структуры
        {
            return new Position(x, y, z);
        }

        ///////////
        ///////////
        ///////////

        public Position Up() { return new Position(x, y - 1, z); }    //Вперед
        public Position Down() { return new Position(x, y + 1, z); }    //Назад
        public Position Right() { return new Position(x + 1, y, z); }   //Вправо
        public Position Left() { return new Position(x - 1, y, z); }    //Влево
        public Position Top() { return new Position(x, y, z + 1); }     //Вверх
        public Position Bottom() { return new Position(x, y, z - 1); }  //Вниз

    }


}
