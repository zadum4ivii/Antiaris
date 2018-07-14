using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Yoyos
{
	public class Cabal : ModItem
	{
	    public override void SetDefaults()
		{
			item.useStyle = 13;
			item.width = 24;
			item.height = 24;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.shoot = mod.ProjectileType("Cabal1");
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			item.knockBack = 2.5f;
			item.damage = 46;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = 5;
			item.useStyle = 5;
		}

	    public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cabal");
			Tooltip.SetDefault("Throws out two yoyos at the same time");
            DisplayName.AddTranslation(GameCulture.Chinese, "政治阴谋");
			Tooltip.AddTranslation(GameCulture.Chinese, "同时抛出两个yoyo");
            DisplayName.AddTranslation(GameCulture.Russian, "Интрига");
			Tooltip.AddTranslation(GameCulture.Russian, "Выпускает сразу два йо-йо одновременно");
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}

	    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("Cabal2"), damage, knockBack, player.whoAmI);
			return true;
		}

	    public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DarkShard, 1);
			recipe.AddIngredient(ItemID.LightShard, 1);
            recipe.AddIngredient(ItemID.WoodYoyo, 2);
			recipe.AddIngredient(ItemID.SoulofLight, 6);
			recipe.AddIngredient(ItemID.SoulofNight, 6);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
	}
}
