using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Tools.Axes
{
    public class PalmWoodAxe : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 3;
            item.melee = true;
            item.width = 32;
            item.height = 28;
            item.useTime = 16;
            item.useAnimation = 28;
            item.useStyle = 1;
            item.knockBack = 4;
            item.value = Item.sellPrice(0, 0, 0, 19);
            item.rare = 0;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
			item.axe = 6;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Palm Wood Axe");
            DisplayName.AddTranslation(GameCulture.Chinese, "棕榈木斧");
            DisplayName.AddTranslation(GameCulture.Russian, "Топор из пальмовой древесины");
        }

        public void OverhaulInit()
        {
            this.SetTag("tool");
            this.SetTag("bluntHit");
            this.SetTag("flammable");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalmWood, 9);
            recipe.SetResult(this);
            recipe.AddTile(18);
            recipe.AddRecipe();
        }
    }
}