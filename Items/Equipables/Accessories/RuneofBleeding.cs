using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    [AutoloadEquip(EquipType.HandsOn)]
    public class RuneofBleeding : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 34;
            item.rare = 4;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.accessory = true;
            item.defense = 3;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rune of Bleeding");
            Tooltip.SetDefault("After taking damage from an enemy, deal damage to all nearby enemies");
            DisplayName.AddTranslation(GameCulture.Chinese, "嗜血符文");
            Tooltip.AddTranslation(GameCulture.Chinese, "当敌人对你造成伤害后，在你屏幕内的所有敌人承受25点伤害");
            DisplayName.AddTranslation(GameCulture.Russian, "Руна кровотечения");
            Tooltip.AddTranslation(GameCulture.Russian, "После получения урона наносит урон всем ближайшим врагам");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
            aPlayer.RuneofBleeding = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "RuneStone", 7);
            recipe.AddIngredient(null, "BloodDroplet", 12);
            recipe.AddIngredient(ItemID.ShadowScale, 12);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "RuneStone", 7);
            recipe.AddIngredient(null, "BloodDroplet", 12);
            recipe.AddIngredient(ItemID.TissueSample, 12);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}