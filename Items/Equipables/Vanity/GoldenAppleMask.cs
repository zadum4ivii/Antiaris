using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class GoldenAppleMask : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 30;
            item.rare = 1;
            item.vanity = true;
            item.value = Item.sellPrice(0, 1, 0, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Golden Apple Mask");
            Tooltip.SetDefault("'Increases coding abilities and laziness by 10%'");
            DisplayName.AddTranslation(GameCulture.Chinese, "金苹果面具");
            Tooltip.AddTranslation(GameCulture.Chinese, "“编程能力和摸鱼能力增加 10% ！”");
            DisplayName.AddTranslation(GameCulture.Russian, "Маска золотого яблока");
            Tooltip.AddTranslation(GameCulture.Russian, "'Увеличивает умение программирования и лень на 10%'");
        }
    }
}
