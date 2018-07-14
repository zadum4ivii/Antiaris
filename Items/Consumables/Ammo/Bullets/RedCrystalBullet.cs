using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Bullets
{
    public class RedCrystalBullet : ModItem
    {
        public override Color? GetAlpha(Color lightColor) { return Color.White; }

        public override void SetDefaults()
        {
            item.damage = 18;
            item.ranged = true;
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.consumable = true;   
            item.knockBack = 7.0f;
            item.value = Item.sellPrice(0, 0, 0, 80);
            item.rare = 5;
            item.shoot = mod.ProjectileType("RedCrystalBullet");
            item.shootSpeed = 6.0f;             
            item.ammo = AmmoID.Bullet;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Red Crystal Bullet");
            Tooltip.SetDefault("More power at the cost of piercing ability");
            DisplayName.AddTranslation(GameCulture.Russian, "Красная кристальная пуля");
            Tooltip.AddTranslation(GameCulture.Russian, "Больше силы, но меньше пробиваемости");
            DisplayName.AddTranslation(GameCulture.Chinese, "红水晶弹");
            Tooltip.AddTranslation(GameCulture.Chinese, "以穿透力为代价的更高伤害");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "RedBigCrystal", 1);
            recipe.AddIngredient(ItemID.MusketBall, 100);
            recipe.SetResult(this, 100);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddRecipe();
        }
    }
}
