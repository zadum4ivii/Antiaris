using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Melee.Miscellaneous
{
    public class FriendlySandnado : ModProjectile
    {
        private int timer = 0;

        public override void SetDefaults()
        {
            Main.projFrames[projectile.type] = 4;
            projectile.width = 142;
            projectile.height = 206;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.timeLeft = 1250;
            projectile.extraUpdates = 1;
            projectile.alpha = 255;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sandnado");
            DisplayName.AddTranslation(GameCulture.Chinese, "沙暴");
            DisplayName.AddTranslation(GameCulture.Russian, "Песчанное торнадо");
        }

        public override void AI()
        {
            ++timer;
            Player owner = null;
            if (projectile.owner != -1)
            {
                owner = Main.player[projectile.owner];
            }
            else if (projectile.owner == 255)
            {
                owner = Main.LocalPlayer;
            }
            var player = owner;
            projectile.alpha--;
            projectile.frameCounter++;
            projectile.rotation = 0f;
            if (projectile.frameCounter > 2)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 4)
            {
                projectile.frame = 0;
            }
            foreach (var npc in Main.npc)
            {
                if (!npc.friendly && !npc.boss && npc.active && !npc.dontTakeDamage && npc.lifeMax > 5)
                {
                    if (projectile.Hitbox.Intersects(npc.Hitbox))
                    {
                        npc.velocity.Y -= 0.65f;
                        if (timer % 15 == 0)
                        {
                            var damage = 10f * player.meleeDamage;
                            var knockBack = 5f;
                            var direction = projectile.direction;
                            if (projectile.velocity.X < 0f)
                            {
                                direction = -1;
                            }
                            if (projectile.velocity.X > 0f)
                            {
                                direction = 1;
                            }
                            npc.StrikeNPC((int)damage, knockBack, direction, false, false, false);
                        }
                    }
                }
            }
            if (projectile.Hitbox.Intersects(player.Hitbox))
            {
                player.velocity.Y -= 0.95f;
                if (Main.time % 15 == 0)
                {
                    player.controlHook = false;
                    player.controlUseItem = false;
                    for (var i = 0; i < 1000; i++)
                    {
                        if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].aiStyle == 7)
                        {
                            Main.projectile[i].Kill();
                        }
                    }
                }
				if (Main.time % 15 == 0)
                {
                    var k = Main.rand.Next(1, 2);
                    player.statLife += k;
                    player.HealEffect(k);
                    NetMessage.SendData(MessageID.SpiritHeal, -1, -1, null, projectile.owner, k);
                    var i = Main.rand.Next(1, 2);
                    player.statMana += i;
                    player.ManaEffect(i);
                }
            }
        }

        public override void Kill(int timeLeft)
        {
            for (var k = 0; k < 25; k++)
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Sandstorm"), projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
        }
    }
}
