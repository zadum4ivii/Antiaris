using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Buckshots
{
    public class SpectralBuckshot : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 16;
            item.width = 18;
            item.maxStack = 999;
            item.height = 18;
            item.rare = 8;
            item.ranged = true;
            item.consumable = true;
            item.knockBack = 1f;
            item.ammo = mod.ItemType("Buckshot");
            item.value = Item.sellPrice(0, 0, 0, 9);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectral Buckshot");
            Tooltip.SetDefault("Used as ammo for blunderbusses\nCan go through blocks");
            DisplayName.AddTranslation(GameCulture.Chinese, "幽灵火铳弹");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、用于火铳\n2、允许穿墙");
            DisplayName.AddTranslation(GameCulture.Russian, "Спектральная картечь");
            Tooltip.AddTranslation(GameCulture.Russian, "Используется как патроны для мушкетонов\nМожет проходить через блоки");
        }

        public override void PickAmmo(Player player, ref int type, ref float speed, ref int damage, ref float knockback)
        {
            type = mod.ProjectileType("SpectralBuckshot");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Buckshot", 50);
            recipe.AddIngredient(ItemID.Ectoplasm);
            recipe.SetResult(this, 50);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
