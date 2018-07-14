using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Yoyos
{
	public class GooYoyo : ModItem
	{
	    public override void SetDefaults()
		{
			item.useStyle = 13;
			item.width = 30;
			item.height = 26;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.shoot = mod.ProjectileType("GooYoyo");
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			item.knockBack = 2.5f;
			item.damage = 12;
			item.value = Item.sellPrice(0, 0, 20, 0);
			item.rare = 2;
			item.useStyle = 5;
		}

	    public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Goo Yoyo");
            DisplayName.AddTranslation(GameCulture.Chinese, "凝胶球");
            DisplayName.AddTranslation(GameCulture.Russian, "Йо-йо из слизи");
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}

	    public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "LiquifiedGoo", 1);
            recipe.AddIngredient(3278, 1);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
	}
}
