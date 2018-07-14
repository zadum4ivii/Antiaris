using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Materials
{
    public class BlueBigCrystal : ModItem
    {
        public override Color? GetAlpha(Color lightColor) { return Color.White; }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 24;
			item.value = Item.sellPrice(0, 0, 3, 10);
            item.rare = 1;
            item.maxStack = 999;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blue Big Crystal");
            DisplayName.AddTranslation(GameCulture.Russian, "Большой голубой кристалл");
            DisplayName.AddTranslation(GameCulture.Chinese, "蓝水晶");
        }
    }
}
