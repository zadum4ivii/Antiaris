using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Buckshots
{
    public class ChlorophyteBuckshot : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 16;
            item.width = 18;
            item.maxStack = 999;
            item.height = 18;
            item.rare = 7;
            item.ranged = true;
            item.consumable = true;
            item.knockBack = 1f;
            item.ammo = mod.ItemType("Buckshot");
            item.value = Item.sellPrice(0, 0, 0, 10);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chlorophyte Buckshot");
            Tooltip.SetDefault("Used as ammo for blunderbusses\nChases after your enemy and bounces from blocks");
            DisplayName.AddTranslation(GameCulture.Chinese, "叶绿火铳弹");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、用于火铳\n2、遇到方块反弹并且追赶你的敌人");
            DisplayName.AddTranslation(GameCulture.Russian, "Спектральная картечь");
            Tooltip.AddTranslation(GameCulture.Russian, "Используется как патроны для мушкетонов\nСледует за врагами и отскакивает от блоков");
        }

        public override void PickAmmo(Player player, ref int type, ref float speed, ref int damage, ref float knockback)
        {
            type = mod.ProjectileType("ChlorophyteBuckshot");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Buckshot", 50);
            recipe.AddIngredient(ItemID.ChlorophyteBar);
            recipe.SetResult(this, 50);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
