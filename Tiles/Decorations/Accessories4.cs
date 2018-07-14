using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Antiaris.Tiles.Decorations
{
    public class Accessories4 : ModTile
    {
        public override void SetDefaults()
        {
			Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.Table | AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.newTile.StyleWrapLimit = 36;
            TileObjectData.addTile(Type);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int item = 0;
			switch (frameX / 18)
			{
				case 0:
				item = ItemID.PDA;
				break;
				case 1:
				item = ItemID.Ruler;
				break;
				case 2:
				item = ItemID.FastClock;
				break;
				case 3:
				item = ItemID.PocketMirror;
				break;
                case 4:
                item = ItemID.ManaFlower;
                break;
				case 5:
                item = ItemID.ClothierVoodooDoll;
                break;
				case 6:
                item = ItemID.GuideVoodooDoll;
                break;
				case 7:
                item = ItemID.MagicQuiver;
                break;
				case 8:
                item = ItemID.ObsidianRose;
                break;
            }
			Item.NewItem(i * 16, j * 16, 16, 16, item, 1, false, 0, false, false);
        }
    }
}