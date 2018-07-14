using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    public class StarRing : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 24;
            item.rare = 1;
            item.value = Item.buyPrice(0, 1, 0, 0);
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Ring");
            Tooltip.SetDefault("Increases maximum mana by 20\n5% reduced spell fail chance");
            DisplayName.AddTranslation(GameCulture.Russian, "Звёздное кольцо");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает максимальное количество маны на 20\nНа 5% снижает шанс неудачного произнесения заклинания");
            DisplayName.AddTranslation(GameCulture.Chinese, "星之戒");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、增加 20 点最大魔力值\n2、减少 5% 咒语失效概率");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.statManaMax += 20;
			AntiarisPlayer.spellFail -= 5;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BandofStarpower);
            recipe.AddIngredient(null, "TranquilityElement", 8);
			recipe.AddIngredient(ItemID.ManaCrystal);
			recipe.AddIngredient(ItemID.FallenStar, 3);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
