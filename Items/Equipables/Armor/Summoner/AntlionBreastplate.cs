using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Summoner
{
    [AutoloadEquip(EquipType.Body)]
    public class AntlionBreastplate : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 22;
            item.rare = 3;
            item.defense = 5;
			item.value = Item.sellPrice(0, 1, 10, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Antlion Breastplate");
            DisplayName.AddTranslation(GameCulture.Chinese, "蚁狮胸甲");
            DisplayName.AddTranslation(GameCulture.Russian, "Нагрудник муравиьного льва");
			Tooltip.SetDefault("6% increased minion damage\nIncreases your max number of minions");
			Tooltip.AddTranslation(GameCulture.Chinese, "1、增加 6% 召唤伤害\n2、增加召唤物最大上限");
			Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает урон миньонов на 6%\nУвеличивает максимальное количество миньонов");
        }

        public override void UpdateEquip(Player player)
        {
			player.minionDamage += 0.06f;
			player.maxMinions += 1;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AntlionMandible, 3);
			recipe.AddIngredient(ItemID.BeeBreastplate);
            recipe.AddIngredient(null, "AntlionCarapace", 16);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
