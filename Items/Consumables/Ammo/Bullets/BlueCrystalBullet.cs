using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Bullets
{
    public class BlueCrystalBullet : ModItem
    {
        public override Color? GetAlpha(Color lightColor) { return Color.White; }

        public override void SetDefaults()
        {
            item.damage = 10;
            item.ranged = true;
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.consumable = true;   
            item.knockBack = 2.0f;
            item.value = Item.sellPrice(0, 0, 0, 80);
            item.rare = 5;
            item.shoot = mod.ProjectileType("BlueCrystalBullet");
            item.shootSpeed = 15.0f;             
            item.ammo = AmmoID.Bullet;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blue Crystal Bullet");
            Tooltip.SetDefault("Crazy velocity and infinity piercing");
            DisplayName.AddTranslation(GameCulture.Russian, "Голубая кристальная пуля");
            Tooltip.AddTranslation(GameCulture.Russian, "Безумная скорость и бесконечная пробиваемость");
            DisplayName.AddTranslation(GameCulture.Chinese, "蓝水晶弹");
            Tooltip.AddTranslation(GameCulture.Chinese, "疯狂的攻速和无尽的穿透");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BlueBigCrystal", 1);
            recipe.AddIngredient(ItemID.MusketBall, 100);
            recipe.SetResult(this, 100);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddRecipe();
        }
    }
}
