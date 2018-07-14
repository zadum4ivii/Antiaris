using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Miscellaneous
{
    public class WandOfCondor : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.mana = 17;
            item.width = 46;
            item.height = 46;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 0.0f;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
            Item.staff[item.type] = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wand of Condor");
            Tooltip.SetDefault("Creates a whirlwind propeling the player further");
			DisplayName.AddTranslation(GameCulture.Chinese, "神鹰魔杖");
            Tooltip.AddTranslation(GameCulture.Chinese, "召唤一个推动玩家的旋风");
            DisplayName.AddTranslation(GameCulture.Russian, "Посох Кондора");
            Tooltip.AddTranslation(GameCulture.Russian, "Создает вихрь, толкающий игрока");
        }

        public override bool UseItem(Player player)
        {
            Vector2 vector = Main.MouseWorld;
            float speed = 14.5f;
            Vector2 vector2 = vector - player.Center;
            float distance = (float)Math.Sqrt((double)vector2.X * (double)vector2.X + (double)vector2.Y * (double)vector2.Y);
            vector2 *= speed / distance;
            player.velocity = vector2;
            if ((double)player.position.X > (double)vector.X) player.direction = -1;
            else if ((double)player.position.X < (double)vector.X) player.direction = 1;
            for (int k = 0; k < 12; k++)
            {
                int dust = Dust.NewDust(new Vector2(player.position.X, player.position.Y) - player.velocity, player.width, player.height, 156, 0.0f, 0.0f, 100, new Color(), 1.2f);
                Main.dust[dust].velocity *= 0.2f;
                Main.dust[dust].noGravity = true;
            }
            for (int k = 0; k < 9; k++)
            {
                int dust = Dust.NewDust(new Vector2(player.position.X, player.position.Y) - player.velocity, player.width, player.height, 156, 0.0f, 0.0f, 100, new Color(), 1f);
                Main.dust[dust].velocity *= 0.2f;
                Main.dust[dust].noGravity = true;
            }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "WandCore");
            recipe.AddIngredient(ItemID.Bone, 3);
            recipe.AddIngredient(ItemID.GoldBar, 5);
            recipe.AddIngredient(ItemID.Lens, 3);
            recipe.AddIngredient(ItemID.Feather, 10);
            recipe.AddIngredient(ItemID.Diamond, 7);
			recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.SetResult(this);
            recipe.AddTile(TileID.DemonAltar);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "WandCore");
            recipe.AddIngredient(ItemID.Bone, 3);
            recipe.AddIngredient(ItemID.PlatinumBar, 5);
            recipe.AddIngredient(ItemID.Lens, 3);
            recipe.AddIngredient(ItemID.Feather, 10);
            recipe.AddIngredient(ItemID.Diamond, 7);
			recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.SetResult(this);
            recipe.AddTile(TileID.DemonAltar);
            recipe.AddRecipe();
        }
    }
}
