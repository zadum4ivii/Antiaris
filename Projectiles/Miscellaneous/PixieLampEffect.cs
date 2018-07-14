using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Miscellaneous
{
    public class PixieLampEffect : ModProjectile
    {
        private float rot;
        private Vector2 rotVec = new Vector2(0.0f, 124.0f);

        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.aiStyle = -1;
            projectile.tileCollide = false;
            projectile.ownerHitCheck = true;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 24;
        }

        public override void AI()
        {
            this.rot += 2.0f;
            projectile.Center = Main.npc[(int)projectile.ai[1]].Center + AntiarisUtils.RotateVector(new Vector2(), this.rotVec, this.rot + projectile.ai[0] * 3.14f);
            for (int k = 0; k < 1; k++)
            {
                float x = projectile.velocity.X / 3f * (float)k;
                float y = projectile.velocity.Y / 3f * (float)k;
                int type = 90;
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, type, 0.0f, 0.0f, 0, new Color(), 2f);
                Main.dust[dust].position.X = projectile.Center.X - x;
                Main.dust[dust].position.Y = projectile.Center.Y - y;
                Main.dust[dust].velocity *= 0.0f;
                Main.dust[dust].noGravity = true;
                Main.dust[dust].scale = 1.2f;
            }
        }
    }
}
