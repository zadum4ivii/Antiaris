using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Blunderbusses
{
    public class UndyingArmyRifle : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.damage = 19;
            item.ranged = true;
            item.width = 68;
            item.height = 26;
            item.useAnimation = 20;
			item.useTime = 10;
			item.reuseDelay = 14;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.rare = 2;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = 10;
            item.holdStyle = 3;
            item.shootSpeed = 12f;
			item.value = Item.sellPrice(0, 1, 10, 0);
            item.useAmmo = mod.ItemType("Buckshot");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Undying Army Rifle");
            Tooltip.SetDefault("Uses buckshots as ammo\nTwo round burst\nOnly first shot consumes ammo");
            DisplayName.AddTranslation(GameCulture.Chinese, "不朽来福枪");
            Tooltip.AddTranslation(GameCulture.Chinese, "使用火铳弹当做弹药\n发射二连发子弹\n每次只消耗一颗子弹");
            DisplayName.AddTranslation(GameCulture.Russian, "Винтовка бессмертной армии");
            Tooltip.AddTranslation(GameCulture.Russian, "Использует картечь в качестве патронов\nОчередь из двух пуль\nБоеприпасы расходуются только на первый выстрел");
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 35f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
			return true;
		}
    }
}
