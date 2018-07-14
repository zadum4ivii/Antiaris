using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Materials
{
    public class Leaf : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 20;
            item.rare = 0;
            item.maxStack = 999;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Leaf");
            DisplayName.AddTranslation(GameCulture.Chinese, "叶子");
            DisplayName.AddTranslation(GameCulture.Russian, "Лист");
        }

        public void OverhaulInit()
        {
            this.SetTag("flammable");
            this.SetTag("floatsInWater");
        }
    }
}
