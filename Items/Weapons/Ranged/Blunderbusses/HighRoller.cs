using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Blunderbusses
{
    public class HighRoller : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.damage = 22;
            item.width = 68;
            item.height = 28;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 4f;
            item.ranged = true;
            item.value = Item.sellPrice(0, 2, 15, 0);
            item.rare = 3;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = 10;
            item.holdStyle = 3;
            item.shootSpeed = 10f;
			item.useAmmo = mod.ItemType("Buckshot");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("High Roller");
            Tooltip.SetDefault("Uses buckshots as ammo\nTwo round burst with little spread\nBuckshots inflict Despairing Flames\n'It feels flat and very hot, but you can't argue with results'");
            DisplayName.AddTranslation(GameCulture.Chinese, "暴殄天物");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、使用火铳弹作为弹药\n2、发射略微分散的两个火铳弹\n3、火铳弹将附加绝望烈焰\n“It feels flat and very hot, but you can't argue with results”");
            DisplayName.AddTranslation(GameCulture.Russian, "Крупный игрок");
            Tooltip.AddTranslation(GameCulture.Russian, "Использует картечь в качестве патронов\nОчередь из двух пуль с небольшим разбросом\nКартечь поджигает врагов Огнём безысходности\n'Плоский на ощупь и очень горячий, но с результатами не поспоришь'");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 55f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(4));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
			Projectile.NewProjectile(position.X, position.Y - 3f, speedX * 1.2f, speedY * 1.2f, type, damage * 2, knockBack * 2, player.whoAmI);
			Projectile.NewProjectile(position.X - 15f * player.direction, position.Y + 5f, speedX, speedY, type, damage / 2, knockBack / 2, player.whoAmI);
			return false;
		}

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DevilDragon", 1);
            recipe.AddIngredient(null, "UndyingArmyRifle", 1);
            recipe.AddIngredient(null, "CherryBlossom", 1);
			recipe.AddIngredient(null, "BoilingPoint", 1);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();

			recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CrimsonDrake", 1);
            recipe.AddIngredient(null, "UndyingArmyRifle", 1);
            recipe.AddIngredient(null, "CherryBlossom", 1);
			recipe.AddIngredient(null, "BoilingPoint", 1);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
        }
    }
}
