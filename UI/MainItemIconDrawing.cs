using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.Map;
using Terraria.ModLoader;
using Terraria.UI;
using tModPorter;

namespace WorldMapExpansion.UI
{
    public class MainItemIconDrawing : ModMapLayer
    {
        IconDrawConfig config = ModContent.GetInstance<IconDrawConfig>();

        public override void Draw(ref MapOverlayDrawContext context, ref string text)
        {
            if (!ModContent.GetInstance<IconDrawConfig>().DrawItems) { return; }
            foreach (Item item in Main.item)
            {
                if (!item.active || (config.DrawDistance != -1 && Vector2.Distance(Main.LocalPlayer.position, item.position) / 16 > config.DrawDistance)) { continue; }

                float scale = GetItemScale(item);
                var itemName = MapIconDraw.DrawMapIcon(TextureAssets.Item[item.type].Value, new Vector2(item.Center.ToTileCoordinates().X, item.Center.ToTileCoordinates().Y), Color.White, new SpriteFrame(1, 1, 0, 0), scale, scale + 0.1f, Alignment.Center, context, item);
                if (itemName.IsMouseOver) { text = item.HoverName; }
            }
        }

        /// <param name="item"></param>
        /// <returns>0.6f for items under 40 width and height, 0.5f for items under 60 width and height, and 0.4f above</returns>
        public static float GetItemScale(Item item)
        {
            if (item.width >= 40 || item.height >= 40)
            {
                if (item.width >= 60 || item.height >= 60)
                {
                    return 0.4f;
                }

                return 0.5f;
            }

            return 0.6f;
        }
    }
}
