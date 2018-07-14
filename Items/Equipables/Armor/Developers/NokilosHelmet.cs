using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Developers
{
    [AutoloadEquip(EquipType.Head)]
    public class NokilosHelmet : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 12;
            item.rare = 9;
			item.vanity = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nokilos' Helmet");
            Tooltip.SetDefault("'Great for impersonating devs!'");
            DisplayName.AddTranslation(GameCulture.Russian, "Шлем Nokilos");
            Tooltip.AddTranslation(GameCulture.Russian, "'Поможет вам выдать себя за разработчика!'");
			DisplayName.AddTranslation(GameCulture.Chinese, "Nokilos的头盔");
            Tooltip.AddTranslation(GameCulture.Chinese, "“非常适合冒充开发者！”");
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("NokilosChestplate") && legs.type == mod.ItemType("NokilosGreaves");
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
        }
    }
}
