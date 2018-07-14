using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Spears
{
	public class TrueDarkLance : ModItem
	{
	    public override void SetDefaults()
		{
            item.useStyle = 5;
            item.useAnimation = 16;
            item.useTime = 16;
            item.shootSpeed = 5.6f;
            item.knockBack = 5.8f;
            item.width = 56;
            item.height = 56;
            item.damage = 56;
            item.scale = 1.1f;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("TrueDarkLance");
            item.rare = 8;
            item.value = Item.sellPrice(0, 11, 25, 45);
            item.noMelee = true;
            item.noUseGraphic = true;
            item.melee = true;
        }

	    public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Dark Lance");
			DisplayName.AddTranslation(GameCulture.Chinese, "真·暗黑长戟");
            DisplayName.AddTranslation(GameCulture.Russian, "Истинная Тёмная пика");
        }

	    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 vector2 = new Vector2(speedX, speedY).RotatedByRandom((double)MathHelper.ToRadians(7.0f));
            speedX = vector2.X;
            speedY = vector2.Y;
            Projectile.NewProjectile(position.X, position.Y, speedX * 1.6f, speedY * 1.6f, type, damage, knockBack, player.whoAmI, 0.0f, 0.0f);
            return false;
        }

	    public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DarkLance);
            recipe.AddIngredient(ItemID.BrokenHeroSword);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
	}
}
