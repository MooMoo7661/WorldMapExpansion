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
            NPCID.DD2DarkMageT1,
            NPCID.DD2DarkMageT3,
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
            NPCID.Everscream
            );
    }
}
