using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(EquipType.Neck)]
    public class SinisterCharm : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.rare = 7;
            item.value = Item.buyPrice(0, 8, 0, 0);
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sinister Charm");
            Tooltip.SetDefault("Minions inflict shadowflame on enemies\nIncreases your max number of minions\n10% increased minion damage");
            DisplayName.AddTranslation(GameCulture.Chinese, "凶兆饰物");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、召唤物会对敌人施加暗影火\n2、增加召唤物上限\n3、增加 10% 召唤物伤害");
            DisplayName.AddTranslation(GameCulture.Russian, "Зловещее ожерелье");
            Tooltip.AddTranslation(GameCulture.Russian, "Миньоны накладывают на врагов теневое пламя\nУвеличивает максимальное количество миньонов\nУвеличивает урон миньонов на 10%");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			aPlayer.shadowflameCharm = true;
			player.minionDamage += 0.1f;
			player.maxMinions += 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ShadowflameCharm");
            recipe.AddIngredient(null, "PrimeNecklace");
            recipe.SetResult(this);
            recipe.AddTile(114);
            recipe.AddRecipe();
        }
    }
}
