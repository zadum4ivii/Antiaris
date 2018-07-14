using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Antiaris.Tiles.MusicBoxes
{
	class AntlionQueenMusicBox : ModTile
	{
	    public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileObsidianKill[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(Type);
			disableSmartCursor = true;
			ModTranslation name = CreateMapEntryName();
            name.SetDefault("Music Box");
            name.AddTranslation(GameCulture.Russian, "Музыкальная шкатулка");
			name.AddTranslation(GameCulture.Chinese, "音乐盒");
			AddMapEntry(new Color(191, 142, 111), name);
		}

	    public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType("AntlionQueenMusicBox"), 1, false, 0, false, false);
		}

	    public override void MouseOver(int i, int j)
		{
			Player player = Main.player[Main.myPlayer];
			player.noThrow = 2;
			player.showItemIcon = true;
			player.showItemIcon2 = mod.ItemType("AntlionQueenMusicBox");
		}
	}
}
