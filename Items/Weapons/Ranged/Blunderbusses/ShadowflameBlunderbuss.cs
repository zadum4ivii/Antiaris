using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Blunderbusses
{
    public class ShadowflameBlunderbuss : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.damage = 33;
            item.ranged = true;
            item.width = 100;
            item.height = 48;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 3;
            item.rare = 5;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = 10;
            item.holdStyle = 3;
            item.shootSpeed = 12f;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.useAmmo = mod.ItemType("Buckshot");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadowflame Blunderbuss");
            Tooltip.SetDefault("Uses buckshots as ammo\nShoots out shadowflame buckshots");
            DisplayName.AddTranslation(GameCulture.Chinese, "暗影火火铳");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、使用火铳弹当做弹药\n2、发射暗影火火铳弹");
            DisplayName.AddTranslation(GameCulture.Russian, "Мушкетон теневого пламени");
            Tooltip.AddTranslation(GameCulture.Russian, "Использует картечь в качестве патронов\nВыстреливает картечью теневого пламени");
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-9, -3);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 110f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}	
			type = mod.ProjectileType("ShadowflameBuckshot");
			return true;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BlunderbussBase", 1);
            recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddIngredient(null, "Shadowflame", 10);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
