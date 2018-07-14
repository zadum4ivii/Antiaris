using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Materials
{
    public class TropicalLeaf : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.rare = 0;
            item.maxStack = 999;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tropical Leaf");
            DisplayName.AddTranslation(GameCulture.Chinese, "热带叶");
            DisplayName.AddTranslation(GameCulture.Russian, "Тропический лист");
        }

        public void OverhaulInit()
        {
            this.SetTag("flammable");
            this.SetTag("floatsInWater");
        }
    }
}
