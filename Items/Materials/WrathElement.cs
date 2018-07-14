using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Materials
{
    public class WrathElement : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 28;
            item.maxStack = 99;
            item.value = Item.sellPrice(0, 0, 1, 0);
            item.rare = 3;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wrath Element");
            DisplayName.AddTranslation(GameCulture.Chinese, "狂怒元素");
            DisplayName.AddTranslation(GameCulture.Russian, "Элемент ярости");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 7));
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override void PostUpdate()
        {
            Player owner = null;
            if (item.owner != -1)
            {
                owner = Main.player[item.owner];
            }
            else if (item.owner == 255)
            {
                owner = Main.LocalPlayer;
            }
            var player = owner;
            var targetPos = player.Center;
            var speed = 4;
            var speedFactor = 0.7f;
            var itemCenter = new Vector2(item.position.X + (float)item.width * 0.5f, item.position.Y + (float)item.height * 0.5f);
            var posX = targetPos.X - itemCenter.X;
            var posY = targetPos.Y - itemCenter.Y;
            var distance = (float)Math.Sqrt((double)(posX * posX + posY * posY));
            if (distance > 75f && (double)Vector2.Distance(targetPos, itemCenter) <= 450.0)
            {
                distance = speed / distance;
                posX *= distance;
                posY *= distance;
                if (item.velocity.X < posX)
                {
                    item.velocity.X = item.velocity.X + speedFactor;
                    if (item.velocity.X < 0f && posX > 0f)
                    {
                        item.velocity.X = item.velocity.X + speedFactor;
                    }
                }
                else if (item.velocity.X > posX)
                {
                    item.velocity.X = item.velocity.X - speedFactor;
                    if (item.velocity.X > 0f && posX < 0f)
                    {
                        item.velocity.X = item.velocity.X - speedFactor;
                    }
                }
                if (item.velocity.Y < posY)
                {
                    item.velocity.Y = item.velocity.Y + speedFactor;
                    if (item.velocity.Y < 0f && posY > 0f)
                    {
                        item.velocity.Y = item.velocity.Y + speedFactor;
                    }
                }
                else if (item.velocity.Y > posY)
                {
                    item.velocity.Y = item.velocity.Y - speedFactor;
                    if (item.velocity.Y > 0f && posY < 0f)
                    {
                        item.velocity.Y = item.velocity.Y - speedFactor;
                    }
                }
            }
        }
    }
}
