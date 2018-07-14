using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Buckshots
{
    public class PlatinumBuckshot : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 7;
            item.width = 14;
            item.maxStack = 999;
            item.height = 14;
            item.rare = 0;
            item.ranged = true;
            item.consumable = true;
            item.knockBack = 2f;
            item.ammo = mod.ItemType("Buckshot");
            item.value = Item.sellPrice(0, 0, 1, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Platinum Buckshot");
            Tooltip.SetDefault("Used as ammo for blunderbusses");
            DisplayName.AddTranslation(GameCulture.Chinese, "铂金火铳弹");
            Tooltip.AddTranslation(GameCulture.Chinese, "用于火铳");
            DisplayName.AddTranslation(GameCulture.Russian, "Платиновая картечь");
            Tooltip.AddTranslation(GameCulture.Russian, "Используется как патроны для мушкетонов");
        }

        public override void PickAmmo(Player player, ref int type, ref float speed, ref int damage, ref float knockback)
        {
            type = mod.ProjectileType("PlatinumBuckshot");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Buckshot", 50);
            recipe.AddIngredient(ItemID.PlatinumBar, 1);
            recipe.SetResult(this, 50);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
