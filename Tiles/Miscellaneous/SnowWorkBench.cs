using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TerrariaOverhaul;

namespace Antiaris.Tiles.Miscellaneous
{
    public class SnowWorkBench : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
			Main.tileSolidTop[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
			TileObjectData.newTile.CoordinateHeights = new int[] { 18 };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Work Bench");
            name.AddTranslation(GameCulture.Chinese, "工作台");
            name.AddTranslation(GameCulture.Russian, "Верстак");
            AddMapEntry(new Color(191, 142, 111), name);
        }

        public void OverhaulInit()
        {
            this.SetTag("flammable");
            this.SetTag("coldBiomeRelated");
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 16, ItemID.BorealWoodWorkBench, 1, false, 0, false, false);
        }
    }
}