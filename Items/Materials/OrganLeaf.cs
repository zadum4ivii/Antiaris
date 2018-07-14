using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Materials
{
    public class OrganLeaf : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 28;
            item.rare = 0;
            item.maxStack = 999;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Organ Leaf");
            DisplayName.AddTranslation(GameCulture.Chinese, "肝脏叶");
            DisplayName.AddTranslation(GameCulture.Russian, "Лист из органов");
        }

        public void OverhaulInit()
        {
            this.SetTag("flammable");
            this.SetTag("floatsInWater");
        }
    }
}
