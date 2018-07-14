using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Accessories
{
    public class LifeRingEffect : ModProjectile
    {
        private float rot;
        private Vector2 rotVec = new Vector2(0.0f, 100.0f);

        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.aiStyle = -1;
            projectile.tileCollide = false;
            projectile.ownerHitCheck = true;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 28;
        }

        public override void AI()
        {
            this.rot += 0.5f;
            projectile.Center = Main.player[projectile.owner].Center + AntiarisUtils.RotateVector(new Vector2(), this.rotVec, this.rot + projectile.ai[0] * 3.14f);
            if (Main.rand.NextBool(1, 5))
            {
                float x = projectile.velocity.X / 3f;
                float y = projectile.velocity.Y / 3f;
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 90, 0.0f, 0.0f, 0, new Color(), 1.4f);
                Main.dust[dust].position.X = projectile.Center.X - x;
                Main.dust[dust].position.Y = projectile.Center.Y - y;
                Main.dust[dust].noGravity = true;
                Main.dust[dust].scale += Main.rand.NextFloat() * 1f;
            }
        }
    }
}
