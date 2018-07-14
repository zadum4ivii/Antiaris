using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Ranged.Bows
{
    public class GooBow : ModItem
    {
		public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }
        public override void SetDefaults()
        {
            item.damage = 16;
            item.ranged = true;
            item.width = 18;
            item.height = 32;
            item.useAnimation = 24;
            item.useTime = 24;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.rare = 2;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = 1;
            item.shootSpeed = 9f;
            item.value = Item.sellPrice(0, 0, 15, 0);
            item.useAmmo = AmmoID.Arrow;
        }
		
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Goo Bow");
            DisplayName.AddTranslation(GameCulture.Chinese, "凝胶弓");
            DisplayName.AddTranslation(GameCulture.Russian, "Лук из слизи");
        }

        public void OverhaulInit()
        {
            this.SetTag("bow");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
			return false;
		}

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "LiquifiedGoo", 1);
            recipe.AddRecipeGroup("Antiaris:WoodenBow");
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
