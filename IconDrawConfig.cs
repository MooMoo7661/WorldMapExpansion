using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace WorldMapExpansion
{
    public class IconDrawConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [DefaultValue(true)]
        public bool DrawNPCs { get; set; }

        [DefaultValue(true)]
        public bool DrawItems { get; set; }

        [BackgroundColor(255, 0, 0)]
        [DefaultValue(false)]
        public bool DrawProjectiles { get; set; }

        [DefaultValue(0.8f)]
        [Increment(0.1f)]
        [Range(0.2f, 1.5f)]
        [Slider]
        public float NpcScale { get; set; }

        [DefaultValue(1f)]
        [Increment(0.1f)]
        [Range(0.4f, 1.5f)]
        [Slider]
        public float ItemScale { get; set; }

        [DefaultValue(160f)]
        [Increment(1f)]
        [Range(-1f, 500f)]
        [Slider]
        public float DrawDistance { get; set; }
    }
}
