using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Arrows
{
    public class ShadowflameArrow : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 17;
            item.ranged = true;
            item.width = 14;
            item.height = 32;
            item.knockBack = 4;
            item.rare = 5;
			item.maxStack = 999;
			item.consumable = true;
            item.shoot = mod.ProjectileType("ShadowflameArrow");
            item.value = Item.sellPrice(0, 0, 1, 0);
            item.ammo = AmmoID.Arrow;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadowflame Arrow");
            DisplayName.AddTranslation(GameCulture.Chinese, "暗影火箭");
            DisplayName.AddTranslation(GameCulture.Russian, "Стрела теневого пламени");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenArrow, 44);
            recipe.AddIngredient(null, "Shadowflame");
            recipe.SetResult(this, 44);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
