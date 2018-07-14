using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Magic
{
    public class AcornStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 6;
            item.magic = true;
            item.mana = 7;
            item.width = 32;
            item.height = 32;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 3f;
            item.value = Item.sellPrice(0, 0, 18, 0);
            item.rare = 1;
            item.UseSound = SoundID.Item20;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("MagicAcorn");
            item.shootSpeed = 6f;
            Item.staff[item.type] = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Acorn Staff");
            Tooltip.SetDefault("Shoots an acorn\nAcorns can transform to acorn creatures that attack enemies");
            DisplayName.AddTranslation(GameCulture.Chinese, "橡子法杖");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、发射橡子\n2、橡子接触物块后会变成橡子生物攻击敌人");
            DisplayName.AddTranslation(GameCulture.Russian, "Посох желудей");
            Tooltip.AddTranslation(GameCulture.Russian, "Выстреливает жёлудями\nЖёлудь может превратиться в существо, которое атакует врагов");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 25);
            recipe.AddIngredient(ItemID.Acorn, 8); ;
            recipe.AddIngredient(null, "NatureEssence", 12);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
