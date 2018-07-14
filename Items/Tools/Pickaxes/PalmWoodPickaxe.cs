using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Tools.Pickaxes
{
    public class PalmWoodPickaxe : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 3;
            item.melee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 16;
            item.useAnimation = 30;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = Item.sellPrice(0, 0, 0, 21);
            item.rare = 0;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
			item.pick = 30;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Palm Wood Pickaxe");
            DisplayName.AddTranslation(GameCulture.Chinese, "棕榈木镐");
            DisplayName.AddTranslation(GameCulture.Russian, "Кирка из пальмовой древесины");
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
            recipe.AddIngredient(ItemID.PalmWood, 10);
            recipe.SetResult(this);
            recipe.AddTile(18);
            recipe.AddRecipe();
        }
    }
}