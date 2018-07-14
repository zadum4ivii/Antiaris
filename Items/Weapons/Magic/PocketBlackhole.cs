using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Magic
{
    public class PocketBlackhole : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 120;
            item.magic = true;
            item.mana = 12;
            item.width = 30;
            item.height = 22;
            item.useTime = 10;
            item.useAnimation = 10;
            item.reuseDelay = 5;
            item.useStyle = 5;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Items/PocketBlackhole");
            item.noMelee = true;
            item.noUseGraphic = true;
            item.channel = true;
            item.knockBack = 0f;
            item.value = Item.buyPrice(0, 17, 0, 0);
            item.shoot = mod.ProjectileType("PocketBlackhole");
            item.shootSpeed = 30f;
            item.rare = 10;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pocket Blackhole");
			Tooltip.SetDefault("'So small but so powerful!'");
			DisplayName.AddTranslation(GameCulture.Chinese, "袖珍黑洞");
			Tooltip.AddTranslation(GameCulture.Chinese, "“麻雀虽小，五脏俱全”");
			DisplayName.AddTranslation(GameCulture.Russian, "Карманная чёрная дыра");
			Tooltip.AddTranslation(GameCulture.Russian, "'Такая маленькая, но такая мощная!'");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LastPrism);
            recipe.AddIngredient(ItemID.NebulaArcanum);
			recipe.AddIngredient(3457, 14);
			recipe.AddIngredient(3467, 12);
			recipe.AddIngredient(null, "WrathElement", 12);
            recipe.SetResult(this);
            recipe.AddTile(412);
            recipe.AddRecipe();
        }
    }
}
