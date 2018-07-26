using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Antiaris.Items.Tools
{
    public class EmeraldNet : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 44;
            item.height = 50;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = 1;
            item.value = Item.sellPrice(0, 25, 0, 0);
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
            item.rare = 4;
            item.scale = 1.2f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Emerald Net");
            Tooltip.SetDefault("Allows to catch slimes and get green goo");
            DisplayName.AddTranslation(GameCulture.Chinese, "翡绿捕虫网");
            Tooltip.AddTranslation(GameCulture.Chinese, "当装备皇家凝胶时可以捕获史莱姆和获取绿色凝胶");
            DisplayName.AddTranslation(GameCulture.Russian, "Изумрудный сачок");
            Tooltip.AddTranslation(GameCulture.Russian, "Позволяет ловить слизней и получать зеленую слизь");
        }

        internal static readonly int[] Slimes =
        {
            1,
            16,
            59,
            71,
            81,
            138,
            121,
            122,
            141,
            147,
            183,
            184,
            204,
            225,
            244,
            302,
            333,
            335,
            334,
            336,
            537
        };

        public override bool UseItem(Player player)
        {
            if (player.itemAnimation > 0)
            {
                var FirstRectangle = new Rectangle((int)player.itemLocation.X, (int)player.itemLocation.Y, 70, 70);
                FirstRectangle.Width = (int)((float)FirstRectangle.Width * player.inventory[player.selectedItem].scale);
                FirstRectangle.Height = (int)((float)FirstRectangle.Height * player.inventory[player.selectedItem].scale);
                if (player.direction == -1)
                {
                    FirstRectangle.X -= FirstRectangle.Width;
                }
                if (player.gravDir == 1f)
                {
                    FirstRectangle.Y -= FirstRectangle.Height;
                }
                if ((double)player.itemAnimation < (double)player.itemAnimationMax * 0.333)
                {
                    if (player.direction == -1)
                    {
                        FirstRectangle.X -= (int)((double)FirstRectangle.Width * 1.4 - (double)FirstRectangle.Width);
                    }
                    FirstRectangle.Width = (int)((double)FirstRectangle.Width * 1.4);
                    FirstRectangle.Y += (int)((double)FirstRectangle.Height * 0.5 * (double)player.gravDir);
                    FirstRectangle.Height = (int)((double)FirstRectangle.Height * 1.1);
                }
                else if ((double)player.itemAnimation >= (double)player.itemAnimationMax * 0.666)
                {
                    if (player.direction == 1)
                    {
                        FirstRectangle.X -= (int)((double)FirstRectangle.Width * 1.2);
                    }
                    FirstRectangle.Width *= 2;
                    FirstRectangle.Y -= (int)(((double)FirstRectangle.Height * 1.4 - (double)FirstRectangle.Height) * (double)player.gravDir);
                    FirstRectangle.Height = (int)((double)FirstRectangle.Height * 1.4);
                }
                for (var k = 0; k < 200; k++)
                {
                    foreach (var slime in Slimes)
                    if (Main.npc[k].active && Main.npc[k].catchItem > 0 && Main.npc[k].type == slime)
                    {
                        Rectangle SecondRectangle = new Rectangle((int)Main.npc[k].position.X, (int)Main.npc[k].position.Y, Main.npc[k].width, Main.npc[k].height);
                        if (FirstRectangle.Intersects(SecondRectangle) && (Main.npc[k].noTileCollide || Collision.CanHit(player.position, player.width, player.height, Main.npc[k].position, Main.npc[k].width, Main.npc[k].height)))
                            NPC.CatchNPC(k, player.whoAmI);
                    }
                }
                return true;
            }
            return true;
        }
    }
}
