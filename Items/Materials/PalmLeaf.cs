using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Materials
{
    public class PalmLeaf : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.rare = 0;
            item.maxStack = 999;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Palm Leaf");
            DisplayName.AddTranslation(GameCulture.Chinese, "棕榈叶");
            DisplayName.AddTranslation(GameCulture.Russian, "Пальмовый лист");
        }

        public void OverhaulInit()
        {
            this.SetTag("flammable");
            this.SetTag("floatsInWater");
        }
    }
}
