using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Bullets
{
    public class PurpleCrystalBullet : ModItem
    {
        public override Color? GetAlpha(Color lightColor) { return Color.White; }

        public override void SetDefaults()
        {
            item.damage = 11;
            item.ranged = true;
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.consumable = true;   
            item.knockBack = 5.0f;
            item.value = Item.sellPrice(0, 0, 0, 80);
            item.rare = 5;
            item.shoot = mod.ProjectileType("PurpleCrystalBullet");
            item.shootSpeed = 8.0f;             
            item.ammo = AmmoID.Bullet;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Purple Crystal Bullet");
            Tooltip.SetDefault("Splits into two bullets flying in a random direction");
            DisplayName.AddTranslation(GameCulture.Russian, "Фиолетовая кристальная пуля");
            Tooltip.AddTranslation(GameCulture.Russian, "Разрывается в две пули, летящие в случайном направлении");
            DisplayName.AddTranslation(GameCulture.Chinese, "紫水晶弹");
            Tooltip.AddTranslation(GameCulture.Chinese, "可以分裂成两个随机方向飞行的子弹");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PurpleBigCrystal", 1);
            recipe.AddIngredient(ItemID.MusketBall, 100);
            recipe.SetResult(this, 100);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddRecipe();
        }
    }
}
