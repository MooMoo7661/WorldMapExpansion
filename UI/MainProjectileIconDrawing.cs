﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent;
using Terraria.Map;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.UI;
using Terraria.ID;

namespace WorldMapExpansion.UI
{
    public class MainProjectileIconDrawing : ModMapLayer
    {
        public override void Draw(ref MapOverlayDrawContext context, ref string text)
        {
           //foreach(Projectile projectile in Main.projectile)
           //{
           //     Main.NewText(Main.projFrames[ContentSamples.ProjectilesByType[Main.LocalPlayer.HeldItem.shoot].type]);
           //     if (projectile.width < 40 && projectile.height <= 50 && projectile.active)
           //     {
           //         var projectileName = MapIconDraw.DrawMapIcon(TextureAssets.Projectile[projectile.type].Value, new Vector2(projectile.Center.ToTileCoordinates().X, projectile.Center.ToTileCoordinates().Y), Color.White, new SpriteFrame(1, (byte)Main.projFrames[projectile.type], 0, 0), 0.5f, 0.6f, Alignment.Center, context, projectile);
           //         if (projectileName.IsMouseOver) { text = projectile.Name; }
           //     }
           //}
        }
    }
}
