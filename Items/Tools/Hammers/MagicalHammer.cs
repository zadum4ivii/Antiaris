using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Tools.Hammers
{
    public class MagicalHammer : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 5;
            item.melee = true;
            item.width = 36;
            item.height = 36;
            item.useTime = 35;
            item.useAnimation = 35;
            item.useStyle = 1;
            item.knockBack = 10;
            item.value = Item.sellPrice(0, 0, 0, 0);
            item.rare = 0;
			item.hammer = 20;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magical Hammer");
            DisplayName.AddTranslation(GameCulture.Russian, "Магический молоток");
            DisplayName.AddTranslation(GameCulture.Chinese, "神奇小锤");
            Tooltip.SetDefault("Can be used to make a tool kit\n'Oddly but it doesn't look magical at all.'");
            Tooltip.AddTranslation(GameCulture.Chinese, "可以用于制作工具包\n“这根本不神奇！”");
            Tooltip.AddTranslation(GameCulture.Russian, "Может использоваться для создания набора инструментов\n'Странно, но он вообще не выглядит магическим.'");
        }

        public void OverhaulInit()
        {
            this.SetTag("hammer");
        }
    }
}
