using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TerrariaOverhaul;

namespace Antiaris.Tiles.Miscellaneous
{
    public class SnowSofa : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Bench");
            name.AddTranslation(GameCulture.Chinese, "长椅");
            name.AddTranslation(GameCulture.Russian, "Скамейка");
            AddMapEntry(new Color(191, 142, 111), name);
        }

        public void OverhaulInit()
        {
            this.SetTag("flammable");
            this.SetTag("coldBiomeRelated");
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 16, ItemID.Sofa, 1, false, 0, false, false);
        }
    }
}