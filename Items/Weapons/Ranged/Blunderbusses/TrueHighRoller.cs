using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Blunderbusses
{
    public class TrueHighRoller : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.damage = 46;
            item.width = 72;
            item.height = 32;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 5f;
            item.ranged = true;
            item.value = Item.sellPrice(0, 9, 15, 10);
            item.rare = 8;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = 10;
            item.holdStyle = 3;
            item.shootSpeed = 10f;
			item.useAmmo = mod.ItemType("Buckshot");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True High Roller");
            Tooltip.SetDefault("Uses buckshots as ammo\nTwo round burst with little spread\nBuckshots inflict Despairing Flames\nHas a chance to shoot a true buckshot that increases ranged damage");
            DisplayName.AddTranslation(GameCulture.Chinese, "真·暴殄天物");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、使用火铳弹作为弹药\n2、发射略微分散的两个火铳弹\n3、火铳弹将附加绝望烈焰\n4、有概率发射出觉醒之弹，增加远程武器的伤害");
            DisplayName.AddTranslation(GameCulture.Russian, "Истинный Крупный игрок");
            Tooltip.AddTranslation(GameCulture.Russian, "Использует картечь в качестве патронов\nОчередь из двух пуль с небольшим разбросом\nКартечь поджигает врагов Огнём безысходности\nИмеет шанс выпустить истинную картечь, которая увеличит дальний урон");        
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 50f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(4));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            if (Main.rand.Next(3) == 0)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX * 1.4f, speedY * 1.4f, mod.ProjectileType("TrueBuckshot2"), damage + 15, knockBack + 2.0f, player.whoAmI);
            }
            else
            {
                Projectile.NewProjectile(position.X, position.Y - 3f, speedX * 1.2f, speedY * 1.2f, type, damage * 2, knockBack * 2, player.whoAmI);
                Projectile.NewProjectile(position.X - 15f * player.direction, position.Y + 5f, speedX, speedY, type, damage / 2, knockBack / 2, player.whoAmI);
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
            recipe.AddIngredient(null, "HighRoller", 1);
            recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
