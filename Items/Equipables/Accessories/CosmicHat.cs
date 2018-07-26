using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    [AutoloadEquip(new EquipType[] { EquipType.Face })]
    public class CosmicHat : ModItem
    {
        private float timer = 0.0f;

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 22;
            item.value = Item.sellPrice(0, 2, 0, 15);
            item.rare = 4;
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cosmic Hat");
            Tooltip.SetDefault("Magic stars will rain down when your mana is at critical levels");
			DisplayName.AddTranslation(GameCulture.Chinese, "星辰帽");
			Tooltip.AddTranslation(GameCulture.Chinese, "当你的魔力值即将消耗完时\n空中会降下能够恢复魔力的魔法星");
            DisplayName.AddTranslation(GameCulture.Russian, "Космическая шапка");
            Tooltip.AddTranslation(GameCulture.Russian, "Звёзды маны будут падать с небес, когда количество маны на критическом уровне");
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawAltHair = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (this.timer > 0.0f) this.timer--;
            if ((player.statMana < player.statManaMax2 * 0.3f) && (double)this.timer <= 0.0)
            {
                float x = player.position.X + (float)Main.rand.Next(-600, 450);
                float y = player.position.Y - (float)Main.rand.Next(750, 1000);
                Vector2 vector2 = new Vector2(x, y);
                float playerX = player.position.X + (float)(player.width / 2) - vector2.X;
                float playerY = player.position.Y + (float)(player.height / 2) - vector2.Y;
                float speed = 22f / (float)Math.Sqrt((double)playerX * (double)playerX + (double)playerY * (double)playerY);
                float speedX = playerX * speed;
                float speedY = playerY * speed;
                Projectile.NewProjectile(x, y, speedX, speedY, mod.ProjectileType("CosmicMana"), 0, 0.0f, player.whoAmI, 0.0f, 0.0f);
                this.timer = 7.0f;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WizardHat);
			recipe.AddIngredient(ItemID.StarCloak);
            recipe.AddIngredient(ItemID.ManaCrystal, 3);
            recipe.AddIngredient(ItemID.SoulofNight, 5);
            recipe.SetResult(this);
            recipe.AddTile(TileID.Anvils);
            recipe.AddRecipe();
        }
    }
}
