using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace Antiaris.Items.Equipables.Armor.Developers
{
    [AutoloadEquip(new EquipType[] { EquipType.Legs })]
    public class ZerokkGreaves : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.rare = 9;
			item.vanity = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zerokk's Greaves");
            Tooltip.SetDefault("'Great for impersonating former developers!'");
            DisplayName.AddTranslation(GameCulture.Russian, "Поножи Zerokk");
            Tooltip.AddTranslation(GameCulture.Russian, "'Поможет вам выдать себя за бывшего разработчика!'");
			DisplayName.AddTranslation(GameCulture.Chinese, "Zerokk的护胫甲");
            Tooltip.AddTranslation(GameCulture.Chinese, "“非常适合冒充前任开发者！”");
        }
    }
}
