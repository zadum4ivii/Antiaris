using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Developers
{
    [AutoloadEquip(EquipType.Head)]
    public class Zadum4iviiStylishHairstyle : ModItem
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
            DisplayName.SetDefault("Zadum4ivii's Stylish Hairstyle");
            Tooltip.SetDefault("'Great for impersonating devs!'");
            DisplayName.AddTranslation(GameCulture.Russian, "Стильная причёска Zadum4ivii");
            Tooltip.AddTranslation(GameCulture.Russian, "'Поможет вам выдать себя за разработчика!'");
			DisplayName.AddTranslation(GameCulture.Chinese, "Zadum4ivii的时尚发型");
            Tooltip.AddTranslation(GameCulture.Chinese, "“非常适合冒充开发者！”");
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("Zadum4iviiStylishJacket") && legs.type == mod.ItemType("Zadum4iviiStylishPants");
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlines = true;
			Lighting.AddLight((int)player.Center.X / 16, (int)player.Center.Y / 16, 0.8f, 0f, 0.8f);
        }
    }
}
