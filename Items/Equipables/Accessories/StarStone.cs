using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    public class StarStone : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 24;
            item.value = Item.sellPrice(0, 4, 0, 15);
            item.rare = 7;
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Stone");
            Tooltip.SetDefault("Mana stars restore more mana");
			DisplayName.AddTranslation(GameCulture.Chinese, "星之石");
            Tooltip.AddTranslation(GameCulture.Chinese, "使魔力星可以回复更多魔力");
            DisplayName.AddTranslation(GameCulture.Russian, "Звездный камень");
            Tooltip.AddTranslation(GameCulture.Russian, "Звезды маны восстанавливают больше маны");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AntiarisPlayer>(mod).starStone = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 15);
            recipe.AddIngredient(ItemID.SoulofNight, 8);
            recipe.AddIngredient(null, "NatureEssence", 6);
            recipe.AddIngredient(ItemID.ManaCrystal, 3);
            recipe.SetResult(this);
            recipe.AddTile(TileID.MythrilAnvil);
        }
    }
}
