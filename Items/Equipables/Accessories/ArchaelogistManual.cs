using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    public class ArchaelogistManual : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 36;
            item.rare = 4;
            item.value = Item.sellPrice(0, 25, 0, 0);
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Archaelogist's Manual");
            Tooltip.SetDefault("Grants immunity to traps damage");
            DisplayName.AddTranslation(GameCulture.Chinese, "考古学家的指南手册");
            Tooltip.AddTranslation(GameCulture.Chinese, "减少陷阱所对你造成的伤害");
            DisplayName.AddTranslation(GameCulture.Russian, "Руководство археолога");
            Tooltip.AddTranslation(GameCulture.Russian, "Даёт иммунитет к урону от ловушек");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            AntiarisPlayer.TrapsImmune = true;
        }

        public override void UpdateInventory(Player player)
        {
            AntiarisPlayer.TrapsImmune = true;
        }
    }
}