using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class CookMask : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 36;
            item.rare = 1;
            item.vanity = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cook Mask");
            DisplayName.AddTranslation(GameCulture.Chinese, "厨师面具");
            DisplayName.AddTranslation(GameCulture.Russian, "Маска повара");
        }
    }
}
