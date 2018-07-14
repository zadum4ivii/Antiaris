using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Ranged.Bows
{
    public class WoodenCrossbow : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 9;
            item.ranged = true;
            item.width = 60;
            item.height = 26;
            item.useTime = 35;
            item.useAnimation = 35;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.rare = 0;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = 1;
            item.shootSpeed = 18f;
            item.value = Item.sellPrice(0, 0, 10, 0);
            item.useAmmo = AmmoID.Arrow;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wooden Crossbow");
            DisplayName.AddTranslation(GameCulture.Chinese, "木十字弩");
            DisplayName.AddTranslation(GameCulture.Russian, "Деревянный арбалет");
        }

        public void OverhaulInit()
        {
            this.SetTag("crossbow");
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 65f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 15);
            recipe.AddIngredient(ItemID.IronBar, 6);
            recipe.anyIronBar = true;
            recipe.AddIngredient(ItemID.Rope, 7);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
