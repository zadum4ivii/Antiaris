using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class BearMask : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 226;
            item.rare = 1;
            item.vanity = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bear Mask");
            DisplayName.AddTranslation(GameCulture.Chinese, "熊面具");
            DisplayName.AddTranslation(GameCulture.Russian, "Маска медведя");
        }
    }
}
