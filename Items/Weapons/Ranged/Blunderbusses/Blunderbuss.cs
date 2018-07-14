using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Blunderbusses
{
    public class Blunderbuss : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 5;
            item.ranged = true;
            item.width = 58;
            item.height = 16;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.rare = 0;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = 10;
            item.holdStyle = 3;
            item.shootSpeed = 12f;
            item.useAmmo = mod.ItemType("Buckshot");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blunderbuss");
            Tooltip.SetDefault("Uses buckshots as ammo");
            DisplayName.AddTranslation(GameCulture.Chinese, "火铳");
            Tooltip.AddTranslation(GameCulture.Chinese, "使用火铳弹当做弹药");
            DisplayName.AddTranslation(GameCulture.Russian, "Мушкетон");
            Tooltip.AddTranslation(GameCulture.Russian, "Использует картечь в качестве патронов");
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 50f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BlunderbussBase", 1);
            recipe.AddIngredient(ItemID.StoneBlock, 15);
            recipe.SetResult(this);
            recipe.AddTile(18);
            recipe.AddRecipe();
        }
    }
}
