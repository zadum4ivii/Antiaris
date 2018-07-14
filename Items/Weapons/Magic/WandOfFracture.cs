using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Magic
{
    public class WandOfFracture : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.damage = 43;
            item.magic = true;
            item.mana = 7;
            item.width = 36;
            item.height = 36;
            item.useTime = 28;
            item.useAnimation = 28;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 5.0f;
            item.value = Item.sellPrice(0, 6, 50, 0);
            item.rare = 5;
            item.UseSound = SoundID.Item54;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("EntropyOrb");
            item.shootSpeed = 7.4f;
            Item.staff[item.type] = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wand of Fracture");
            Tooltip.SetDefault("Casts three homing explosive orbs\n'The powers of Ignis and Terra pulse within this wand'");
			DisplayName.AddTranslation(GameCulture.Chinese, "断裂之杖");
			Tooltip.AddTranslation(GameCulture.Chinese, "发射三个跟踪爆裂钢珠\n“这个法杖蕴含了炙焰与大地的力量！”");
            DisplayName.AddTranslation(GameCulture.Russian, "Посох разрушения");
            Tooltip.AddTranslation(GameCulture.Russian, "Выпускает три самонаводящихся взрывоопасных шаров\n'Силы Игниса и Терры пульсируют в этом посохе'");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 40f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 42.0f;
			for (int k = 0; k < 3; k++)
            {
				float speedXN = speedX + (float)Main.rand.Next(-40, 41) * 0.1f;
				float speedYN = speedY + (float)Main.rand.Next(-40, 41) * 0.1f;
				Projectile.NewProjectile(position.X, position.Y, speedXN, speedYN, type, damage, knockBack, player.whoAmI);
            }
			return false;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "WandOfEarthruler");
            recipe.AddIngredient(null, "WandOfFirestorm");
			recipe.AddIngredient(ItemID.HallowedBar, 10);
			recipe.AddIngredient(ItemID.ExplosivePowder, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
            recipe.SetResult(this);
            recipe.AddTile(TileID.DemonAltar);
            recipe.AddRecipe();
        }
    }
}
