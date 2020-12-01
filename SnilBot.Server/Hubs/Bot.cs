using SnilBot.Shared.Data;
using SnilBot.Shared.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnilBot.Server.Hubs
{

    public class Bot
    {
        private Position position { get; set; }
        private Map globalMap { get; set; }
        public Dictionary<int, CoordJob> ArrayJobCoord { get; set; }
        public RangeFinder rangefinder { get; set; }

        private int kol;

        private DataMap dataMap { get; set; }

        public Bot(Map globalMap)
        {
            dataMap = new DataMap();
            position = dataMap.positionBot;
            ArrayJobCoord = new Dictionary<int, CoordJob>();
            kol = 0;
            this.globalMap = globalMap;
            rangefinder = new RangeFinder(globalMap, position);

        }

        public void Wait()
        {
            DefaultStepHelper();
        }

        public void Teleport()
        {
            position = globalMap.UseTeleport(position);
            DefaultStepHelper();
        }

        public void MoveDown()
        {
            if (globalMap.Step(position.Down())) position = position.Down();
            DefaultStepHelper();
        }

        public void MoveRight()
        {
            if (globalMap.Step(position.Right())) position = position.Right();
            DefaultStepHelper();
        }

        public void MoveUp()
        {
            if (globalMap.Step(position.Up())) position = position.Up();
            DefaultStepHelper();
        }


        public void MoveLeft()
        {
            if (globalMap.Step(position.Left())) position = position.Left();
            DefaultStepHelper();
        }


        private void DefaultStepHelper()
        {
            ArrayJobCoord.Add(kol, new CoordJob(position));
            kol++;
            rangefinder.currPosition = position;
        }




    }







    public class RangeFinder
    {

        public Map global;
        public Position currPosition;

        public RangeFinder(Map map, Position position)
        {
            global = map;
            currPosition = position;
        }

        public int down()
        {
            Position temp = new Position();
            temp = currPosition;
            for (int i = 0; i < 100; i++)
            {
                temp.y++;
                if (!global.Step(temp)) return i;
            }
            return 0;
        }

        public int up()
        {
            Position temp = new Position();
            temp = currPosition;
            for (int i = 0; i < 100; i++)
            {
                temp.y--;
                if (!global.Step(temp)) return i;
            }
            return 0;
        }

        public int left()
        {
            Position temp = new Position();
            temp = currPosition;
            for (int i = 0; i < 100; i++)
            {
                temp.x--;
                if (!global.Step(temp)) return i;
            }
            return 0;
        }

        public int right()
        {
            Position temp = new Position();
            temp = currPosition;
            for (int i = 0; i < 100; i++)
            {
                temp.x++;
                if (!global.Step(temp)) return i;
            }
            return 0;
        }

    };





}
