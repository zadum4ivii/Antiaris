using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Pets
{
    public class ShadowflameCandle : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 44;
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
            ProjectileID.Sets.LightPet[projectile.type] = true;
            Main.projFrames[projectile.type] = 4;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            if (projectile.alpha > 0) projectile.alpha--;
			projectile.frameCounter++;
            if (projectile.frameCounter >= 6) { projectile.frame++; projectile.frameCounter = 0; }
            if (projectile.frame >= (int)Main.projFrames[projectile.type]) projectile.frame = 0;
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.8f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.9f) / 255f);
            float speed = 4.0f;
            Vector2 position = new Vector2((float)(player.direction * 30), -20f); position.Y += (float)Math.Cos((double)projectile.ai[0] * 0.05) * 4.0f;
            Vector2 dustPos = new Vector2(projectile.spriteDirection == -1 ? -6.0f : -3.0f, -20.0f).RotatedBy((double)projectile.rotation, new Vector2());
            if (Main.rand.Next(24) == 0)
            {
                Dust dust = Dust.NewDustDirect(projectile.Center + dustPos, 4, 4, 65, 0.0f, 0.0f, 100, new Color(), 1f);
                if (Main.rand.NextBool(1, 3))
                {
                    dust.noGravity = true;
                    dust.velocity.Y -= 3f;
                    dust.noLight = true;
                }
                else if (Main.rand.Next(2) != 0) dust.noLight = true;
                dust.velocity *= 0.5f;
                dust.velocity.Y -= 0.9f;
                dust.scale += (float)(0.1 + (double)Main.rand.NextFloat() * 0.6);
            }
            projectile.rotation = projectile.velocity.X * 0.095f;
            projectile.spriteDirection = projectile.direction;
            if (player.controlDown && player.velocity == Vector2.Zero && (double)player.velocity.Y == 0.0)
            {
                Vector2 vector = Main.MouseWorld;
                if ((double)projectile.position.X > (double)vector.X) projectile.direction = -1;
                else if ((double)projectile.position.X < (double)vector.X) projectile.direction = 1;
                if (Main.myPlayer != projectile.owner) return;
                float speed2 = 2.94f;
                Vector2 vector2 = vector - projectile.Center;
                float distance2 = (float)Math.Sqrt((double)vector2.X * (double)vector2.X + (double)vector2.Y * (double)vector2.Y);
                vector2 *= speed2 / distance2;
                projectile.velocity = vector2;
            }
            else
            {
                if (player.suspiciouslookingTentacle || player.petFlagDD2Ghost) position.X += (float)(-player.direction * 64);
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
            }
            ++projectile.ai[0];
            if ((double)projectile.ai[0] > 120.0) projectile.ai[0] = 0.0f;
            projectile.netUpdate = true;
            if (player.dead)
                player.GetModPlayer<AntiarisPlayer>(mod).shadowflameCandle = false;
            if (!player.GetModPlayer<AntiarisPlayer>(mod).shadowflameCandle)
                return;
            projectile.timeLeft = 2;
        }
    }
}
