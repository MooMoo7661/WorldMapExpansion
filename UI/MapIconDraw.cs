using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Map;
using Terraria.UI;
using Terraria;
using static Terraria.Map.MapOverlayDrawContext;
using Microsoft.Xna.Framework;
using System.Reflection;
using Terraria.GameContent;
using Terraria.ModLoader;
using System;

namespace WorldMapExpansion.UI
{
    public class MapIconDraw
    {
        //This code is a nightmare. I know, it sucks, and I hate it too.

        /// <summary>
        /// Used to reflect fields from a context.
        /// </summary>
        public struct MapOverlayDrawContextCapture
        {
            public static readonly FieldInfo _mapPosition = typeof(MapOverlayDrawContext).GetField("_mapPosition", BindingFlags.NonPublic | BindingFlags.Instance);
            public static readonly FieldInfo _mapOffset = typeof(MapOverlayDrawContext).GetField("_mapOffset", BindingFlags.NonPublic | BindingFlags.Instance);
            public static readonly FieldInfo _clippingRect = typeof(MapOverlayDrawContext).GetField("_clippingRect", BindingFlags.NonPublic | BindingFlags.Instance);
            public static readonly FieldInfo _mapScale = typeof(MapOverlayDrawContext).GetField("_mapScale", BindingFlags.NonPublic | BindingFlags.Instance);
            public static readonly FieldInfo _drawScale = typeof(MapOverlayDrawContext).GetField("_drawScale", BindingFlags.NonPublic | BindingFlags.Instance);

            public Vector2 mapPosition;
            public Vector2 mapOffset;
            public Rectangle? clippingRect;
            public float mapScale;
            public float drawScale;

            public static MapOverlayDrawContextCapture Capture(MapOverlayDrawContext context)
            {
                MapOverlayDrawContextCapture capture = new()
                {
                    mapPosition = (Vector2)_mapPosition.GetValue(context),
                    mapOffset = (Vector2)_mapOffset.GetValue(context),
                    clippingRect = (Rectangle?)_clippingRect.GetValue(context),
                    mapScale = (float)_mapScale.GetValue(context),
                    drawScale = (float)_drawScale.GetValue(context)
                };

                return capture;
            }
        }

        public static DrawResult DrawNpcMapIcon(NPC npc, Color color, MapOverlayDrawContext context)
        {
            MapOverlayDrawContextCapture capture = MapOverlayDrawContextCapture.Capture(context);
            IconDrawConfig config = ModContent.GetInstance<IconDrawConfig>();
            Vector2 MapPosition = capture.mapPosition;
            Vector2 MapOffset = capture.mapOffset;
            float mapScale = capture.mapScale;
            float drawScale = capture.drawScale;

            Vector2 position = npc.position.ToTileCoordinates().ToVector2();
            SpriteFrame frame = new SpriteFrame(1, 1, 0, 0);
            Texture2D texture = TextureAssets.Npc[npc.type].Value;
            float scaleIfNotSelected = config.NpcScale;

            position = (position - capture.mapPosition) * capture.mapScale + capture.mapOffset;
            if (capture.clippingRect.HasValue && !capture.clippingRect.Value.Contains(position.ToPoint()))
            {
                return DrawResult.Culled;
            }

            Rectangle sourceRectangle = npc.frame;
            Vector2 vector = sourceRectangle.Size() * Alignment.Center.OffsetMultiplier;
            Vector2 position2 = position;
            float num = capture.drawScale * scaleIfNotSelected;
            Vector2 vector2 = position - vector * num;
            bool num2 = new Rectangle((int)vector2.X, (int)vector2.Y, (int)(sourceRectangle.Width * num), (int)(sourceRectangle.Height * num)).Contains(Main.MouseScreen.ToPoint());
            float scale = num;
            if (num2)
            {
                scale = capture.drawScale * scaleIfNotSelected + 0.1f;
            }

            SpriteEffects effects = SpriteEffects.None;
            if (npc.spriteDirection == 1) { effects = SpriteEffects.FlipHorizontally; }

            position2 = (npc.Center / 16f - MapPosition) * mapScale + MapOffset;
            position2.Y -= npc.frame.X / 2;

            sourceRectangle = npc.frame;
            if (sourceRectangle.Width > 75 || sourceRectangle.Height > 75)
                return new DrawResult(num2);

            Main.spriteBatch.Draw(texture, position2, npc.frame, color, npc.rotation, new Vector2(sourceRectangle.Width / 2f, sourceRectangle.Height / 2), scale, effects, 0f);
            return new DrawResult(num2);
        }

