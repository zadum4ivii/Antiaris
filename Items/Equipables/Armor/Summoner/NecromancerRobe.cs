using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Summoner
{
    [AutoloadEquip(EquipType.Body)]
    public class NecromancerRobe : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.rare = 8;
            item.defense = 12;
			item.value = Item.sellPrice(0, 5, 0, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Necromancer Robe");
            DisplayName.AddTranslation(GameCulture.Chinese, "死灵法师法袍");
            DisplayName.AddTranslation(GameCulture.Russian, "Роба некроманта");
			Tooltip.SetDefault("Increases your max amount of minions\n15% increased minion damage");
			Tooltip.AddTranslation(GameCulture.Chinese, "1、增加召唤物最大上限\n2、增加 15% 召唤物伤害");
			Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает максимальное количество миньонов\nУвеличивает урон миньонов на 15%");
        }

        public override void UpdateEquip(Player player)
        {
			player.maxMinions += 2;
			player.minionDamage += 0.15f;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "NecroCloth", 18);
            recipe.AddIngredient(ItemID.Bone, 10);
            recipe.AddIngredient(ItemID.SoulofNight, 8);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
