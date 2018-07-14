using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Buckshots
{
    public class Buckshot : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 4;
            item.width = 14;
            item.maxStack = 999;
            item.height = 14;
            item.rare = 0;
            item.ranged = true;
            item.consumable = true;
            item.knockBack = 1.4f;
            item.ammo = mod.ItemType("Buckshot");
            item.value = Item.sellPrice(0, 0, 0, 4);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Buckshot");
            Tooltip.SetDefault("Used as ammo for blunderbusses");
            DisplayName.AddTranslation(GameCulture.Chinese, "火铳弹");
            Tooltip.AddTranslation(GameCulture.Chinese, "用于火铳");
            DisplayName.AddTranslation(GameCulture.Russian, "Картечь");
            Tooltip.AddTranslation(GameCulture.Russian, "Используется как патроны для мушкетонов");
        }

        public override void PickAmmo(Player player, ref int type, ref float speed, ref int damage, ref float knockback)
        {
            type = mod.ProjectileType("Buckshot");
        }
    }
}
