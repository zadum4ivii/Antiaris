﻿using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Spears
{
	public class PalmWoodSpear : ModItem
	{
	    public override void SetDefaults()
		{
			item.damage = 7;
			item.useStyle = 5;
			item.useAnimation = 28;
			item.useTime = 32;
			item.shootSpeed = 2f;
			item.knockBack = 10f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("PalmWoodSpear");
			item.value = Item.sellPrice(0, 0, 0, 21);
			item.noMelee = true; 
			item.noUseGraphic = true;
			item.melee = true;
			item.autoReuse = false;
		}

	    public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Palm Wood Spear");
            DisplayName.AddTranslation(GameCulture.Chinese, "棕榈木矛");
            DisplayName.AddTranslation(GameCulture.Russian, "Копье из пальмовой древесины");
		}

	    public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalmWood, 9);
            recipe.SetResult(this);
            recipe.AddTile(18);
            recipe.AddRecipe();
        }
	}
}
