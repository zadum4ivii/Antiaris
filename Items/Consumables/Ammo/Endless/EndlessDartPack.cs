using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Endless
{
    public class EndlessDartPack : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 10;
            item.ranged = true;
            item.maxStack = 1;
            item.consumable = false;
            item.height = 22;
            item.width = 26;			
            item.shoot = 267;
            item.shootSpeed = 5f; 
            item.knockBack = 4;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 2;
            item.ammo = AmmoID.Dart;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endless Dart Pack");
            DisplayName.AddTranslation(GameCulture.Chinese, "无尽飞镖包");
            DisplayName.AddTranslation(GameCulture.Russian, "Бесконечный комплект дротиков");
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PoisonDart, 3996);
            recipe.SetResult(this);
            recipe.AddTile(125);
            recipe.AddRecipe();
        }
    }
}
