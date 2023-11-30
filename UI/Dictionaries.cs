using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace WorldMapExpansion.UI
{
    public class Dictionaries : ModSystem
    {
        public static readonly string path = "WorldMapExpansion/UI/Icons/";

        /// <summary>
        /// Allows overriding of the automatic npc icon drawing, to instead opt for a custom icon.
        /// </summary>
        public static Dictionary<int, Icon> dict = new Dictionary<int, Icon>();

        #region Icons
        public Icon slime = new();
        #endregion

        public override void PostSetupContent()
        {
            AddDictionaryEntries();
        }

        /// <summary>
        /// Used to register dictionary entries. All entries use TryAdd to avoid possible conflicts
        /// </summary>
        public void AddDictionaryEntries()
        {
            //slime.Set("BlueSlime"); dict.TryAdd(NPCID.BlueSlime, slime); // example
        }

        public Texture2D GetIcon(int npcid)
        {
            if (dict.TryGetValue(npcid, out Icon icon))
            {
                return icon.Get();
            }

            return null;
        }

        public class Icon
        {
            public Texture2D tex;

            public void Set(string name)
            {
                tex = ModContent.Request<Texture2D>(path + name, ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;
            }

            public Texture2D Get()
            {
                return tex;
            }
        }

    }
}
