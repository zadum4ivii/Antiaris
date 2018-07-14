using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Materials
{
    public class TranquilityElement : ModItem
    {
        private int timer = 0;

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 20;
            item.maxStack = 99;
            item.value = Item.sellPrice(0, 0, 1, 0);
            item.rare = 3;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tranquility Element");
            DisplayName.AddTranslation(GameCulture.Chinese, "宁静元素");
            DisplayName.AddTranslation(GameCulture.Russian, "Элемент спокойствия");
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override void PostUpdate()
        {
            ++timer;
            if (timer % 155 == 0)
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
                var startPos = new Vector2(item.position.X + (item.width * 0.5f), item.position.Y + (item.height / 2));
                var rot = (float)Math.Atan2(startPos.Y - (player.position.Y + (player.height * 0.5f)), startPos.X - (player.position.X + (player.width * 0.5f)));
                item.velocity.X = (float)(Math.Cos(rot) * 5) * -1;
                item.velocity.Y = (float)(Math.Sin(rot) * 5) * -1;
            }
            if (Main.rand.Next(15) == 0)
            {
                Dust.NewDust(item.position, item.width, item.height, 211, item.velocity.X * 0.5f, item.velocity.Y * 0.5f, 150, default(Color), 1.2f);
            }
        }
    }
}
