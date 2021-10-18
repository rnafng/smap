using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace Minimap
{
    public class ModEntry : Mod
    {
        bool display = false;
        Texture2D map;
        public override void Entry(IModHelper helper)
        {
            helper.Events.Input.ButtonPressed += this.OnButtonPressed;
            helper.Events.Display.RenderedWorld += this.renderMiniMap;
            map = helper.Content.Load<Texture2D>("assets/minimap.png", ContentSource.ModFolder);


        }


        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (!Context.IsWorldReady)
                return;

            this.Monitor.Log($"{Game1.player.Name} pressed {e.Button}.", LogLevel.Debug);
            if (e.Button == SButton.N)
            {
                display = !display;
            }

        }

        private void renderMiniMap(object sender, StardewModdingAPI.Events.RenderedWorldEventArgs e)
        {
            if (!display) {
                return;
            }
            Vector2 pos = new Vector2(1475,795);
            e.SpriteBatch.Draw(map, pos, Color.White);

        }
    }
}