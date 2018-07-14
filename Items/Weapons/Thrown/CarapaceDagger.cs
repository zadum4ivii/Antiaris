using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Thrown
{
    public class CarapaceDagger : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 19;
            item.thrown = true;
            item.width = 20;
            item.height = 44;
            item.noUseGraphic = true;
            item.useTime = 22;
            item.useAnimation = 22;
            item.shoot = mod.ProjectileType("CarapaceDagger");
            item.shootSpeed = 11f;
            item.useStyle = 1;
            item.knockBack = 5f;
            item.value = Item.sellPrice(0, 0, 0, 18);
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
			item.maxStack = 999;
			item.consumable = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Carapace Dagger");
            DisplayName.AddTranslation(GameCulture.Russian, "Панцирный клинок");
            DisplayName.AddTranslation(GameCulture.Chinese, "坚壳飞刀");
        }

        public void OverhaulInit()
        {
            this.SetTag("throwable");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ThrowingKnife, 50);
			recipe.AddIngredient(null, "AntlionCarapace");
            recipe.SetResult(this, 50);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
