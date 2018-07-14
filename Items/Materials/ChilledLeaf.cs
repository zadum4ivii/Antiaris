using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Materials
{
    public class ChilledLeaf : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.rare = 0;
            item.maxStack = 999;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chilled Leaf");
            DisplayName.AddTranslation(GameCulture.Chinese, "寒冰叶");
            DisplayName.AddTranslation(GameCulture.Russian, "Замёрзший лист");
        }

        public void OverhaulInit()
        {
            this.SetTag("flammable");
            this.SetTag("floatsInWater");
        }
    }
}
