using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Magic
{
    public class TreacheousBoltStaff : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.damage = 28;
            item.magic = true;
            item.mana = 4;
            item.width = 48;
            item.height = 64;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2.3f;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 3;
            item.UseSound = SoundID.Item75;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("TrueEnergy");
            item.shootSpeed = 10.0f;
            Item.staff[item.type] = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treacheous Bolt Staff");
			DisplayName.AddTranslation(GameCulture.Chinese, "千瞬闪电杖");
            DisplayName.AddTranslation(GameCulture.Russian, "Посох коварной молнии");
        }

        public void OverhaulInit()
        {
            this.SetTag("magicWeapon", false);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            Vector2 vector = Main.MouseWorld;
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 70.5f;
            float speed = (float)(3.0 + (double)Main.rand.NextFloat() * 6.0);
            Vector2 start = Vector2.UnitY.RotatedByRandom(6.32);
            Projectile.NewProjectile(position.X, position.Y, start.X * speed, start.Y * speed, type, damage, knockBack, player.whoAmI, vector.X, vector.Y);
            return false;
		}
    }
}
