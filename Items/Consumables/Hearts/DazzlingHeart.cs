using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Hearts
{
    public class DazzlingHeart : ModItem
    {
        public override void SetDefaults()
        {
            item.maxStack = 99;
            item.width = 24;
            item.height = 20;
            item.useStyle = 4;
            item.useTime = 30;
            item.useAnimation = 30;
            item.UseSound = SoundID.Item4;
            item.consumable = true;
            item.rare = 5;
            item.value = Item.sellPrice(0, 1, 90, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dazzling Heart");
            Tooltip.SetDefault("Permanently increases maximum life by 5");
            DisplayName.AddTranslation(GameCulture.Russian, "Сияющее сердце");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает максимальное количество жизней на 5");
            DisplayName.AddTranslation(GameCulture.Chinese, "璀璨之心");
            Tooltip.AddTranslation(GameCulture.Chinese, "增加5点最大生命值");
        }
    }
}
