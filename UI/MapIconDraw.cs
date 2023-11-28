using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Map;
using Terraria.UI;
using Terraria;
using static Terraria.Map.MapOverlayDrawContext;
using Microsoft.Xna.Framework;
using System.Reflection;

namespace WorldMapExpansion.UI
{
    public class MapIconDraw
    {
        //code used from MagicStorage
        
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

        /// <summary>
        /// An alternate Draw for MapOverlayDrawContext.Draw, that takes in a context and an NPes
        /// </summary>
        public static DrawResult DrawMapIcon(Texture2D texture, Vector2 position, Color color, SpriteFrame frame, float scaleIfNotSelected, float scaleIfSelected, Alignment alignment, MapOverlayDrawContext context, NPC npc)
        {
            MapOverlayDrawContextCapture capture = MapOverlayDrawContextCapture.Capture(context);
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

            SpriteEffects effects = SpriteEffects.None;
            if (npc.spriteDirection == 1) { effects = SpriteEffects.FlipHorizontally; }
            Main.spriteBatch.Draw(texture, position2, sourceRectangle, color, npc.rotation, vector, scale, effects, 0f);
            return new DrawResult(num2);
        }

        /// <summary>
        /// An alternate Draw for MapOverlayDrawContext.Draw, that takes in a context and a projectile.
        /// </summary>
        public static DrawResult DrawMapIcon(Texture2D texture, Vector2 position, Color color, SpriteFrame frame, float scaleIfNotSelected, float scaleIfSelected, Alignment alignment, MapOverlayDrawContext context, Projectile projectile)
        {
            MapOverlayDrawContextCapture capture = MapOverlayDrawContextCapture.Capture(context);
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

            SpriteEffects effects = SpriteEffects.None;
            if (projectile.spriteDirection == 1) { effects = SpriteEffects.FlipHorizontally; }
            Main.spriteBatch.Draw(texture, position2, sourceRectangle, color, projectile.rotation, vector, scale, effects, 0f);
            return new DrawResult(num2);
        }
    }
}
