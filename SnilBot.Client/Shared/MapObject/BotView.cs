using BabylonJS;
using BabylonJS.GUI;
using EventHorizon.Blazor.Interop.Callbacks;
using SnilBot.Client.Model;
using SnilBot.Shared.Data;
using SnilBot.Shared.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnilBot.Client.Shared.MapObject
{
    public class BotView
    {
        public decimal globalX { get; set; }
        public decimal globalY { get; set; }
        public decimal globalZ { get; set; }       //Future

        Vector3 nextPosition;

        public StandardMaterial materialBox;

        public Mesh Obj;        //Обьект
        public Mesh Obj2;        //Обьект

        public DataMap dataMap;

        public BotView(Scene scene, int x, int y, int z)
        {
            dataMap = new DataMap();

            Obj = Mesh.CreateSphere("Obj", 10, 10, scene);
            Obj2 = Mesh.CreateSphere("Obj", 8, 8, scene);
            Obj2.parent = Obj;
            Obj2.position.y = 8;

            Obj.position.z = globalX = (decimal)(dataMap.sizeMapX * (-4.5) + (x * 10.15));
            Obj.position.x = globalY = (decimal)(dataMap.sizeMapY * (-4.5) + (y * 10.15));
            if (z == 0) Obj.position.y = globalZ = 5;         // 4 - высота обьекта
            else Obj.position.y = globalZ = 5 * (z + z) + 5;         // 4 - высота обьекта
            
            materialBox = new StandardMaterial("temp", scene);
            materialBox.diffuseTexture = new BabylonJS.Texture(scene, "https://thumbs.dreamstime.com/b/%D0%B2%D0%BE%D0%B4%D0%B0-%D0%B3%D0%BE%D0%BB%D1%83%D0%B1%D0%BE%D0%B9-%D1%82%D0%B5%D0%BA%D1%81%D1%82%D1%83%D1%80%D1%8B-%D0%BE%D1%82%D1%80%D0%B0%D0%B6%D0%B5%D0%BD%D0%B8%D1%8F-%D0%B1%D0%B0%D1%81%D1%81%D0%B5%D0%B8%D0%BD%D0%B0-%D0%BF%D1%80%D0%BE%D0%B7%D1%80%D0%B0%D1%87%D0%BD%D0%B0%D1%8F-11883597.jpg");
            Obj.material = Obj2.material = materialBox;



            // Skybox
            //  var skybox = Mesh.CreateBox("skyBox", 1000.0m, scene);
            //   var skyboxMaterial = new StandardMaterial("skyBox", scene);
            //   skyboxMaterial.backFaceCulling = false;
            //   skyboxMaterial.reflectionTexture = new CubeTexture("jpg/test", scene);
            //   skyboxMaterial.reflectionTexture.coordinatesMode = Texture.SKYBOX_MODE;
            //   skyboxMaterial.diffuseColor = new Color3(0, 0, 0);
            //   skyboxMaterial.specularColor = new Color3(0, 0, 0);
            //    skybox.material = skyboxMaterial;
            //   skybox.infiniteDistance = true;
        }

        public void ResetPosition(int x, int y, int z) {
            Obj.position.z = globalX = (decimal)(dataMap.sizeMapX * (-4.5) + (x * 10.15));
            Obj.position.x = globalY = (decimal)(dataMap.sizeMapY * (-4.5) + (y * 10.15));

            if (z == 0) Obj.position.y = globalZ = 5;         
            else Obj.position.y = globalZ = 5 * (z + z) + 5;             
        }


        public void ToPosition(int x, int y, int z){

            //Анимация
            //if (z == 0) nextPosition = new Vector3((decimal)(dataMap.sizeMapY * (-4.5) + (y * 10.15)), 5, (decimal)(dataMap.sizeMapX * (-4.5) + (x * 10.15)));
            //else nextPosition = new Vector3((decimal)(dataMap.sizeMapY * (-4.5) + (y * 10.15)), 5 * (z + z) + 5, (decimal)(dataMap.sizeMapX * (-4.5) + (x * 10.15)));
            //Animation.CreateAndStartAnimation("test", Obj, "position", 30m, 20m, Obj.position, nextPosition, Animation.ANIMATIONLOOPMODE_CONSTANT, null, 
            //new ActionCallback( async () => { Obj.position = nextPosition; })) ;


            Obj.position.z = globalX = (decimal)(dataMap.sizeMapX * (-4.5) + (x * 10.15));
            Obj.position.x = globalY = (decimal)(dataMap.sizeMapY * (-4.5) + (y * 10.15));

            if (z == 0) Obj.position.y = globalZ = 5;         
            else Obj.position.y = globalZ = 5 * (z + z) + 5;        
        }

    }
}
