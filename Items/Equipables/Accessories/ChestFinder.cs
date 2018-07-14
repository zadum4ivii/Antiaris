using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    public class ChestFinder : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 26;
            item.rare = 3;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chest Finder");
            Tooltip.SetDefault("Reveals nearby wooden and gold chests on map when worn");
            DisplayName.AddTranslation(GameCulture.Chinese, "箱子搜寻者");
            Tooltip.AddTranslation(GameCulture.Chinese, "显示附近的木箱子和金箱子");
            DisplayName.AddTranslation(GameCulture.Russian, "Поисковик сундуков");
            Tooltip.AddTranslation(GameCulture.Russian, "Когда надет, отображает ближайшие деревянные и золотые сундуки на карте");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
            aPlayer.foundChest = true;
        }

        public override void UpdateInventory(Player player)
        {
            var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
            aPlayer.foundChest = true;
        }
    }
}