using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Mounts
{
    public class EmeraldSlime : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Emerald Slime");
			Description.SetDefault("Even more BOOOIIINNNG!");
            DisplayName.AddTranslation(GameCulture.Russian, "Изумрудный слизень");
			Description.AddTranslation(GameCulture.Russian, "Ещё больше БДЫНЬ!");
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.mount.SetMount(mod.MountType("EmeraldSlime"), player);
            player.buffTime[buffIndex] = 10;
            player.armorEffectDrawShadow = true;
            if (player.wet)
            {
                player.wetSlime = 30;
                if (player.velocity.Y > 2f)
                {
                    player.velocity.Y = player.velocity.Y * 0.9f;
                }
                player.velocity.Y = player.velocity.Y - 1f;
                if (player.velocity.Y < -5f)
                {
                    player.velocity.Y = -5f;
                }
                if (player.controlJump)
                {
                    player.velocity.Y = -20f;
                }
            }
            var checkDamagePlayer = player.getRect();
            checkDamagePlayer.Offset(0, player.height - 1);
            checkDamagePlayer.Height = 2;
            checkDamagePlayer.Inflate(12, 6);
            for (var i = 0; i < 200; i++)
            {
                var npc = Main.npc[i];
                if (npc.active && !npc.dontTakeDamage && !npc.friendly && npc.immune[player.whoAmI] == 0)
                {
                    var checkDamageNPC = npc.getRect();
                    if (checkDamagePlayer.Intersects(checkDamageNPC) && (npc.noTileCollide || Collision.CanHit(player.position, player.width, player.height, npc.position, npc.width, npc.height)))
                    {
                        var damage = 60f * player.meleeDamage;
                        var knockBack = 5f;
                        var direction = player.direction;
                        if (player.velocity.X < 0f)
                        {
                            direction = -1;
                        }
                        if (player.velocity.X > 0f)
                        {
                            direction = 1;
                        }
                        if (player.whoAmI == Main.myPlayer)
                        {
                            npc.StrikeNPC((int)damage, knockBack, direction, false, false, false);
                        }
                        npc.immune[player.whoAmI] = 10;
                        player.velocity.Y = -20f;
                        player.immune = true;
                        break;
                    }
                }
            }
        }
    }
}
