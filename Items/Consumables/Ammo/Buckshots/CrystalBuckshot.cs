using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Buckshots
{
    public class CrystalBuckshot : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 14;
            item.width = 14;
            item.maxStack = 999;
            item.height = 14;
            item.rare = 4;
            item.ranged = true;
            item.consumable = true;
            item.knockBack = 2f;
            item.ammo = mod.ItemType("Buckshot");
            item.value = Item.sellPrice(0, 0, 0, 6);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Buckshot");
            Tooltip.SetDefault("Used as ammo for blunderbusses");
            DisplayName.AddTranslation(GameCulture.Russian, "Кристальная картечь");
            Tooltip.AddTranslation(GameCulture.Russian, "Используется как патроны для мушкетонов");
            DisplayName.AddTranslation(GameCulture.Chinese, "魔晶火铳弹");
            Tooltip.AddTranslation(GameCulture.Chinese, "用于火铳");
        }

        public override void PickAmmo(Player player, ref int type, ref float speed, ref int damage, ref float knockback)
        {
            type = mod.ProjectileType("CrystalBuckshot");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Buckshot", 50);
            recipe.AddIngredient(ItemID.CrystalShard);
            recipe.SetResult(this, 50);
            recipe.AddTile(TileID.Anvils);
            recipe.AddRecipe();
        }
    }
}
