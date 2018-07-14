using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Materials
{
    public class EnchantedLeaf : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 30;
            item.rare = 0;
            item.maxStack = 999;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enchanted Leaf");
            DisplayName.AddTranslation(GameCulture.Chinese, "附魔叶");
            DisplayName.AddTranslation(GameCulture.Russian, "Зачарованный лист");
        }

        public void OverhaulInit()
        {
            this.SetTag("flammable");
            this.SetTag("floatsInWater");
        }
    }
}
