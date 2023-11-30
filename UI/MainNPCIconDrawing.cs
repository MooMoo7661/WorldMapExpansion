using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.Map;
using Terraria.ModLoader;
using Terraria.UI;

namespace WorldMapExpansion.UI
{
    public class MainNPCIconDrawing : ModMapLayer
    {
        public static readonly string path = "WorldMapExpansion/UI/Icons/";

        public override void Draw(ref MapOverlayDrawContext context, ref string text)
        {
            if (!ModContent.GetInstance<IconDrawConfig>().DrawNPCs) { return; }

            foreach (NPC npc in Main.npc.SkipLast(1)) // last is a dummy npc
            {
                if (npc.active && !npc.townNPC && !npc.boss && !DrawSets.AvoidDrawing[npc.type])
                {   
                    Dictionaries dictionaries = new Dictionaries();
                    Texture2D tex = dictionaries.GetIcon(npc.type);
                    Color color = Color.White;
                    IconDrawConfig config = ModContent.GetInstance<IconDrawConfig>();

                    if (config.DrawDistance != -1 && Vector2.Distance(Main.LocalPlayer.position, npc.position) / 16 > config.DrawDistance)
                    {
                        continue;
                    }

                    if (DrawSets.ShouldUseNpcDrawColor[npc.type])
                    {
                        color = npc.color;
                    }

                    if (tex == null)
                    {
                        tex = (Texture2D)TextureAssets.Npc[npc.type];

                        var name = MapIconDraw.DrawNpcMapIcon(npc, color, context);
                        if (name.IsMouseOver) { text = npc.FullName; }
                    }
                    else
                    {
                        var npcName = context.Draw(tex, new Vector2(npc.Center.ToTileCoordinates().X, npc.Center.ToTileCoordinates().Y), color, new SpriteFrame(1, 1, 0, 0), 0.7f, 0.8f, Alignment.Center);
                        if (npcName.IsMouseOver) { text = npc.FullName; }
                    }
                }
            }
        }
    }
}
