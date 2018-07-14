using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    public class SwordsmanGuide : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 30;
            item.rare = 1;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Swordsman Guide");
            Tooltip.SetDefault("Grants autoswing for all swords");
            DisplayName.AddTranslation(GameCulture.Chinese, "剑客手册");
            Tooltip.AddTranslation(GameCulture.Chinese, "允许连续挥动所有的剑");
            DisplayName.AddTranslation(GameCulture.Russian, "Пособие мечника");
            Tooltip.AddTranslation(GameCulture.Russian, "Даёт автоатаку всем мечам");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AntiarisPlayer>(mod).SwordsmanGuide = true;
        }
    }
}
