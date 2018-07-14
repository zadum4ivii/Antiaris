using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Antiaris.Tiles.Decorations
{
    public class Accessories5 : ModTile
    {
        public override void SetDefaults()
        {
			Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
			TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16
            };
			TileObjectData.newTile.Width = 3; 
			TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 36;
            TileObjectData.addTile(Type);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int item = 0;
			switch (frameX / 54)
			{
				case 0:
				item = ItemID.CobaltShield;
				break;
				case 1:
				item = ItemID.AnkhShield;
				break;
            }
			Item.NewItem(i * 16, j * 16, 16, 16, item, 1, false, 0, false, false);
        }
    }
}