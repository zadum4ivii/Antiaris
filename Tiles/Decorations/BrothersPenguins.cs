using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TerrariaOverhaul;

namespace Antiaris.Tiles.Decorations
{
	public class BrothersPenguins : ModTile
	{
	    public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;
		    TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
		    TileObjectData.newTile.StyleHorizontal = true;
		    TileObjectData.newTile.StyleWrapLimit = 36;
		    TileObjectData.newTile.CoordinateHeights = new int[]
		    {
		        16,
		        16
		    };
		    TileObjectData.newTile.Width = 3;
		    TileObjectData.newTile.Height = 2;
            TileObjectData.addTile(Type);
			dustType = 0;
            AddMapEntry(new Color(99,50,30));
		}

	    public void OverhaulInit()
        {
            this.SetTag("flammable");
        }

	    public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			if(frameX == 0)
			{
				Item.NewItem(i * 16, j * 16, 48, 48, mod.ItemType("BrothersPenguins"), 1, false, 0, false, false);
			}
		}
	}
}