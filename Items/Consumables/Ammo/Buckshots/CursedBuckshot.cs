using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Buckshots
{
    public class CursedBuckshot : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 14;
            item.width = 18;
            item.maxStack = 999;
            item.height = 18;
            item.rare = 3;
            item.ranged = true;
            item.consumable = true;
            item.knockBack = 1f;
            item.ammo = mod.ItemType("Buckshot");
            item.value = Item.sellPrice(0, 0, 0, 8);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Buckshot");
            Tooltip.SetDefault("Used as ammo for blunderbusses\nDeals 20% of damage to nearby enemies");
            DisplayName.AddTranslation(GameCulture.Chinese, "咒火火铳弹");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、用于火铳\n2、对附近的敌人造成 20% 的伤害");
            DisplayName.AddTranslation(GameCulture.Russian, "Проклятая картечь");
            Tooltip.AddTranslation(GameCulture.Russian, "Используется как патроны для мушкетонов\nНаносит 20% урона ближайшим врагам");
        }

        public override void PickAmmo(Player player, ref int type, ref float speed, ref int damage, ref float knockback)
        {
            type = mod.ProjectileType("CursedBuckshot");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Buckshot", 50);
            recipe.AddIngredient(ItemID.CursedFlame);
            recipe.SetResult(this, 50);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
