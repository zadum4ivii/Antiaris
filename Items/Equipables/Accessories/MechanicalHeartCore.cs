using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    public class MechanicalHeartCore : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 24;
            item.value = Item.sellPrice(0, 4, 0, 15);
            item.rare = 7;
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechanical Heart Core");
            Tooltip.SetDefault("All life hearts become stronger");
			DisplayName.AddTranslation(GameCulture.Chinese, "机械心脏核心");
            Tooltip.AddTranslation(GameCulture.Chinese, "所有的生命之心将变得更强大");
            DisplayName.AddTranslation(GameCulture.Russian, "Ядро механического сердца");
            Tooltip.AddTranslation(GameCulture.Russian, "Все сердца жизни становятся лучше");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AntiarisPlayer>(mod).mechanicalHeart = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 15);
            recipe.AddIngredient(ItemID.SoulofLight, 8);
            recipe.AddIngredient(null, "NatureEssence", 6);
            recipe.AddIngredient(ItemID.LifeCrystal, 3);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
