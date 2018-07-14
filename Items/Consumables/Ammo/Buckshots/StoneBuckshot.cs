using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Buckshots
{
    public class StoneBuckshot : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 3;
            item.width = 14;
            item.maxStack = 999;
            item.height = 14;
            item.rare = 0;
            item.ranged = true;
            item.consumable = true;
            item.knockBack = 2f;
            item.ammo = mod.ItemType("Buckshot");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone Buckshot");
            Tooltip.SetDefault("Used as ammo for blunderbusses");
            DisplayName.AddTranslation(GameCulture.Chinese, "石质火铳弹");
            Tooltip.AddTranslation(GameCulture.Chinese, "用于火铳");
            DisplayName.AddTranslation(GameCulture.Russian, "Каменная картечь");
            Tooltip.AddTranslation(GameCulture.Russian, "Используется как патроны для мушкетонов");
        }

        public override void PickAmmo(Player player, ref int type, ref float speed, ref int damage, ref float knockback)
        {
            type = mod.ProjectileType("StoneBuckshot");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 1);
            recipe.SetResult(this, 7);
            recipe.AddTile(18);
            recipe.AddRecipe();
        }
    }
}
