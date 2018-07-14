using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    [AutoloadEquip(EquipType.HandsOn)]
    public class RuneofWrath : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 34;
            item.rare = 4;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.accessory = true;
            item.defense = 3;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rune of Wrath");
            Tooltip.SetDefault("After taking damage from an enemy, grants 15% increased damage for 5 seconds");
            DisplayName.AddTranslation(GameCulture.Chinese, "狂怒符文");
            Tooltip.AddTranslation(GameCulture.Chinese, "当敌人对你造成伤害后，5秒内自身增加15%的伤害");
            DisplayName.AddTranslation(GameCulture.Russian, "Руна гнева");
            Tooltip.AddTranslation(GameCulture.Russian, "После получения урона повышает наносимый урон на 5% на 5 секунд");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
            aPlayer.RuneofWrath = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "RuneStone", 7);
            recipe.AddIngredient(null, "WrathElement", 10);
            recipe.AddIngredient(ItemID.ShadowScale, 12);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "RuneStone", 7);
            recipe.AddIngredient(null, "WrathElement", 10);
            recipe.AddIngredient(ItemID.TissueSample, 12);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
