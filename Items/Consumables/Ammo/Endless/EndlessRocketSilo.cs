using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Endless
{
    public class EndlessRocketSilo : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 40;
            item.ranged = true;
            item.maxStack = 1;
            item.consumable = false;
            item.height = 36;
            item.width = 38;			
            item.shoot = 0;
            item.shootSpeed = 5f; 
            item.knockBack = 4;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 2;
            item.ammo = 771;
        }

        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Endless Rocket Silo");
			DisplayName.AddTranslation(GameCulture.Chinese, "无尽火箭箱");
			DisplayName.AddTranslation(GameCulture.Russian, "Бесконечный комплект ракет");
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RocketI, 3996);
            recipe.SetResult(this);
            recipe.AddTile(125);
            recipe.AddRecipe();
        }
    }
}
