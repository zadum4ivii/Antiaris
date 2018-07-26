using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Tiles
{
    public class BlazingFeet : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Blazing Feet");
            Description.SetDefault("Increases movement speed");
            DisplayName.AddTranslation(GameCulture.Chinese, "燃烧之足");
            Description.AddTranslation(GameCulture.Chinese, "增加移动速度");
            DisplayName.AddTranslation(GameCulture.Russian, "Искрящиеся ноги");
            Description.AddTranslation(GameCulture.Russian, "Увеличивает скорость передвижения");
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed += 0.2f;
            if (Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y) > 1f && !player.rocketFrame)
            {
                if (player.direction == 1)
                {
                    for (var i = 0; i < 5; i++)
                    {
                        Dust.NewDust(player.position - new Vector2(15f, 0f), player.width, player.height, 6, 0, 0, 0, Color.White);
                    }
                }

                if (player.direction == -1)
                {
                    for (var i = 0; i < 5; i++)
                    {
                        Dust.NewDust(player.position + new Vector2(15f, 0f), player.width, player.height, 6, 0, 0, 0, Color.White);
                    }
                }
            }
        }
    }
}
