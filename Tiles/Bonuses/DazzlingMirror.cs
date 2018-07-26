using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Antiaris.Tiles.Bonuses
{
    public class DazzlingMirror : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 36;
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Dazzling Mirror");
            name.AddTranslation(GameCulture.Russian, "Сияющее зеркало");
            name.AddTranslation(GameCulture.Chinese, "璀璨之镜");
            AddMapEntry(new Color(70, 70, 70), name);
            dustType = 53;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            if (frameX == 0)
            {
                Item.NewItem(i * 16, j * 16, 48, 48, mod.ItemType("DazzlingMirror"));
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
            Main.spriteBatch.Draw(mod.GetTexture("Glow/DazzlingMirror_GlowMask"), new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + Zero, new Rectangle(tile.frameX, tile.frameY, 16, Height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {
                Player player = Main.player[Main.myPlayer];
                player.AddBuff(mod.BuffType("MirrorBlessing"), 60, true);
            }
        }
    }
}

