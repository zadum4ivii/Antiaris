using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Antiaris.Tiles.Miscellaneous
{
	public class BlazingHeart : ModTile
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
            name.SetDefault("Blazing Heart");
            name.AddTranslation(GameCulture.Russian, "Пылающее сердце");
			name.AddTranslation(GameCulture.Chinese, "燃烧之心");
            AddMapEntry(new Color(228, 138, 39), name);
            dustType = 6;
            disableSmartCursor = true;
		}

	    public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 48, 48, mod.ItemType("BlazingHeart"), 1, false, 0, false, false);
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
            Main.spriteBatch.Draw(mod.GetTexture("Glow/BlazingHeart_GlowMask"), new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + Zero, new Rectangle(tile.frameX, tile.frameY, 16, Height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
	}
}
