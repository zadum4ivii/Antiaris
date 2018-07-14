using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Ranged.Blunderbusses
{
    public class TrueHallowedBlunderbuss : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.damage = 69;
            item.ranged = true;
            item.width = 80;
            item.height = 32;
            item.useTime = 34;
            item.useAnimation = 34;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 7f;
            item.rare = 8;
            item.value = Item.sellPrice(0, 11, 25, 45);
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = 10;
            item.holdStyle = 3;
            item.shootSpeed = 13f;
            item.useAmmo = mod.ItemType("Buckshot");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Hallowed Blunderbuss");
            Tooltip.SetDefault("Uses buckshots as ammo\n<right> to zoom out\n50% chance to not consume ammo\nHas a chance to shoot a true buckshot that increases critical strike chance and damage for ranged weapons");
            DisplayName.AddTranslation(GameCulture.Chinese, "真·神圣火铳");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、使用火铳弹当做弹药 \n2、<right> 键观察远处。 \n3、50%的几率不消耗弹药\n4、有概率发射出觉醒之弹，增加远程武器的致命一击率和伤害");
            DisplayName.AddTranslation(GameCulture.Russian, "Истинный Святой мушкетон");
            Tooltip.AddTranslation(GameCulture.Russian, "Использует картечь в качестве патронов\nright> для приближения\n50% шанс не потратить пулю\nИмеет шанс выпустить истинную картечь, которая увеличит шанс нанесения и показатель критического урона");
        }

        public void OverhaulInit()
        {
            this.SetTag("holyDamage");
        }

        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .50f;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 85f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
            if (Main.rand.Next(3) == 0)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX * 1.4f, speedY * 1.4f, mod.ProjectileType("TrueBuckshot1"), damage + 15, knockBack + 2.0f, player.whoAmI);
                return false;
            }
            return true;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HallowedBlunderbuss", 1);
            recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
