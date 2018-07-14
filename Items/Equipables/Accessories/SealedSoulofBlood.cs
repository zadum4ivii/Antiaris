using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    public class SealedSoulofBlood : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 40;
            item.rare = 4;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sealed Soul of Blood");
            Tooltip.SetDefault("Each fifth damage dealt restores life");
            DisplayName.AddTranslation(GameCulture.Chinese, "密封的血之灵魂");
            Tooltip.AddTranslation(GameCulture.Chinese, "每第五次攻击将恢复生命");
            DisplayName.AddTranslation(GameCulture.Russian, "Запечатанная душа крови");
            Tooltip.AddTranslation(GameCulture.Russian, "Каждое пятое нанесение урона восстанавливает здоровье");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
            aPlayer.hitHeal = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BloodyChargedCrystal", 15);
			recipe.AddIngredient(ItemID.SoulofNight, 20);
			recipe.AddIngredient(ItemID.TissueSample, 8);
			recipe.AddIngredient(null, "BloodDroplet", 25);
			recipe.AddIngredient(null, "VampiricEssence", 5);
			recipe.AddIngredient(null, "WrathElement", 6);
            recipe.SetResult(this);
            recipe.AddTile(26);
            recipe.AddRecipe();
        }
    }
}