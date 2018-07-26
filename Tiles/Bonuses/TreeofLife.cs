using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TerrariaOverhaul;

namespace Antiaris.Tiles.Bonuses
{
    public class TreeofLife : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 18 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 36;
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Tree of Life");
            name.AddTranslation(GameCulture.Russian, "Дерево жизни");
            name.AddTranslation(GameCulture.Chinese, "生命树");
            AddMapEntry(new Color(40, 101, 13), name);
            dustType = 7;
        }

        public void OverhaulInit()
        {
            this.SetTag("flammable");
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            if (frameX == 0)
            {
                Item.NewItem(i * 16, j * 16, 48, 48, mod.ItemType("TreeofLife"));
            }
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {
                Player player = Main.player[Main.myPlayer];
                player.AddBuff(mod.BuffType("InnerZen"), 60, true);
            }
        }
    }
}


