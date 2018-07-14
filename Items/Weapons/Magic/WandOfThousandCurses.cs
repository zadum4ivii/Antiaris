using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Magic
{
    public class WandOfThousandCurses : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.damage = 34;
            item.magic = true;
            item.mana = 11;
            item.width = 42;
            item.height = 42;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = 5;
            item.noMelee = true;
            item.value = Item.sellPrice(0, 2, 50, 0);
            item.knockBack = 3.4f;
            item.rare = 4;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("CurseSphere");
            item.shootSpeed = 7.4f;
            Item.staff[item.type] = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wand of Thousand Curses");
            Tooltip.SetDefault("Creates multiple flames which wither your enemy away");
			DisplayName.AddTranslation(GameCulture.Chinese, "千咒之杖");
			Tooltip.AddTranslation(GameCulture.Chinese, "召唤多个烈焰让你的敌人凋零");
            DisplayName.AddTranslation(GameCulture.Russian, "Посох тысячи проклятий");
            Tooltip.AddTranslation(GameCulture.Russian, "Создает несколько огней, которые ослабевают Вашего врага");
        }

        public void OverhaulInit()
        {
            this.SetTag("unholyDamage");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 40f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 46.0f;
            for (int k = 0; k < Main.rand.Next(2, 4); k++)
            {
                float speedXN = speedX + (float)Main.rand.Next(-10, 11) * 0.1f;
                float speedYN = speedY + (float)Main.rand.Next(-10, 11) * 0.1f;
                Projectile.NewProjectile(position.X, position.Y, speedXN, speedYN, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "WandCore");
            recipe.AddIngredient(ItemID.CursedFlame, 20);
            recipe.AddIngredient(ItemID.SoulofNight, 14);
            recipe.AddIngredient(ItemID.AdamantiteBar, 8);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "WandCore");
            recipe.AddIngredient(ItemID.CursedFlame, 20);
            recipe.AddIngredient(ItemID.SoulofNight, 14);
            recipe.AddIngredient(ItemID.TitaniumBar, 8);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
