using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Enums;
using Terraria.GameContent.Shaders;
using Terraria.Graphics.Effects;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Magic
{
    public class PocketBlackholeBeam : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = -1;
            projectile.alpha = 255;
            projectile.tileCollide = false;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 35;
			projectile.timeLeft = 1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pocket Blackhole");
			DisplayName.AddTranslation(GameCulture.Chinese, "袖珍黑洞");
			DisplayName.AddTranslation(GameCulture.Russian, "Карманная чёрная дыра");
        }

        public override void AI()
        {
			projectile.timeLeft++;
            //from vanilla
            Vector2? nullable = new Vector2?();
            if (projectile.velocity.HasNaNs() || projectile.velocity == Vector2.Zero)
                projectile.velocity = -Vector2.UnitY;
            if (projectile.type != mod.ProjectileType("PocketBlackholeBeam") || !Main.projectile[(int)projectile.ai[1]].active || Main.projectile[(int)projectile.ai[1]].type != mod.ProjectileType("PocketBlackhole"))
            {
                projectile.Kill();
            }
            else
            {
                float num1 = (float)(int)projectile.ai[0] - 2.5f;
                Vector2 vector2_1 = Vector2.Normalize(Main.projectile[(int)projectile.ai[1]].velocity);
                Projectile projectile1 = Main.projectile[(int)projectile.ai[1]];
                float num2 = num1 * 0.5235988f;
                Vector2 zero = Vector2.Zero;
                float num3;
                float y;
                float num4;
                float num5;
                if ((double)projectile1.ai[0] < 180.0)
                {
                    num3 = (float)(1.0 - (double)projectile1.ai[0] / 180.0);
                    y = (float)(20.0 - (double)projectile1.ai[0] / 180.0 * 14.0);
                    if ((double)projectile1.ai[0] < 120.0)
                    {
                        num4 = (float)(20.0 - 4.0 * ((double)projectile1.ai[0] / 120.0));
                        projectile.Opacity = (float)((double)projectile1.ai[0] / 120.0 * 0.400000005960464);
                    }
                    else
                    {
                        num4 = (float)(16.0 - 10.0 * (((double)projectile1.ai[0] - 120.0) / 60.0));
                        projectile.Opacity = (float)(0.400000005960464 + ((double)projectile1.ai[0] - 120.0) / 60.0 * 0.600000023841858);
                    }
                    num5 = (float)((double)projectile1.ai[0] / 180.0 * 20.0 - 22.0);
                }
                else
                {
                    num3 = 0.0f;
                    num4 = 1.75f;
                    y = 6f;
                    projectile.Opacity = 1f;
                    num5 = -2f;
                }
                float num6 = (float)(((double)projectile1.ai[0] + (double)num1 * (double)num4) / ((double)num4 * 6.0) * 6.28318548202515);
                float num7 = Vector2.UnitY.RotatedBy((double)num6, new Vector2()).Y * 0.5235988f * num3;
                Vector2 vector2_2 = (Vector2.UnitY.RotatedBy((double)num6, new Vector2()) * new Vector2(4f, y)).RotatedBy((double)projectile1.velocity.ToRotation(), new Vector2());
                projectile.position = projectile1.Center + vector2_1 * 16f - projectile.Size / 2f + new Vector2(0.0f, -Main.projectile[(int)projectile.ai[1]].gfxOffY);
                Projectile projectile2 = projectile;
                Vector2 vector2_3 = projectile2.position + projectile1.velocity.ToRotation().ToRotationVector2() * num5;
                projectile2.position = vector2_3;
                Projectile projectile3 = projectile;
                Vector2 vector2_4 = projectile3.position + vector2_2;
                projectile3.position = vector2_4;
                projectile.velocity = Vector2.Normalize(projectile1.velocity).RotatedBy((double)num7, new Vector2());
                projectile.scale = (float)(1.79999995231628 * (1.0 - (double)num3));
                projectile.damage = projectile1.damage;
                if ((double)projectile1.ai[0] >= 180.0)
                {
                    projectile.damage *= 3;
                    nullable = new Vector2?(projectile1.Center);
                }
                if (!Collision.CanHitLine(Main.player[projectile.owner].Center, 0, 0, projectile1.Center, 0, 0))
                    nullable = new Vector2?(Main.player[projectile.owner].Center);
                projectile.friendly = (double)projectile1.ai[0] > 30.0;
                if (projectile.velocity.HasNaNs() || projectile.velocity == Vector2.Zero)
                    projectile.velocity = -Vector2.UnitY;
                float rotation1 = projectile.velocity.ToRotation();
                projectile.rotation = rotation1 - 1.570796f;
                projectile.velocity = rotation1.ToRotationVector2();
                float num8 = 2f;
                float num9 = 0.0f;
                Vector2 center = projectile.Center;
                if (nullable.HasValue)
                    center = nullable.Value;
                float[] samples = new float[(int)num8];
                Collision.LaserScan(center, projectile.velocity, num9 * projectile.scale, 2400f, samples);
                float num10 = 0.0f;
                for (int index = 0; index < samples.Length; ++index)
                    num10 += samples[index];
                float num11 = num10 / num8;
                float amount = 0.75f;
                projectile.localAI[1] = MathHelper.Lerp(projectile.localAI[1], num11, amount);
                if ((double)Math.Abs(projectile.localAI[1] - num11) >= 100.0 || (double)projectile.scale <= 0.150000005960464)
                    return;
                Color rgb = new Color(253, 108, 227);
                rgb.A = (byte)0;
                Vector2 Position = projectile.Center + projectile.velocity * (projectile.localAI[1] - 14.5f * projectile.scale);
                float x = Main.rgbToHsl(new Color(253, 108, 227)).X;
                DelegateMethods.v3_1 = rgb.ToVector3() * 0.3f;
                float num14 = 0.1f * (float)Math.Sin((double)Main.GlobalTime * 20.0);
                Vector2 size = new Vector2(projectile.velocity.Length() * projectile.localAI[1], (float)projectile.width * projectile.scale);
                float rotation2 = projectile.velocity.ToRotation();
                if (Main.netMode != 2)
                    ((WaterShaderData)Filters.Scene["WaterDistortion"].GetShader()).QueueRipple(projectile.position + new Vector2(size.X * 0.5f, 0.0f).RotatedBy((double)rotation2, new Vector2()), new Color(0.5f, (float)(0.100000001490116 * (double)Math.Sign(num14) + 0.5), 0.0f, 1f) * Math.Abs(num14), size, RippleShape.Square, rotation2);
                Utils.PlotTileLine(projectile.Center, projectile.Center + projectile.velocity * projectile.localAI[1], (float)projectile.width * projectile.scale, new Utils.PerLinePoint(DelegateMethods.CastLight));
				for (int index = 0; index < 2; ++index)
                {
                    float num12 = projectile.velocity.ToRotation() + (float)((Main.rand.Next(2) == 1 ? -1.0 : 1.0) * 1.57079637050629);
                    float num13 = (float)(Main.rand.NextDouble() * 0.800000011920929 + 1.0);
                    Vector2 vector2_5 = new Vector2((float)Math.Cos((double)num12) * num13, (float)Math.Sin((double)num12) * num13);
                    int dustIndex = Dust.NewDust(Position, 0, 0, 70, vector2_5.X, vector2_5.Y, 0, new Color(253, 108, 227), 3.3f);
                    Main.dust[dustIndex].color = rgb;
                    Main.dust[dustIndex].scale = 1.2f;
                    if ((double)projectile.scale > 1.0)
                    {
                        Main.dust[dustIndex].velocity *= projectile.scale;
                        Main.dust[dustIndex].scale *= projectile.scale;
                    }
                    Main.dust[dustIndex].noGravity = true;
                    if ((double)projectile.scale != 1.39999997615814)
                    {
                        Dust dust = Dust.CloneDust(dustIndex);
                        //dust.color = Color.Purple;
                        dust.scale /= 2f;
                    }
                    float Saturation = (float)(((double)x + (double)Main.rand.NextFloat() * 0.400000005960464) % 1.0);
                    Main.dust[dustIndex].color = Color.Lerp(rgb, Main.hslToRgb(2.55f, Saturation, 0.53f), projectile.scale / 1.4f);
                }
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (projectile.velocity == Vector2.Zero)
                return false;
            Texture2D tex = Main.projectileTexture[projectile.type];
            float num1 = projectile.localAI[1];
            Color rgb = Main.hslToRgb(2.55f, GetHue(projectile.ai[0]), 0.53f);
            rgb.A = (byte)0;
            Vector2 vector2_1 = projectile.Center.Floor() + projectile.velocity * projectile.scale * 10.5f;
            float num2 = num1 - projectile.scale * 14.5f * projectile.scale;
			Vector2 scale = new Vector2(projectile.scale);
			
            DelegateMethods.f_1 = 1f;
            DelegateMethods.c_1 = rgb * 0.75f * projectile.Opacity;
            Vector2 oldPo = projectile.oldPos[0];
            Vector2 vector2_2 = new Vector2((float)projectile.width, (float)projectile.height) / 2f + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition;
            Utils.DrawLaser(Main.spriteBatch, tex, vector2_1 - Main.screenPosition, vector2_1 + projectile.velocity * num2 - Main.screenPosition, scale, new Utils.LaserLineFraming(DelegateMethods.RainbowLaserDraw));
            DelegateMethods.c_1 = new Color(253, 108, 227, (int)sbyte.MaxValue) * 0.75f * projectile.Opacity;
            Utils.DrawLaser(Main.spriteBatch, tex, vector2_1 - Main.screenPosition, vector2_1 + projectile.velocity * num2 - Main.screenPosition, scale / 2f, new Utils.LaserLineFraming(DelegateMethods.RainbowLaserDraw));
            return false;
        }

        public override void CutTiles()
        {
            DelegateMethods.tilecut_0 = TileCuttingContext.AttackProjectile;
            Utils.PlotTileLine(projectile.Center, projectile.Center + projectile.velocity * projectile.localAI[1], (float)projectile.width * projectile.scale, new Utils.PerLinePoint(DelegateMethods.CutTiles));
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            if (projHitbox.Intersects(targetHitbox))
                return new bool?(true);
            float collisionPoint = 0.0f;
            if (Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), projectile.Center, projectile.Center + projectile.velocity * projectile.localAI[1], 22f * projectile.scale, ref collisionPoint))
                return new bool?(true);
            return new bool?(false);
        }

        public float GetHue(float indexing)
        {
            return (float)(int)indexing / 6f;
        }
    }
}
