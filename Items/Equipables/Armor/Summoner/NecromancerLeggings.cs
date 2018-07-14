using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Summoner
{
    [AutoloadEquip(EquipType.Legs)]
    public class NecromancerLeggings : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 18;
            item.rare = 8;
			item.defense = 8;
			item.value = Item.sellPrice(0, 4, 0, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Necromancer Leggings");
			DisplayName.AddTranslation(GameCulture.Chinese, "死灵法师护腿");
            DisplayName.AddTranslation(GameCulture.Russian, "Поножи некроманта");
            Tooltip.SetDefault("Increases your max amount of minions\n10% increased minion damage");
			Tooltip.AddTranslation(GameCulture.Chinese, "1、增加召唤物最大上限\n2、增加 10% 召唤物伤害");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает максимальное количество миньонов\nУвеличивает урон миньонов на 10%");
        }

        public override void UpdateEquip(Player player)
        {
			player.maxMinions += 1;
			player.minionDamage += 0.1f;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "NecroCloth", 15);
            recipe.AddIngredient(ItemID.Bone, 10);
            recipe.AddIngredient(ItemID.SoulofNight, 4);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
