using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Developers
{
    [AutoloadEquip(EquipType.Legs)]
    public class CookieSamSweatpants : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 14;
            item.rare = 9;
			item.vanity = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("CookieSam's Sweetpants");
            Tooltip.SetDefault("'Great for impersonating devs!'");
            DisplayName.AddTranslation(GameCulture.Russian, "Спортивные штаны CookieSam");
            Tooltip.AddTranslation(GameCulture.Russian, "'Поможет вам выдать себя за разработчика!'");
			DisplayName.AddTranslation(GameCulture.Chinese, "CookieSam运动裤");
            Tooltip.AddTranslation(GameCulture.Chinese, "“非常适合冒充开发者！”");
        }
    }
}
