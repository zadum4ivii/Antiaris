using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Thrown
{
    public class RoyalDagger : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 17;
            item.thrown = true;
            item.width = 14;
            item.height = 32;
            item.noUseGraphic = true;
            item.useTime = 10;
            item.reuseDelay = 19;
            item.useAnimation = 20;
            item.shoot = mod.ProjectileType("RoyalDagger");
            item.shootSpeed = 14f;
            item.useStyle = 1;
            item.knockBack = 3.5f;
            item.value = Item.sellPrice(0, 15, 0, 0);
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;			
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Royal Dagger");
            DisplayName.AddTranslation(GameCulture.Russian, "Королевский нож");
            DisplayName.AddTranslation(GameCulture.Chinese, "皇家飞刀");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、抛出两个击中敌人会反弹的飞刀\n2、被其击中的敌人施加一个Debuff，获得Debuff后被击杀的敌人掉落的钱币更多");
            Tooltip.SetDefault("Shoots out two daggers that can bounce off enemies\nHas a chance to inflict Midas on enemies");
            Tooltip.AddTranslation(GameCulture.Russian, "Выстреливает двумя ножами, которые могут отскакивать от врагов\nИмеет шанс наложить эффект Мидаса на врагов");
        }

        public void OverhaulInit()
        {
            this.SetTag("throwable");
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
