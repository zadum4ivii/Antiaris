using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI.Chat;

namespace Antiaris.Items.Weapons.Ranged.Guns
{
    public class AcornChopper : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 16;
            item.ranged = true;
            item.width = 44;
            item.height = 24;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.rare = 1;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("Acorn");
            item.shootSpeed = 6f;
            item.value = Item.sellPrice(0, 0, 0, 75);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Acorn Chopper");
            Tooltip.SetDefault("Uses acorn as ammo");
			DisplayName.AddTranslation(GameCulture.Chinese, "橡子粉碎机");
			Tooltip.AddTranslation(GameCulture.Chinese, "使用橡子作为弹药");
            DisplayName.AddTranslation(GameCulture.Russian, "Измельчитель желудей");
            Tooltip.AddTranslation(GameCulture.Russian, "Использует желуди в качестве патронов");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 newPos = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + newPos, 0, 0))
            {
                position += newPos;
            }
            speedX *= 0.7f + (Main.rand.Next(10) / 20f);
            speedY *= 0.7f + (Main.rand.Next(10) / 20f);
            speedX += (Main.rand.Next(-1, 2) / 10);
            speedY += (Main.rand.Next(-1, 2) / 10);
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            return Util.ConsumeAmmo(ref player, ItemID.Acorn);
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }


        public override void PostDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            if (!Main.playerInventory)
            {
                var index = 20;
                for (var j = 0; j < 10; ++j)
                {
                    var scale_ = Main.hotbarScale[j];
                    var position_ = (int)(20 + 22 * (1 - (double)scale_));
                    var item = Main.player[Main.myPlayer].inventory[j];
                    if (item.stack > 0 && item.type == mod.ItemType("AcornChopper"))
                    {
                        var pos = new Vector2((float)index, (float)position_);
                        var text = 0;
                        for (var m = 0; m < 50; m++)
                        {
                            var item2 = Main.player[Main.myPlayer].inventory[m];
                            if (item2.type == ItemID.Acorn)
                                if (item2.stack > 0)
                                    text += item2.stack;
                                else
                                    text = 0;
                        }
                        ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontItemStack, "" + text, pos + new Vector2(10f * scale_, 32f * scale_), Color.White, 0f, default(Vector2), new Vector2(scale_ *= 0.8f), -1f, 0.8f);
                    }
                    index += (int)((double)Main.inventoryBackTexture.Width * (double)Main.hotbarScale[j]) + 4;
                }
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 15);
            recipe.AddIngredient(ItemID.Wood, 12);
			recipe.AddIngredient(null, "NatureEssence", 11);
            recipe.AddIngredient(ItemID.Acorn, 6);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
