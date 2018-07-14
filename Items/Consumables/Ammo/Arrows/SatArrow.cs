using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Arrows
{
    public class SatArrow : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 20;
            item.ranged = true;
            item.maxStack = 999;
            item.consumable = true;
            item.height = 50;
            item.width = 18;			
            item.shoot = mod.ProjectileType("SatArrow");
            item.shootSpeed = 12f; 
            item.knockBack = 4;
            item.value = Item.sellPrice(0, 0, 0, 20);
            item.rare = 8;
            item.ammo = AmmoID.Arrow;
        }

        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Sat's Arrow");
			Tooltip.SetDefault("A fastly moving arrow not affected by gravity\nInflicts shadowflame on enemies\nSummons shadow flames if shot from Sat's Bow");
			DisplayName.AddTranslation(GameCulture.Chinese, "Sat的弓箭");
			Tooltip.AddTranslation(GameCulture.Chinese, "1、高速且不受重力影响的弓箭\n2、受到该弓箭攻击的敌人会被暗影火灼烧\n3、如果使用<Sat的弓>接触物体爆炸后会召唤暗影火");
			DisplayName.AddTranslation(GameCulture.Russian, "Стрела Сата");
			Tooltip.AddTranslation(GameCulture.Russian, "Быстро движущаяся стрела, не подверженная гравитации\nНакладывает на врагов теневой огонь\nПризывает теневые огоньки, если выстрелена из Лука Сата");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodenArrow, 333);
            recipe.AddIngredient(null, "Shadowflame");
            recipe.AddIngredient(null, "WrathElement");
            recipe.SetResult(this, 333);
            recipe.AddTile(412);
            recipe.AddRecipe();
        }
    }
}
