using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Ranged.Blunderbusses
{
    public class HallowedBlunderbuss : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.damage = 45;
            item.ranged = true;
            item.width = 78;
            item.height = 32;
            item.useTime = 48;
            item.useAnimation = 48;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 8;
            item.rare = 5;
			item.value = Item.sellPrice(0, 5, 10, 0);
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = 10;
            item.holdStyle = 3;
            item.shootSpeed = 16f;
            item.useAmmo = mod.ItemType("Buckshot");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hallowed Blunderbuss");
            Tooltip.SetDefault("Uses buckshots as ammo\n<right> to zoom out\n50% chance to not consume ammo");
            DisplayName.AddTranslation(GameCulture.Chinese, "神圣火铳");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、使用火铳弹当做弹药 \n2、点击鼠标 <right> 键观察远处。 \n3、50%的几率不消耗弹药。");
            DisplayName.AddTranslation(GameCulture.Russian, "Святой мушкетон");
            Tooltip.AddTranslation(GameCulture.Russian, "Использует картечь в качестве патронов\nright> для приближения\n50% шанс не потратить пулю");
        }

        public void OverhaulInit()
        {
            this.SetTag("holyDamage");
        }

        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .50f;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
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
            recipe.AddIngredient(null, "BlunderbussBase", 1);
            recipe.AddIngredient(ItemID.HallowedBar, 14);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
