using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Antiaris.Projectiles.Magic
{
    public class Lightning : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 600;
            projectile.extraUpdates = 4;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 90;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lightning");
			DisplayName.AddTranslation(GameCulture.Chinese, "真正的落雷");	
            DisplayName.AddTranslation(GameCulture.Russian, "Молния");
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                if (projectile.oldPos[k] == Vector2.Zero)
                    return false;
                Vector2 position = projectile.oldPos[k] - Main.screenPosition + projectile.Size / 2f;
                spriteBatch.Draw(mod.GetTexture("Glow/Lightning_GlowMask"), position, new Rectangle?(), Color.White, 0.0f, projectile.Size / 2f, 0.65f, SpriteEffects.None, 0.0f);
            }
            return true;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            for (int k = 0; k < projectile.oldPos.Length && !(projectile.oldPos[k] == Vector2.Zero); k++)
            {
                Vector2 position = projectile.oldPos[k] - Main.screenPosition + projectile.Size / 2f;
                spriteBatch.Draw(Main.projectileTexture[projectile.type], position, new Rectangle?(), Color.White, 0.0f, projectile.Size / 2f, 0.5f, SpriteEffects.None, 0.0f);
            }
        }

        public override void OnHitNPC(NPC npc, int damage, float knockback, bool crit)
        {
            npc.immune[projectile.owner] = 3;
        }

        public override void AI()
        {
            if ((double)Vector2.Distance(Main.player[projectile.owner].Center, projectile.Center) > 1000.0)
                projectile.Kill();
            if (projectile.velocity == Vector2.Zero)
            {
                float num1 = (float)((double)projectile.rotation + 1.57079637050629 + (Main.rand.Next(2) == 1 ? -1.0 : 1.0) * 1.57079637050629);
                float num2 = (float)(Main.rand.NextDouble() * 1.25 + 1.25);
                Vector2 vector2 = new Vector2((float)Math.Cos((double)num1) * num2, (float)Math.Sin((double)num1) * num2);
            }
            if (projectile.timeLeft >= 596)
                return;
            if ((double)projectile.localAI[1] == 0.0 && (double)projectile.ai[0] >= 900.0)
            {
                projectile.ai[0] -= 1000f;
                projectile.localAI[1] = -1f;
            }
            projectile.frameCounter = projectile.frameCounter + 1;
            Lighting.AddLight(projectile.Center, 0.3f, 0.45f, 0.5f);
            if (projectile.velocity == Vector2.Zero)
            {
                if (projectile.frameCounter >= projectile.extraUpdates * 2)
                {
                    projectile.frameCounter = 0;
                    bool flag = true;
                    for (int index = 1; index < projectile.oldPos.Length; ++index)
                    {
                        if (projectile.oldPos[index] != projectile.oldPos[0])
                            flag = false;
                    }
                    if (flag)
                        projectile.Kill();
                }
                if (Main.rand.Next(projectile.extraUpdates) != 0 || !(projectile.velocity != Vector2.Zero) && Main.rand.Next((double)projectile.localAI[1] == 2.0 ? 2 : 6) != 0)
                    return;
                for (int k = 0; k < 2; k++)
                {
                    float num1 = projectile.rotation + (float)((Main.rand.Next(2) == 1 ? -1.0 : 1.0) * 1.57079637050629);
                    float num2 = (float)(Main.rand.NextDouble() * 0.800000011920929 + 1.0);
                    Vector2 vector2 = new Vector2((float)Math.Cos((double)num1) * num2, (float)Math.Sin((double)num1) * num2);
                }
                if (Main.rand.Next(5) != 0)
                    return;
                int index3 = Dust.NewDust(projectile.Center + projectile.velocity.RotatedBy(1.57079637050629, new Vector2()) * ((float)Main.rand.NextDouble() - 0.5f) * (float)projectile.width - Vector2.One * 4f, 8, 8, 31, 0.0f, 0.0f, 100, new Color(), 1.5f);
                Main.dust[index3].velocity *= 0.5f;
                Main.dust[index3].velocity.Y = -Math.Abs(Main.dust[index3].velocity.Y);
            }
            else
            {
                if (projectile.frameCounter < projectile.extraUpdates * 2)
                    return;
                projectile.frameCounter = 0;
                float num1 = projectile.velocity.Length();
                UnifiedRandom unifiedRandom = new UnifiedRandom((int)projectile.ai[1]);
                int num2 = 0;
                Vector2 spinningpoint = -Vector2.UnitY;
                Vector2 rotationVector2;
                int num3;
                do
                {
                    int num4 = unifiedRandom.Next();
                    projectile.ai[1] = (float)num4;
                    rotationVector2 = ((float)((double)(num4 % 100) / 100.0 * 6.28318548202515)).ToRotationVector2();
                    if ((double)rotationVector2.Y > 0.0)
                        rotationVector2.Y *= -1f;
                    bool flag = false;
                    if ((double)rotationVector2.Y > -0.0199999995529652)
                        flag = true;
                    if ((double)rotationVector2.X * (double)(projectile.extraUpdates + 1) * 2.0 * (double)num1 + (double)projectile.localAI[0] > 25.0)
                        flag = true;
                    if ((double)rotationVector2.X * (double)(projectile.extraUpdates + 1) * 2.0 * (double)num1 + (double)projectile.localAI[0] < -25.0)
                        flag = true;
                    if (flag)
                    {
                        num3 = num2;
                        num2 = num3 + 1;
                    }
                    else
                        goto label_36;
                }
                while (num3 < 100);
                projectile.velocity = Vector2.Zero;
                if ((double)projectile.localAI[1] < 1.0)
                {
                    projectile.localAI[1] += 2f;
                    goto label_37;
                }
                else
                    goto label_37;
                label_36:
                spinningpoint = rotationVector2;
                label_37:
                if (!(projectile.velocity != Vector2.Zero))
                    return;
                projectile.localAI[0] += (float)((double)spinningpoint.X * (double)(projectile.extraUpdates + 1) * 2.0) * num1;
                projectile.velocity = spinningpoint.RotatedBy((double)projectile.ai[0] + 1.57079637050629, new Vector2()) * num1;
                projectile.rotation = projectile.velocity.ToRotation() + 1.570796f;
                if (Main.rand.Next(5) != 0 || Main.netMode == 1 || (double)projectile.localAI[1] != 0.0)
                    return;
                Vector2 v = projectile.ai[0].ToRotationVector2().RotatedBy((double)Main.rand.Next(-1, 1) * 1.04719758033752 / 3.0, new Vector2()) * projectile.velocity.Length();
                int index = Projectile.NewProjectile(projectile.Center.X - v.X, projectile.Center.Y - v.Y, v.X, v.Y, projectile.type, projectile.damage, projectile.knockBack, projectile.owner, v.ToRotation() + 1000f, projectile.ai[1]);
                Main.projectile[index].timeLeft = 240;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.velocity.X = 0.0f;
            projectile.velocity.Y = 0.0f;
            return false;
        }
    }
}
