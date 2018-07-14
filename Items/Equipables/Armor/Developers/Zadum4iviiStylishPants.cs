using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Developers
{
    [AutoloadEquip(EquipType.Legs)]
    public class Zadum4iviiStylishPants : ModItem
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
            DisplayName.SetDefault("Zadum4ivii's Stylish Pants");
            Tooltip.SetDefault("'Great for impersonating devs!'");
            DisplayName.AddTranslation(GameCulture.Russian, "Стильные брюки Zadum4ivii");
            Tooltip.AddTranslation(GameCulture.Russian, "'Поможет вам выдать себя за разработчика!'");
			DisplayName.AddTranslation(GameCulture.Chinese, "Zadum4ivii时尚裤子");
            Tooltip.AddTranslation(GameCulture.Chinese, "“非常适合冒充开发者！”");
        }
    }
}
