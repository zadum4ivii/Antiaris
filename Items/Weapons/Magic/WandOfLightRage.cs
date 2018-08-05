using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Magic
{
    public class WandOfLightRage : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.damage = 27;
            item.magic = true;
            item.mana = 12;
            item.width = 40;
            item.height = 40;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 0.0f;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 3;
            item.UseSound = SoundID.Item81;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("Lightning3");
            item.shootSpeed = 22.0f;
            Item.staff[item.type] = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wand of Light Rage");
            Tooltip.SetDefault("Casts furious lightning at enemies\n'Forged with Aer'");
			DisplayName.AddTranslation(GameCulture.Chinese, "雷怒之杖");
			Tooltip.AddTranslation(GameCulture.Chinese, "对敌人降下天谴\n“空气之造物”");
            DisplayName.AddTranslation(GameCulture.Russian, "Посох ярости света");
            Tooltip.AddTranslation(GameCulture.Russian, "Выпускает яростную молнию в противников\n'Сковано из Аера'");
        }

        public void OverhaulInit()
        {
            this.SetTag("magicWeapon", false);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.ownedProjectileCounts[type] > 3) return false;
            knockBack = player.GetWeaponKnockback(item, knockBack);
            player.itemTime = item.useTime;
            Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
            float x = (float)Main.mouseX - Main.screenPosition.X - vector.X;
            float y = (float)Main.mouseY - Main.screenPosition.Y - vector.Y;
            if (player.gravDir == -1.0f) y = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector.Y;
            float distance = (float)Math.Sqrt((double)(x * x + y * y));
            if ((float.IsNaN(x) && float.IsNaN(y)) || (x == 0.0f && y == 0.0f))
            {
                x = (float)player.direction;
                y = 0.0f;
                distance = item.shootSpeed;
            }
            else distance = item.shootSpeed / distance;
            x *= distance;
            y *= distance;
            int count = 1;
            for (int k = 0; k < count; k++)
            {
                vector = new Vector2(player.position.X + (float)player.width * 0.5f + (float)(Main.rand.Next(201) * -(float)player.direction) + ((float)Main.mouseX + Main.screenPosition.X - player.position.X), player.MountedCenter.Y - 600f);
                vector.X = (vector.X + player.Center.X) / 2.0f + (float)Main.rand.Next(-200, 201);
                vector.Y -= (float)(100 * k);
                x = (float)Main.mouseX + Main.screenPosition.X - vector.X;
                y = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
                if (y < 0.0f) y *= -1.0f;
                if (y < 20.0f) y = 20.0f;
                distance = (float)Math.Sqrt((double)(x * x + y * y));
                distance = item.shootSpeed / distance;
                x *= distance;
                y *= distance;
                Projectile.NewProjectile(vector.X, vector.Y, x, y + (float)Main.rand.Next(-180, 181) * 0.02f, type, damage, knockBack, player.whoAmI, 0.0f, (float)Main.rand.Next(10));
            }
			return false;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "WandCore");
            recipe.AddIngredient(ItemID.Bone, 3);
            recipe.AddIngredient(ItemID.GoldBar, 5);
            recipe.AddIngredient(ItemID.Lens, 3);
            recipe.AddIngredient(ItemID.FallenStar, 10);
            recipe.AddIngredient(ItemID.Topaz, 10);
            recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.SetResult(this);
            recipe.AddTile(TileID.DemonAltar);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "WandCore");
            recipe.AddIngredient(ItemID.Bone, 3);
            recipe.AddIngredient(ItemID.PlatinumBar, 5);
            recipe.AddIngredient(ItemID.Lens, 3);
            recipe.AddIngredient(ItemID.FallenStar, 10);
            recipe.AddIngredient(ItemID.Topaz, 10);
            recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.SetResult(this);
            recipe.AddTile(TileID.DemonAltar);
            recipe.AddRecipe();
        }
    }
}
