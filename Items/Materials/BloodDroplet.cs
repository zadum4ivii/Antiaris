using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Materials
{
    public class BloodDroplet : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.rare = 1;
            item.maxStack = 999;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Droplet");
            DisplayName.AddTranslation(GameCulture.Chinese, "血滴");
            DisplayName.AddTranslation(GameCulture.Russian, "Капля крови");
        }
    }
}
