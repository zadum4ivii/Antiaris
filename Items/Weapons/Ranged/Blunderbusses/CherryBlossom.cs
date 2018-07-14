using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Blunderbusses
{
    public class CherryBlossom : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 19;
            item.ranged = true;
            item.width = 68;
            item.height = 26;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.rare = 3;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = 10;
            item.holdStyle = 3;
            item.shootSpeed = 12f;
			item.value = Item.sellPrice(0, 0, 65, 0);
            item.useAmmo = mod.ItemType("Buckshot");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cherry Blossom");
            Tooltip.SetDefault("Uses buckshots as ammo\nBuckshots poison enemies");
            DisplayName.AddTranslation(GameCulture.Chinese, "樱花");
            Tooltip.AddTranslation(GameCulture.Chinese, "使用火铳弹当做弹药\n发射可以使敌人中毒的火铳弹");
            DisplayName.AddTranslation(GameCulture.Russian, "Цветущая вишня");
            Tooltip.AddTranslation(GameCulture.Russian, "Использует картечь в качестве патронов\nКартечь отравляет врагов");
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 65f;
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
            recipe.AddIngredient(ItemID.Stinger, 12);
			recipe.AddIngredient(ItemID.JungleSpores, 8);
			recipe.AddIngredient(null, "NatureEssence", 10);
            recipe.SetResult(this);
            recipe.AddTile(18);
            recipe.AddRecipe();
        }
    }
}
