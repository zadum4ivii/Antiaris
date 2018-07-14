using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Magic
{
    public class SupportStavePro : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 180;
            projectile.height = 10;
            projectile.width = 10;
            aiType = ProjectileID.Bullet;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            for (int k = 0; k < 200; k++)
            {
                if (Main.npc[k].townNPC && Main.npc[k].active)
                {
                    if (projectile.Hitbox.Intersects(Main.npc[k].Hitbox))
                    {
                        if (Main.npc[k].lifeMax > Main.npc[k].life)
                        {
                            projectile.Kill();
                            Main.npc[k].life += 30;
                            Main.npc[k].HealEffect(30, true);
                        }
                        if (Main.npc[k].lifeMax <= Main.npc[k].life)
                        {
                            Main.npc[k].life = Main.npc[k].lifeMax;
                        }
                    }
                }
            }
            int Beams = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 157, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            int Beams2 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 157, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.dust[Beams].noGravity = true;
            Main.dust[Beams2].noGravity = true;
            Main.dust[Beams2].velocity *= 0f;
            Main.dust[Beams2].velocity *= 0f;
            Main.dust[Beams2].scale = 1.2f;
            Main.dust[Beams].scale = 1.2f;
        }
    } 
}
