using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TerrariaOverhaul;

namespace Antiaris.Tiles.Crafting
{
    public class Stove : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            Main.tileTable[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 36;
			animationFrameHeight = 36;
			TileObjectData.addTile(Type);
			adjTiles = new int[]{96};
			ModTranslation name = CreateMapEntryName();
            name.SetDefault("Stove");
            name.AddTranslation(GameCulture.Chinese, "烤炉");
            name.AddTranslation(GameCulture.Russian, "Плита");
            AddMapEntry(new Color(227, 216, 195), name);
        }

        public void OverhaulInit()
        {
            this.SetTag("warm");
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
		{
			frameCounter++;
			if(frameCounter > 7)
			{
				frameCounter = 0;
				frame++;
				frame %= 4;
			}
		}

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if(Main.tile[i, j].frameX == 0 && Main.tile[i, j].frameY == 0)
            {
                Item.NewItem(i * 16, j * 16, 48, 48, mod.ItemType("Stove"), 1, false, 0, false, false);
            }
        }
    }
}
