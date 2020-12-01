using BabylonJS;
using BabylonJS.GUI;
using EventHorizon.Blazor.Interop.Callbacks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.SignalR.Client;
using SnilBot.Client.Model;
using SnilBot.Client.Shared.MapObject;
using SnilBot.Client.Shared.MapObject.Block;
using SnilBot.Shared.Constants;
using SnilBot.Shared.Data;
using SnilBot.Shared.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;


namespace SnilBot.Client.Shared
{
    public partial class SceneComponent : IDisposable
    {

        public Canvas canvas;
        public Engine engine;
        public Scene scene;
        public Light light1, light2, light3;
        public Mesh ground;
        public Camera camera;

        public AbstractMesh abstractMesh;

        public DataMap dataMap { get; set; }        //Симуляция загрузки с бд

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                dataMap = new DataMap();
                InitDefault();
                InitBot();
                InitBarier();
                InitTeleport();

                //Загрузка обьекта и его текстуры
                //var meshData = await SceneLoader.ImportMeshAsync("", "obj/", "mine.babylon", scene);
                //var mine = meshData.meshes.First();
                //mine.position.x = 0m;
                //mine.position.z = 0m;
                //mine.position.y = 12m;
                //mine.scaling.x = 20;
                //mine.scaling.y = 20;
                //mine.scaling.z = 20;
                //mine.material.metallic = 1;

                var advancedTexture = AdvancedDynamicTexture.CreateFullscreenUI("UI");
                //engine.runRenderLoop(() => Task.Run(() => scene.render(true, false)));

                engine.runRenderLoop(new ActionCallback( async() => scene.render(true,false) ));

            }
        }

        

        public void Dispose()
        { }


        public void InitBot()
        {
            Pes.SetLogicCoord(dataMap.positionBot);     //Получили данные о боте с DATA
            Pes.botView = new BotView(scene, Pes.X, Pes.Y, Pes.Z);  //Отрисовка по полученным координатам
        }


        //
        public void InitDefault()
        {
            canvas = Canvas.GetElementById("game-window");
            engine = new Engine(canvas, true);
            scene = new Scene(engine);


            light1 = new BabylonJS.HemisphericLight("Hemi3", new BabylonJS.Vector3(dataMap.sizeMapX * 2, 10, 0), scene);
            light2 = new BabylonJS.HemisphericLight("Hemi3", new BabylonJS.Vector3(-dataMap.sizeMapX * 2, 10, 0), scene);
            light3 = new BabylonJS.HemisphericLight("Hemi3", new BabylonJS.Vector3(0, 10, 0), scene);


            camera = new ArcRotateCamera(
                            "ArcRotateCamera",
                            0,
                            (decimal)(System.Math.PI / 3),
                            (dataMap.sizeMapX + dataMap.sizeMapY) / 2 * 12,
                            new Vector3(0, 10, 0),
                            scene
                        )
            {
                upperBetaLimit = (decimal)(System.Math.PI / 2),
                lowerBetaLimit = (decimal)(System.Math.PI / 6),
                lowerRadiusLimit = 40,
                upperRadiusLimit = (dataMap.sizeMapX + dataMap.sizeMapY) / 2 * 15
            };
            scene.activeCamera = camera;
            camera.attachControl(false);
        }


        public void InitBarier()
        {
            List<Block> barier = new List<Block>(); //Массив препятствий
            List<Position> tempDataBarrier = dataMap.positionBarrier;  //Получение массива препятвий из DATA
            foreach (var item in tempDataBarrier)
            {
                barier.Add(new Block(scene, item));
            }
        }




        public void InitTeleport()
        {
            List<Teleport> barier = new List<Teleport>(); //Массив телепортов(может быть не 1)
            List<PositionPair> tempDataTeleport = dataMap.teleport;  //Получение массива телепортов из DATA
            foreach (var item in tempDataTeleport)
            {
                barier.Add(new Teleport(scene, item));
            }
        }






    }
}






















