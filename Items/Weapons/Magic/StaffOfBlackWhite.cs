using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Magic
{
    public class StaffOfBlackWhite : ModItem
    {
        public override Color? GetAlpha(Color lightColor) { return Color.White; }

        public override void SetDefaults()
        {
            item.damage = 41;
            item.magic = true;
            item.mana = 13;
            item.width = 52;
            item.height = 52;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2.3f;
            item.value = Item.sellPrice(0, 4, 25, 0);
            item.rare = 5;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("YinYangCentral");
            item.shootSpeed = 5.0f;
            Item.staff[item.type] = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Staff of Black & White");
			DisplayName.AddTranslation(GameCulture.Chinese, "阴阳杖");
            DisplayName.AddTranslation(GameCulture.Russian, "Посох чёрного и белого");
        }

        public void OverhaulInit()
        {
            this.SetTag("magicWeapon", false);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MagicMissile);
            recipe.AddIngredient(ItemID.LightShard, 2);
            recipe.AddIngredient(ItemID.DarkShard, 2);
            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
