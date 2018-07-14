using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Ranged.Blunderbusses
{
    public class CrimsonDrake : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 17;
            item.ranged = true;
            item.width = 66;
            item.height = 26;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.rare = 1;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = 10;
            item.holdStyle = 3;
            item.shootSpeed = 65f;
			item.value = Item.sellPrice(0, 0, 50, 0);
            item.useAmmo = mod.ItemType("Buckshot");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crimson Drake");
            Tooltip.SetDefault("Uses buckshots as ammo\nFires two buckshots");
            DisplayName.AddTranslation(GameCulture.Chinese, "血腥德雷克");
            Tooltip.AddTranslation(GameCulture.Chinese, "使用火铳弹当做弹药\n发射两个火铳弹");
            DisplayName.AddTranslation(GameCulture.Russian, "Багряный дракон");
            Tooltip.AddTranslation(GameCulture.Russian, "Использует картечь в качестве патронов\nВыстреливает двумя картечами");
        }

        public void OverhaulInit()
        {
            this.SetTag("unholyDamage");
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-9, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			float numberProjectiles = 2;
			float rotation = MathHelper.ToRadians(5);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BlunderbussBase", 1);
            recipe.AddIngredient(ItemID.CrimtaneBar, 10);
			recipe.AddIngredient(ItemID.TissueSample, 10);
            recipe.SetResult(this);
            recipe.AddTile(18);
            recipe.AddRecipe();
        }
    }
}
