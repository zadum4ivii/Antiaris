using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Antiaris.Tiles.Miscellaneous
{
	public class NatureCrystal : ModTile
	{
	    public override void SetDefaults()
		{
            Main.tileFrameImportant[Type] = true;
			//Main.tileNoAttach[Type] = true;
			Main.tileLighted[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Nature Crystal");
            name.AddTranslation(GameCulture.Russian, "Кристалл природы");
			name.AddTranslation(GameCulture.Chinese, "自然精华");
            AddMapEntry(new Color(137, 255, 143), name);
            dustType = 61;
            disableSmartCursor = true;
		}

	    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.5f;
            g = 0.6f;
            b = 1f;
        }

	    public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 48, 48, mod.ItemType("NatureEssence"), Main.rand.Next(2, 4), false, 0, false, false);
        }

	    public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            var tile = Main.tile[i, j];
            var Zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen)
            {
                Zero = Vector2.Zero;
            }
            var Height = 16;
            Main.spriteBatch.Draw(mod.GetTexture("Tiles/Miscellaneous/NatureCrystal"), new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + Zero, new Rectangle(tile.frameX, tile.frameY, 16, Height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
	}
}
