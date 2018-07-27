using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Blunderbusses
{
    public class ThoriumBlunderbuss : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 14;
            item.ranged = true;
            item.width = 62;
            item.height = 28;
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
			item.value = Item.sellPrice(0, 1, 0, 0);
            item.useAmmo = mod.ItemType("Buckshot");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thorium Blunderbuss");
            Tooltip.SetDefault("Uses buckshots as ammo\nShoots a piercing buckshot");
            DisplayName.AddTranslation(GameCulture.Chinese, "瑟银火铳");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、使用火铳弹作为弹药\n2、发射一枚锋利的火铳弹");
            DisplayName.AddTranslation(GameCulture.Russian, "Ториевый мушкетон");
            Tooltip.AddTranslation(GameCulture.Russian, "Использует картечь в качестве патронов\nВыстреливает пробивающей картечью");
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			if (Antiaris.Thorium != null)
            {
                recipe.AddIngredient(Antiaris.Thorium.ItemType("ThoriumBar"), 14);
				recipe.AddIngredient(null, "BlunderbussBase", 1);
				recipe.AddIngredient(ItemID.StoneBlock, 10);
				recipe.SetResult(this);
				recipe.AddTile(16);
				recipe.AddRecipe();
			}
		}
    }
}
