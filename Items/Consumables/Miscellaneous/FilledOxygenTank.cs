using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Miscellaneous
{
    public class FilledOxygenTank : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 34;
            item.maxStack = 20;
            item.rare = 1;
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.UseSound = SoundID.Item1.WithPitchVariance(0.8f);
            item.consumable = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Oxygen Tank");
            Tooltip.SetDefault("Fully restores breath meter\n'Fills your lungs with air'");
            DisplayName.AddTranslation(GameCulture.Chinese, "氧气罐");
			Tooltip.AddTranslation(GameCulture.Chinese, "完全恢复呼吸计\n“让你的肺不再失去空气”");
            DisplayName.AddTranslation(GameCulture.Russian, "Бак с кислородом");
            Tooltip.AddTranslation(GameCulture.Russian, "Полностью восстанавливает запас кислорода\n'Наполняет легкие кислородом'");
        }

        public override bool UseItem(Player player)
        {
            if (player.breath != player.breathMax)
            {
                player.QuickSpawnItem(mod.ItemType("EmptyOxygenTank"));
                player.breath = player.breathMax;
                return true;
            }
            return false;
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "EmptyOxygenTank");
            recipe.AddTile(mod, "Compressor");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
