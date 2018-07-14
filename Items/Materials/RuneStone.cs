using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Materials
{
    public class RuneStone : ModItem
    {
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 34;
            item.rare = 1;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 3, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rune Stone");
            DisplayName.AddTranslation(GameCulture.Chinese, "符文石");
            DisplayName.AddTranslation(GameCulture.Russian, "Рунный камень");
        }
    }
}
