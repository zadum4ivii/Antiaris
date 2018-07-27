using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Guns
{
    public class FungiBoomgun : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 9;
            item.ranged = true;
            item.width = 66;
            item.height = 28;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.rare = 0;
            item.UseSound = SoundID.Item36;
            item.autoReuse = false;
            item.shoot = 10;
            item.shootSpeed = 3f;
            item.useAmmo = AmmoID.Bullet;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fungi Boomgun");
            Tooltip.SetDefault("Uses bullets as ammo\nShoots spore shrooms that explode into fungus spore");
            DisplayName.AddTranslation(GameCulture.Chinese, "真菌爆破枪");
            Tooltip.AddTranslation(GameCulture.Chinese, "将所有子弹变成蘑菇，蘑菇接触物块后变成会爆炸的真菌孢子");
            DisplayName.AddTranslation(GameCulture.Russian, "Грибная взрывопушка");
            Tooltip.AddTranslation(GameCulture.Russian, "Использует пули в качестве патронов\nВыстреливает споровыми грибами, которые взрываются в грибные споры");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            type = mod.ProjectileType("BulletShroom");
            int numberProjectiles = 3; 
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20)); 
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false; 
        }


        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FlareGun, 1);
            recipe.AddIngredient(ItemID.Boomstick, 1);
            recipe.AddIngredient(ItemID.GlowingMushroom, 15);
            recipe.AddIngredient(ItemID.IronBar, 8);
            recipe.anyIronBar = true;
            recipe.SetResult(this);
            recipe.AddTile(18);
            recipe.AddRecipe();
        }
    }
}
