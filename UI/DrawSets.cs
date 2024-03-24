using Terraria.ID;

namespace WorldMapExpansion.UI
{
    public class DrawSets
    {
        public static bool[] ShouldUseNpcDrawColor = ItemID.Sets.Factory.CreateBoolSet(NPCID.BlueSlime);

        public static bool[] AvoidDrawing = ItemID.Sets.Factory.CreateBoolSet(
            NPCID.WindyBalloon,
            NPCID.DD2OgreT2,
            NPCID.DD2OgreT3,
            NPCID.DD2Betsy,
            NPCID.PirateShip,
            NPCID.IceQueen,
            NPCID.Pumpking,
            NPCID.MourningWood,
            NPCID.SantaNK1,
            NPCID.MartianSaucer,
            NPCID.MartianSaucerCannon,
            NPCID.MartianSaucerCore,
            NPCID.MartianSaucerTurret,
            NPCID.Everscream,
            NPCID.GolemFistLeft,
            NPCID.GolemFistRight,
            NPCID.GolemHead,
            NPCID.GolemHeadFree,
            NPCID.Shimmerfly
            );

       
        public static bool[] AvoidDrawingProjectile = ItemID.Sets.Factory.CreateBoolSet(
            ProjectileID.TheHorsemansBlade,
            ProjectileID.FinalFractal,
            ProjectileID.TrueExcalibur,
            ProjectileID.TrueNightsEdge
            );

        public static bool[] FlipSprite = ItemID.Sets.Factory.CreateBoolSet(
            ProjectileID.Spear,
            ProjectileID.AdamantiteGlaive,
            ProjectileID.ChlorophytePartisan,
            ProjectileID.CobaltNaginata,
            ProjectileID.DarkLance,
            ProjectileID.MonkStaffT2,
            ProjectileID.Gungnir,
            ProjectileID.MushroomSpear,
            ProjectileID.MythrilHalberd,
            ProjectileID.NorthPoleWeapon,
            ProjectileID.ObsidianSwordfish,
            ProjectileID.OrichalcumHalberd,
            ProjectileID.PalladiumPike,
            ProjectileID.ThunderSpear,
            ProjectileID.Swordfish,
            ProjectileID.TheRottedFork,
            ProjectileID.TitaniumTrident,
            ProjectileID.Trident
            );
    }
}
