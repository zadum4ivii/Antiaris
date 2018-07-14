using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Dyes
{
    public class GooDye : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.rare = 2;
            item.value = Item.sellPrice(0, 1, 35, 0);
            item.maxStack = 99;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Goo Dye");
            DisplayName.AddTranslation(GameCulture.Chinese, "凝胶染料");
            DisplayName.AddTranslation(GameCulture.Russian, "Краситель из слизи");
        }
    }
}
