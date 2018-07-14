using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.RocketLaunchers
{
    public class Bonebardier : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 48;
            item.ranged = true;
            item.width = 64;
            item.height = 30;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 9;
            item.rare = 8;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = 134;
            item.shootSpeed = 7f;
            item.useAmmo = AmmoID.Rocket;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bonebardier");
            Tooltip.SetDefault("Uses rockets as ammo\nRockets that are shoot out from Bonebardier explode into several damaging bones");
            DisplayName.AddTranslation(GameCulture.Chinese, "骸骨炮兵");
            DisplayName.AddTranslation(GameCulture.Russian, "Костордир");
            Tooltip.AddTranslation(GameCulture.Russian, "Использует ракеты в качестве патронов\nРакеты, выстреленные из Костордира, взрываются в несколько наносящих урон костей");
			Tooltip.AddTranslation(GameCulture.Chinese, "1、使用火箭作为弹药\n2、骸骨炮兵发射的火箭爆炸后会分裂成几个有杀伤性的骸骨");
			
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true;
		}

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BonebardierBlueprint", 1);
            recipe.AddIngredient(ItemID.Bone, 45);
			recipe.AddIngredient(ItemID.IronBar, 12);
			recipe.anyIronBar = true;
			recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
