using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    public class CelestialManual : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 36;
            item.rare = 4;
            item.value = Item.sellPrice(0, 15, 0, 0);
            item.accessory = true;
            item.defense = 2;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Celestial Manual");
            Tooltip.SetDefault("Using Adventurer's symbols will restore life");
            DisplayName.AddTranslation(GameCulture.Chinese, "神圣手册");
            Tooltip.AddTranslation(GameCulture.Chinese, "使用“特殊能力”类型的饰品将回复生命值");
            DisplayName.AddTranslation(GameCulture.Russian, "Небесное руководство");
            Tooltip.AddTranslation(GameCulture.Russian, "Использование символов Путешественника восстановит здоровье");
        }
    }
}