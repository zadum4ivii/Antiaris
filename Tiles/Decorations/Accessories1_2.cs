using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Antiaris.Tiles.Decorations
{
    public class Accessories1_2 : ModTile
    {
        public override void SetDefaults()
        {
			Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.Table | AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.newTile.StyleWrapLimit = 36;
            TileObjectData.addTile(Type);
        }

        public override bool Drop(int i, int j)
        {
			int style = Main.tile[i, j].frameX / 18;
            int item = 0;
			switch (style)
			{
				case 0:
				item = ItemID.RoyalGel;
				break;
				case 1:
				item = ItemID.CordageGuide;
				break;
				case 2:
				item = ItemID.PanicNecklace;
				break;
				case 3:
				item = ItemID.Shackle;
				break;
				case 4:
				item = ItemID.PutridScent;
				break;
				case 5:
				item = ItemID.SweetheartNecklace;
				break;
				case 6:
				item = ItemID.ArmorPolish;
				break;
				case 7:
				item = ItemID.HandWarmer;
				break;
				case 8:
				item = ItemID.ObsidianHorseshoe;
				break;
				case 9:
				item = ItemID.HighTestFishingLine;
				break;
				case 10:
				item = ItemID.TsunamiInABottle;
				break;
			}
			Item.NewItem(i * 16, j * 16, 16, 16, item, 1, false, 0, false, false);
			return false;
        }
    }
}