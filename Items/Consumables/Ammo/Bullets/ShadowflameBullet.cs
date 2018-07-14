using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Bullets
{
    public class ShadowflameBullet : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 13;
            item.ranged = true;
            item.width = 12;
            item.height = 12;
            item.knockBack = 4;
            item.rare = 5;
			item.maxStack = 999;
			item.consumable = true;
            item.shoot = mod.ProjectileType("ShadowflameBullet");
			item.shootSpeed = 5f;
            item.value = Item.sellPrice(0, 0, 1, 0);
            item.ammo = AmmoID.Bullet;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadowflame Bullet");
            DisplayName.AddTranslation(GameCulture.Chinese, "暗影火弹");
            DisplayName.AddTranslation(GameCulture.Russian, "Пуля теневого пламени");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MusketBall, 70);
            recipe.AddIngredient(null, "Shadowflame");
            recipe.SetResult(this, 70);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
