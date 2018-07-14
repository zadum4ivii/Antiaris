using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TerrariaOverhaul;

namespace Antiaris.Tiles.Decorations
{
	public class SlimyCrate : ModTile
	{
	    public override void SetDefaults()
		{
            Main.tileTable[Type] = true;
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.addTile(Type);
            dustType = 61;
            disableSmartCursor = true;
            ModTranslation name = CreateMapEntryName();
			name.SetDefault("Slimy Crate");
			name.AddTranslation(GameCulture.Russian, "Слизневый ящик");
			name.AddTranslation(GameCulture.Chinese, "小粘板条箱");
			AddMapEntry(new Color(84, 230, 114), name);
		}

	    public void OverhaulInit()
        {
            this.SetTag("flammable");
        }

	    public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			if(frameX == 0)
			{
				Item.NewItem(i * 16, j * 16, 48, 48, mod.ItemType("SlimyCrate"), 1, false, 0, false, false);
			}
		}
	}
}