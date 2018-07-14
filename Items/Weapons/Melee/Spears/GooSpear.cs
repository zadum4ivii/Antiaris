using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Spears
{
	public class GooSpear : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 15;
			item.useStyle = 5;
			item.useAnimation = 18;
			item.useTime = 24;
			item.shootSpeed = 4f;
			item.knockBack = 10f;
			item.width = 38;
			item.height = 38;
			item.scale = 1f;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("GooSpear");
			item.value = Item.sellPrice(0, 0, 14, 0);
			item.noMelee = true; 
			item.noUseGraphic = true;
			item.melee = true;
            item.autoReuse = false;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Goo Spear");
            DisplayName.AddTranslation(GameCulture.Chinese, "凝胶矛");
            DisplayName.AddTranslation(GameCulture.Russian, "Копье из слизи");
		}
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "LiquifiedGoo", 1);
            recipe.AddRecipeGroup("Antiaris:WoodenSpear");
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
	}
}