        /// <summary>
        /// An alternate Draw for MapOverlayDrawContext.Draw, that takes in a context and a projectile.
        /// </summary>
        public static DrawResult DrawProjectileOnMap(Texture2D texture, Vector2 position, Color color, SpriteFrame frame, float scaleIfNotSelected, float scaleIfSelected, Alignment alignment, MapOverlayDrawContext context, Projectile projectile)
        {
            //Minimap offscreen detection
            MapOverlayDrawContextCapture capture = MapOverlayDrawContextCapture.Capture(context);
            position = (position - capture.mapPosition) * capture.mapScale + capture.mapOffset;
            if (capture.clippingRect.HasValue && !capture.clippingRect.Value.Contains(position.ToPoint()))
            {
                return DrawResult.Culled;
            } 


            // assigning local vars to captures
            IconDrawConfig config = ModContent.GetInstance<IconDrawConfig>();
            Vector2 MapPosition = capture.mapPosition;
            Vector2 MapOffset = capture.mapOffset;
            float mapScale = capture.mapScale;
            float drawScale = capture.drawScale;

            Rectangle sourceRectangle = frame.GetSourceRectangle(texture);
            Vector2 vector = sourceRectangle.Size() * alignment.OffsetMultiplier;
            Vector2 position2 = position;
            float num = capture.drawScale * scaleIfNotSelected;
            Vector2 vector2 = position - vector * num;
            bool num2 = new Rectangle((int)vector2.X, (int)vector2.Y, (int)(sourceRectangle.Width * num), (int)(sourceRectangle.Height * num)).Contains(Main.MouseScreen.ToPoint());
            float scale = num;
            if (num2)
            {
                scale = capture.drawScale * scaleIfSelected;
            }
            position2 = (projectile.Bottom / 16f - MapPosition) * mapScale + MapOffset;

            SpriteEffects effects = SpriteEffects.None;

            Main.spriteBatch.Draw(texture, position2, sourceRectangle, color, projectile.rotation, vector, scale, effects, 0f);
            return new DrawResult(num2);
        }

        public static DrawResult DrawMapIcon(Texture2D texture, Vector2 position, Color color, SpriteFrame frame, float scaleIfNotSelected, float scaleIfSelected, Alignment alignment, MapOverlayDrawContext context, Item item)
        {
            MapOverlayDrawContextCapture capture = MapOverlayDrawContextCapture.Capture(context);
            IconDrawConfig config = ModContent.GetInstance<IconDrawConfig>();
            position = (position - capture.mapPosition) * capture.mapScale + capture.mapOffset;
            if (capture.clippingRect.HasValue && !capture.clippingRect.Value.Contains(position.ToPoint()))
            {
                return DrawResult.Culled;
            }

            Rectangle sourceRectangle = frame.GetSourceRectangle(texture);
            Vector2 vector = sourceRectangle.Size() * alignment.OffsetMultiplier;
            Vector2 position2 = position;
            float num = capture.drawScale * scaleIfNotSelected;
            Vector2 vector2 = position - vector * num;
            bool num2 = new Rectangle((int)vector2.X, (int)vector2.Y, (int)(sourceRectangle.Width * num), (int)(sourceRectangle.Height * num)).Contains(Main.MouseScreen.ToPoint());
            float scale = num;
            if (num2)
            {
                scale = capture.drawScale * scaleIfSelected;
            }

            scale *= config.ItemScale;

            Main.instance.LoadItem(item.type);
            Texture2D value = TextureAssets.Item[item.type].Value;
            sourceRectangle = Main.itemAnimations[item.type]?.GetFrame(value) ?? value.Frame();
            SpriteEffects effects = SpriteEffects.None;
            Main.spriteBatch.Draw(texture, position2, sourceRectangle, color, 0f, sourceRectangle.Size() / 2f, scale, effects, 0f);
            return new DrawResult(num2);
        }
    }
}
