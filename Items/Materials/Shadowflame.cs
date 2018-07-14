using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Materials
{
    public class Shadowflame : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 26;
            item.rare = 5;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 0, 90);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadowflame");
            DisplayName.AddTranslation(GameCulture.Chinese, "暗影火");
            DisplayName.AddTranslation(GameCulture.Russian, "Теневое пламя");
        }
    }
}
