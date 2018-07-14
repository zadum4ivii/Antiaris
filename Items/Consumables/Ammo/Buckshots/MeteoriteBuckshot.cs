using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Buckshots
{
    public class MeteoriteBuckshot : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 8;
            item.width = 14;
            item.maxStack = 999;
            item.height = 14;
            item.rare = 1;
            item.ranged = true;
            item.consumable = true;
            item.knockBack = 2f;
            item.value = Item.sellPrice(0, 0, 1, 0);
            item.ammo = mod.ItemType("Buckshot");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meteorite Buckshot");
            Tooltip.SetDefault("Used as ammo for blunderbusses");
            DisplayName.AddTranslation(GameCulture.Chinese, "陨铁火铳弹");
            Tooltip.AddTranslation(GameCulture.Chinese, "用于火铳");
            DisplayName.AddTranslation(GameCulture.Russian, "Метеоритовая картечь");
            Tooltip.AddTranslation(GameCulture.Russian, "Используется как патроны для мушкетонов");
        }

        public override void PickAmmo(Player player, ref int type, ref float speed, ref int damage, ref float knockback)
        {
            type = mod.ProjectileType("MeteoriteBuckshot");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Buckshot", 50);
            recipe.AddIngredient(ItemID.MeteoriteBar, 1);
            recipe.SetResult(this, 50);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
