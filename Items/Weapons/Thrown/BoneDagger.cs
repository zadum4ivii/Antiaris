using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Thrown
{
    public class BoneDagger : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 13;
            item.thrown = true;
            item.width = 14;
            item.height = 26;
            item.noUseGraphic = true;
            item.useTime = 22;
            item.useAnimation = 22;
            item.shoot = mod.ProjectileType("BoneDagger");
            item.shootSpeed = 6f;
            item.useStyle = 1;
            item.knockBack = 3.5f;
            item.value = Item.sellPrice(0, 0, 0, 12);
            item.rare = 1;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
			item.maxStack = 999;
			item.consumable = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bone Dagger");
            DisplayName.AddTranslation(GameCulture.Russian, "Костяной клинок");
            DisplayName.AddTranslation(GameCulture.Chinese, "骸骨飞刀");
        }

        public void OverhaulInit()
        {
            this.SetTag("throwable");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bone, 3);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
