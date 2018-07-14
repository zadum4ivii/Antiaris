using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    public class GuardianHeart2 : ModItem
    {
        private float timer;
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 30;
            item.rare = 4;
            item.value = Item.buyPrice(0, 3, 15, 0);
            item.accessory = true;
            item.defense = 2;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Guardian Heart");
            Tooltip.SetDefault("Holding control down will charge up the heart\nGain a boost after charging up");
            DisplayName.AddTranslation(GameCulture.Russian, "Сердце стража");
            Tooltip.AddTranslation(GameCulture.Russian, "Зажатие кнопки вниз начнет заряжать сердце\nПосле зарядки игрок получит усиление");
			DisplayName.AddTranslation(GameCulture.Chinese, "守护者之心");
			Tooltip.AddTranslation(GameCulture.Chinese, "控制住可以让生命之心充满活力\n填装后需要蓄能");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.mount.Active && player.mount.Type >= 0)
                return;
            if (player.controlDown && Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y) < 1.0f &&
                !player.rocketFrame)
            {
                if (player.GetModPlayer<AntiarisPlayer>(mod).guardianHeart2)
                    return;
                ++timer;
                for (int k = 0; k < 5 * (int)((double)timer / 50f); k++)
                {
                    float scale = 0.4f;
                    if (timer % 2 == 1) scale = 0.65f;
                    int velocity = (int)((double)timer / 50f);
                    Vector2 sDust = player.Center + new Vector2(0f, 8f) + ((float)Main.rand.NextDouble() * 6.283185f).ToRotationVector2() * (12f - (float)(velocity * 2));
                    int index2 = Dust.NewDust(sDust - Vector2.One * 12f, 24, 24, 62, player.velocity.X / 2f, player.velocity.Y / 2f, 0, new Color(), 1f);
                    Main.dust[index2].position -= new Vector2(2f);
                    Main.dust[index2].velocity = Vector2.Normalize(player.Center - sDust) * 1.5f * (float)(10.0 - (double)velocity * 2.0) / 10f;
                    Main.dust[index2].noGravity = true;
                    Main.dust[index2].scale = scale;
                    Main.dust[index2].customData = (object)player;
                    Main.dust[index2].shader = GameShaders.Armor.GetSecondaryShader(player.ArmorSetDye(), player);
                }
            }
            if ((double)timer >= 480.0)
            {
                timer = 0.0f;
                player.statMana = player.statManaMax2;
                player.ManaEffect(player.statManaMax2);
                player.AddBuff(mod.BuffType("Amplification2"), 600, true);
                player.AddBuff(mod.BuffType("BloodRepletion2"), Main.rand.Next(4400, 5200), true);
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ShadowChargedCrystal", 17);
            recipe.AddIngredient(ItemID.SoulofNight, 14);
            recipe.AddIngredient(null, "TranquilityElement", 12);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
