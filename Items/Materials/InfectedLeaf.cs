using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Materials
{
    public class InfectedLeaf : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 20;
            item.rare = 0;
            item.maxStack = 999;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infected Leaf");
            DisplayName.AddTranslation(GameCulture.Chinese, "腐化叶");
            DisplayName.AddTranslation(GameCulture.Russian, "Заражённый лист");
        }

        public void OverhaulInit()
        {
            this.SetTag("flammable");
            this.SetTag("floatsInWater");
        }
    }
}
