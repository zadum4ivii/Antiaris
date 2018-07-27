using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Guns
{
    public class RoyalCannon : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 17;
            item.ranged = true;
            item.width = 76;
            item.height = 28;
            item.useTime = 25;
            item.useAnimation = 25;
            item.shoot = mod.ProjectileType("RoyalCannonball");
            item.shootSpeed = 15f;
            item.useStyle = 5;
            item.knockBack = 6;
            item.value = Item.sellPrice(0, 15, 0, 0);
            item.rare = 2;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Royal Cannon");
            DisplayName.AddTranslation(GameCulture.Chinese, "皇家加农炮");
            DisplayName.AddTranslation(GameCulture.Russian, "Королевская пушка");
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "RoyalWeaponParts", 6);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
