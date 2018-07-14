using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Antiaris.Tiles.Miscellaneous
{
    public class SteelShovel : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
			TileObjectData.newTile.CoordinateWidth = 18;
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Steel Shovel");
            name.AddTranslation(GameCulture.Chinese, "铁锹");
            name.AddTranslation(GameCulture.Russian, "Стальная лопата");
            AddMapEntry(new Color(96, 105, 105), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("SteelShovel"), 1, false, 0, false, false);
        }

        public override void MouseOver(int i, int j)
		{
			Player player = Main.LocalPlayer;
			player.noThrow = 2;
			player.showItemIcon = true;
			player.showItemIcon2 = mod.ItemType("SteelShovel");
		}

        public override void RightClick(int x, int y)
		{
			WorldGen.KillTile(x, y, false, false, false);
		}
    }
}