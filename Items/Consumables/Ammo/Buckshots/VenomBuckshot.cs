using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Buckshots
{
    public class VenomBuckshot : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 14;
            item.width = 18;
            item.maxStack = 999;
            item.height = 18;
            item.rare = 3;
            item.ranged = true;
            item.consumable = true;
            item.knockBack = 1f;
            item.ammo = mod.ItemType("Buckshot");
            item.value = Item.sellPrice(0, 0, 0, 9);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Venom Buckshot");
            Tooltip.SetDefault("Used as ammo for blunderbusses\nSlows enemies down");
            DisplayName.AddTranslation(GameCulture.Chinese, "剧毒火铳弹");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、用于火铳\n2、减缓敌人的移动速度");
            DisplayName.AddTranslation(GameCulture.Russian, "Отравленная картечь");
            Tooltip.AddTranslation(GameCulture.Russian, "Используется как патроны для мушкетонов\nЗамедляет врагов");
        }

        public override void PickAmmo(Player player, ref int type, ref float speed, ref int damage, ref float knockback)
        {
            type = mod.ProjectileType("VenomBuckshot");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Buckshot", 50);
            recipe.AddIngredient(ItemID.VialofVenom);
            recipe.SetResult(this, 50);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
