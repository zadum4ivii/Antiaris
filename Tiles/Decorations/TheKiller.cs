using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TerrariaOverhaul;

namespace Antiaris.Tiles.Decorations
{
	public class TheKiller : ModTile
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
                16,
				16
            };
			TileObjectData.newTile.Width = 2; 
			TileObjectData.newTile.Height = 3;
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
				Item.NewItem(i * 16, j * 16, 48, 48, mod.ItemType("TheKiller"), 1, false, 0, false, false);
			}
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
			if(Main.bloodMoon)
				Main.spriteBatch.Draw(mod.GetTexture("Glow/TheKiller_GlowMask"), new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + Zero, new Rectangle(tile.frameX, tile.frameY, 16, Height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }

	    public override void NearbyEffects(int i, int j, bool closer)
        {
            Player player = Main.player[Main.myPlayer];
            float distanceTo = Vector2.Distance(player.Center, new Vector2(i * 16, j * 16));
            float distance = 100.0f; //один фут, примерно
            if ((double)distanceTo <= (double)distance && Main.bloodMoon && !player.GetModPlayer<AntiarisPlayer>(mod).bitesTheDust)
            {
                player.AddBuff(mod.BuffType("BitesTheDust"), 600, true);
            }
        }
	}
}