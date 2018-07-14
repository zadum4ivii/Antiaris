using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Antiaris.Tiles.Crafting
{
    public class Compressor : ModTile
    {
        public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.CoordinateHeights = new []{ 16, 16, 18 };
			TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Compressor");
            name.AddTranslation(GameCulture.Russian, "Компрессор");
            name.AddTranslation(GameCulture.Chinese, "压缩机");
            AddMapEntry(Color.Gray, name);
			disableSmartCursor = true;
			animationFrameHeight = 54;
		}

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 48, 48, mod.ItemType("Compressor"), 1, false, 0, false, false);
		}

        public override void AnimateTile(ref int frame, ref int frameCounter)
		{
			frameCounter++;
			if(frameCounter >= 15)
			{
				frameCounter = 0;
				frame++;
				if(frame >= 4)
				{
					frame = 0;
				}
			}
		}
    }
}
