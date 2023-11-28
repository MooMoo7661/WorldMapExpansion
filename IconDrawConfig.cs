using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace WorldMapExpansion
{
    public class IconDrawConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Label("Draw NPCS")]
        [Tooltip("Enemies, critters, bosses, etc. all count as npcs. Town npcs are not the only npcs.")]
        [DefaultValue(true)]
        public bool DrawNPCs { get; set; }

        [Label("Draw Items")]
        [Tooltip("Configure drawing dropped items on the map")]
        [DefaultValue(true)]
        public bool DrawItems { get; set; }
    }
}
