using BabylonJS;
using BabylonJS.GUI;
using SnilBot.Client.Model;
using SnilBot.Shared.Data;
using SnilBot.Shared.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnilBot.Client.Shared.MapObject
{
    public class TeleportView
    {
        public decimal globalX { get; set; }
        public decimal globalY { get; set; }
        public decimal globalZ { get; set; }       //Future

        public StandardMaterial materialBox;

        public Mesh Obj;        //Обьект
        public Mesh Obj2;        //Обьект

        public DataMap dataMap;

        public TeleportView(Scene scene, PositionPair pos)
        {
            dataMap = new DataMap();

            Obj = Mesh.CreateTorus("torus", 10, 1, 10, scene);
            Obj.position.z = globalX = (decimal)(dataMap.sizeMapX * (-4.5) + (pos.pairPosition[0].x * 10.15));
            Obj.position.x = globalY = (decimal)(dataMap.sizeMapY * (-4.5) + (pos.pairPosition[0].y * 10.15));
            if (pos.pairPosition[0].z == 0) Obj.position.y = 1;
            else Obj.position.y = (decimal)5 * (pos.pairPosition[0].z + pos.pairPosition[0].z);


            Obj2 = Mesh.CreateTorus("torus", 10, 1, 8, scene);
            Obj2.position.z = globalX = (decimal)(dataMap.sizeMapX * (-4.5) + (pos.pairPosition[1].x * 10.15));
            Obj2.position.x = globalY = (decimal)(dataMap.sizeMapY * (-4.5) + (pos.pairPosition[1].y * 10.15));
            if (pos.pairPosition[1].z == 0) Obj2.position.y = 1;
            else Obj2.position.y = (decimal)5 * (pos.pairPosition[1].z + pos.pairPosition[1].z);

            materialBox = new StandardMaterial("temp", scene);
            materialBox.diffuseColor = new Color3(pos.red, pos.green, pos.blue);
            Obj.material = materialBox;
            Obj2.material = materialBox;
        }

    }
}
