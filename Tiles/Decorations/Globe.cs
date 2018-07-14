using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TerrariaOverhaul;

namespace Antiaris.Tiles.Decorations
{
    public class Globe : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 36;
            TileObjectData.addTile(Type);
            dustType = 7;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Globe");
            name.AddTranslation(GameCulture.Chinese, "地球仪");
            name.AddTranslation(GameCulture.Russian, "Глобус");
            AddMapEntry(new Color(120, 85, 60), name);
        }

        public void OverhaulInit()
        {
            this.SetTag("flammable");
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            if (frameX == 0)
            {
                Item.NewItem(i * 16, j * 16, 48, 48, mod.ItemType("Globe"));
            }
        }
    }
}