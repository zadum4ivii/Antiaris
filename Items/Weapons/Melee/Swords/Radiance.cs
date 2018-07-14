using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Melee.Swords
{
    public class Radiance : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.damage = 61;
            item.melee = true;
            item.width = 44;
            item.height = 44;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = 1;
            item.knockBack = 6.5f;
            item.value = Item.sellPrice(0, 7, 0, 0);
            item.rare = 5;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Radiance");
            DisplayName.AddTranslation(GameCulture.Russian, "Сияние");
            DisplayName.AddTranslation(GameCulture.Chinese, "虚伪正义");
            Tooltip.AddTranslation(GameCulture.Chinese, "发射神圣烈焰\n“那两颗宝石跟地狱小鬼的眼珠子似的！”");
            Tooltip.SetDefault("Fires a celestial flame");
            Tooltip.AddTranslation(GameCulture.Russian, "Выстреливает небесным огоньком");
        }

        public void OverhaulInit()
        {
            this.SetTag("broadsword");
        }

        public override bool UseItem(Player player)
        {
            if ((double)player.Center.X > (double)Main.mouseX + (double)Main.screenPosition.X)
                player.direction = -1;
            else
                player.direction = 1;
            var i = Projectile.NewProjectile(player.Center.X + (float)(-40 * player.direction) + (float)Main.rand.Next(-34, 21), player.Center.Y - (float)Main.rand.Next(-25, 45), 0.0f, 0.0f, mod.ProjectileType("CelestialMagicCentral"), (int)((double)item.damage * (double)player.meleeDamage), 7.5f, player.whoAmI, 0.0f, 0.0f);
            Main.projectile[i].penetrate = 2;
            return true;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(4) == 0)
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 57);
            if (Main.rand.Next(5) == 0)
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 73);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Excalibur, 1);
            recipe.AddIngredient(ItemID.SoulofLight, 26);
			recipe.AddIngredient(null, "WrathElement", 10);
			recipe.AddIngredient(ItemID.CrystalShard, 12);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
