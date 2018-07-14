using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    public class CrystalAegis : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 34;
            item.rare = 4;
            item.value = Item.buyPrice(0, 1, 0, 0);
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Aegis");
            Tooltip.SetDefault("Increases maximum mana by 20\n10% reduced spell fail chance\nIncreases mana regeneration rate");
            DisplayName.AddTranslation(GameCulture.Chinese, "魂霜心");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、魔力最大值增加 20\n2、减少 10% 咒语失效概率\n3、增加魔力回复速度");
            DisplayName.AddTranslation(GameCulture.Russian, "Кристальная эгида");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает максимальное количество на 20\nНа 10% снижает шанс неудачного произнесения заклинания\nУвеличивает восстановление маны");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.statManaMax += 20;
			player.manaRegenBonus += 25;
			AntiarisPlayer.spellFail -= 10;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "StarRing");
            recipe.AddIngredient(null, "TranquilityElement", 6);
			recipe.AddIngredient(ItemID.ManaRegenerationBand);
			recipe.AddIngredient(ItemID.CrystalShard, 10);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
