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
    public class BlockView
    {
        public decimal globalX { get; set; }
        public decimal globalY { get; set; }
        public decimal globalZ { get; set; }       //Future

        public StandardMaterial materialBox;

        public Mesh Obj;        //Обьект

        public DataMap dataMap;

        public BlockView(Scene scene, int x, int y, int z, string keyCol = null)
        {
            dataMap = new DataMap();

            Obj = Mesh.CreateBox("Obj", 10, scene);
            Obj.position.z = globalX = (decimal)(dataMap.sizeMapX * (-4.5) + (x * 10.15));
            Obj.position.x = globalY = (decimal)(dataMap.sizeMapY * (-4.5) + (y * 10.15));

            if (z == 0) Obj.position.y = globalZ = 5;         // 4 - высота обьекта
            else Obj.position.y = globalZ = 5 * (z + z) + 5;         // 4 - высота обьекта

            materialBox = new StandardMaterial("temp", scene);

            if (keyCol == "Ground") materialBox.diffuseColor = new Color3((decimal)0.17, (decimal)0.17, (decimal)0.17);
            if (keyCol == "Box") materialBox.diffuseColor = new Color3((decimal)0.10, (decimal)0.10, (decimal)0.10);
            if (keyCol == "Win") materialBox.diffuseColor = new Color3(0, (decimal)0.8, 0);

            Obj.material = materialBox;
        }

    }
}
