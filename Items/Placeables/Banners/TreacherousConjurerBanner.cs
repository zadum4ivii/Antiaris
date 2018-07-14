using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables.Banners
{
    public class TreacherousConjurerBanner : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 28;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 1;
            item.value = Item.buyPrice(0, 0, 10, 0);
            item.createTile = mod.TileType("Banners");
            item.placeStyle = 19;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treacherous Conjurer Banner");
			Tooltip.SetDefault("Nearby players get a bonus against: Treacherous Conjurer");
            DisplayName.AddTranslation(GameCulture.Chinese, "千瞬巫师旗");
			Tooltip.AddTranslation(GameCulture.Chinese, "附近的玩家针对以下情况获得奖励：千瞬巫师");
            DisplayName.AddTranslation(GameCulture.Russian, "Знамя коварного заклинателя");
			
			Tooltip.AddTranslation(GameCulture.Russian, "Игроки поблизости получают бонус против: Коварный заклинатель");
        }
    }
}
