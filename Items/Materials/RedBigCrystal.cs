using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Materials
{
    public class RedBigCrystal : ModItem
    {
        public override Color? GetAlpha(Color lightColor) { return Color.White; }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 26;
			item.value = Item.sellPrice(0, 0, 3, 10);
            item.rare = 1;
            item.maxStack = 999;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Red Big Crystal");
            DisplayName.AddTranslation(GameCulture.Russian, "Большой красный кристалл");
            DisplayName.AddTranslation(GameCulture.Chinese, "红水晶");
        }
    }
}
