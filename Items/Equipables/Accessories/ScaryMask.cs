using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    [AutoloadEquip(EquipType.Neck)]
    public class ScaryMask : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 30;
            item.rare = 5;
            item.value = Item.sellPrice(0, 18, 0, 0);
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scary Mask");
            Tooltip.SetDefault("Increases minion size by 150%\n10% increased minion damage");
            DisplayName.AddTranslation(GameCulture.Chinese, "惊惧之相");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、增加 150% 召唤物大小\n2、增加 10% 召唤物伤害");
            DisplayName.AddTranslation(GameCulture.Russian, "Страшная маска");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает размер миньонов на 150%\nУвеличивает урон миньонов на 10%");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
            player.minionDamage += 0.1f;
            aPlayer.bigMinions = true;
        }
    }
}
