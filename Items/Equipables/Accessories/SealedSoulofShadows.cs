using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    public class SealedSoulofShadows : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 44;
            item.rare = 4;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sealed Soul of Shadows");
            Tooltip.SetDefault("Dealing critical damage restores life");
            DisplayName.AddTranslation(GameCulture.Chinese, "密封的暗之灵魂");
            Tooltip.AddTranslation(GameCulture.Chinese, "造成致命一击时将恢复生命");
            DisplayName.AddTranslation(GameCulture.Russian, "Запечатанная душа теней");
            Tooltip.AddTranslation(GameCulture.Russian, "Нанесение критического урона восстанавливает здоровье");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
            aPlayer.critHeal = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ShadowChargedCrystal", 15);
			recipe.AddIngredient(ItemID.SoulofNight, 20);
			recipe.AddIngredient(ItemID.ShadowScale, 8);
			recipe.AddIngredient(null, "BloodDroplet", 25);
			recipe.AddIngredient(null, "VampiricEssence", 5);
			recipe.AddIngredient(null, "WrathElement", 6);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
        }
    }
}