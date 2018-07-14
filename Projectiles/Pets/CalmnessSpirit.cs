using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Pets
{
    public class CalmnessSpirit : ModProjectile
    {
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 32;
            projectile.friendly = true;
            projectile.netImportant = true;
            projectile.timeLeft *= 5;
            projectile.ignoreWater = true;
            projectile.scale = 1.0f;
            projectile.tileCollide = false;
        }

        public override void SetStaticDefaults()
        {
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 2;
            Main.projFrames[projectile.type] = 4;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            if (projectile.alpha > 0) projectile.alpha--;
            projectile.frameCounter++;
            if (projectile.frameCounter >= 8) { projectile.frame++; projectile.frameCounter = 0; }
            if (projectile.frame >= (int)Main.projFrames[projectile.type]) projectile.frame = 0;
            float speed = 4.0f;
            Vector2 position = new Vector2((float)(player.direction * 30), -20f); position.Y += (float)Math.Cos((double)projectile.ai[0] * 0.05) * 4.0f;
            projectile.rotation = projectile.velocity.X * 0.095f;
            projectile.spriteDirection = projectile.direction;
            if (player.suspiciouslookingTentacle || player.petFlagDD2Ghost || player.GetModPlayer<AntiarisPlayer>(mod).shadowflameCandle) position.X += (float)(-player.direction * 64);
            if (!player.controlDown) projectile.direction = projectile.spriteDirection = player.direction;
            Vector2 distancePosition = player.MountedCenter + position;
            float maxDistance = Vector2.Distance(projectile.Center, distancePosition);
            if ((double)maxDistance > 1000.0) projectile.Center = player.Center + position;
            Vector2 zeroPoint = distancePosition - projectile.Center;
            if ((double)maxDistance < (double)speed)
            {
                Vector2 speedTo = projectile.velocity * 0.25f;
                projectile.velocity = speedTo;
            }
            if (zeroPoint != Vector2.Zero)
            {
                if ((double)zeroPoint.Length() < (double)speed * 0.5) projectile.velocity = zeroPoint;
                else projectile.velocity = zeroPoint * 0.1f;
            }
            ++projectile.ai[0];
            if ((double)projectile.ai[0] > 120.0) projectile.ai[0] = 0.0f;
            projectile.netUpdate = true;
            if (player.dead)
                player.GetModPlayer<AntiarisPlayer>(mod).calmnessSpirit = false;
            if (!player.GetModPlayer<AntiarisPlayer>(mod).calmnessSpirit)
                return;
            projectile.timeLeft = 2;
        }
    }
}
