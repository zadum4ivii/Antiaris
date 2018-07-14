using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    [AutoloadEquip(EquipType.Shoes)]
    public class LeatherBoots : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 38;
            item.rare = 1;
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.accessory = true;
            item.defense = 4;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Leather Boots");
            DisplayName.AddTranslation(GameCulture.Chinese, "皮靴");
            DisplayName.AddTranslation(GameCulture.Russian, "Кожанные ботинки");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.OldShoe, 2);
            recipe.AddIngredient(ItemID.Leather, 7);
            recipe.SetResult(this);
            recipe.AddTile(TileID.Loom);
            recipe.AddRecipe();
        }
    }
}