using System.Text.Json.Serialization;
using BabylonJS;
using EventHorizon.Blazor.Interop;

namespace SnilBot.Client.Model
{
    [JsonConverter(typeof(CachedEntityConverter<Canvas>))]
    public class Canvas : HTMLCanvasElementCachedEntity
    {
        public static Canvas GetElementById(
            string elementId
        ) => EventHorizonBlazorInterop.FuncClass(
            entity => new Canvas(entity),
            new string[] { "document", "getElementById" },
            elementId
        );

        private Canvas(
            ICachedEntity entity
        )
        {
            ___guid = entity.___guid;
        }
    }
}
