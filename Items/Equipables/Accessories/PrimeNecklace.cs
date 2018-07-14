using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(EquipType.Neck)]
    public class PrimeNecklace : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.rare = 6;
            item.value = Item.buyPrice(0, 7, 0, 0);
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prime Necklace");
            Tooltip.SetDefault("Increases your max number of minions\n10% increased minion damage");
            DisplayName.AddTranslation(GameCulture.Chinese, "首领项链");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、增加召唤物上限\n2、增加 10% 召唤物伤害");
            DisplayName.AddTranslation(GameCulture.Russian, "Прайм-ожерелье");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает максимальное количество миньонов\nУвеличивает урон миньонов на 10%");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.minionDamage += 0.1f;
			player.maxMinions += 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PygmyNecklace);
            recipe.AddIngredient(ItemID.AvengerEmblem);
            recipe.SetResult(this);
            recipe.AddTile(114);
            recipe.AddRecipe();
        }
    }
}
