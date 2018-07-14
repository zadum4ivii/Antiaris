using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Pets
{
    public class LivingEmerald : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 1;
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.TrailingMode[projectile.type] = 2;
            ProjectileID.Sets.LightPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.penetrate = -1;
            projectile.netImportant = true;
            projectile.timeLeft *= 5;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.scale = 1f;
            projectile.tileCollide = false;
            projectile.width = 28;
            projectile.height = 28;
            projectile.aiStyle = -1;
            aiType = 500;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override void AI()
        {
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
            //from vanilla
            var flag = projectile.type == mod.ProjectileType("LivingEmerald");
            var modPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
            if (flag)
            {
                if (player.dead)
                {
                    modPlayer.livingEmerald = false;
                }
                if (modPlayer.livingEmerald)
                {
                    projectile.timeLeft = 2;
                }
            }
            if (Main.rand.Next(4) == 0)
            {
                var index = Dust.NewDust(projectile.position - projectile.velocity, projectile.width, projectile.height, 61, 0.0f, 0.0f, 0, new Color(), 1f);
                Main.dust[index].noGravity = true;
                Main.dust[index].velocity *= 0.15f;
                Main.dust[index].shader = GameShaders.Armor.GetSecondaryShader(Main.player[projectile.owner].cLight, Main.player[projectile.owner]);
            }
            projectile.rotation += projectile.velocity.X / 20f;
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.4f) / 255f, ((255 - projectile.alpha) * 0.3f) / 255f);
            if (!player.active)
            {
                projectile.active = false;
            }
            else
            {
                bool flag1 = projectile.type == 393 || projectile.type == 394 || projectile.type == 395;
                Vector2 vector2_1 = player.Center;
                if (flag1)
                {
                    vector2_1.X -= (float)((15 + player.width / 2) * player.direction);
                    vector2_1.X -= (float)(projectile.minionPos * 40 * player.direction);
                }
                if (projectile.type == mod.ProjectileType("LivingEmerald"))
                {
                    vector2_1.X -= (float)((15 + player.width / 2) * player.direction);
                    vector2_1.X -= (float)(40 * player.direction);
                }
                bool flag2 = true;
                if (projectile.type == mod.ProjectileType("LivingEmerald") || projectile.type == 653)
                    flag2 = false;
                int index1 = -1;
                float num1 = 450f;
                if (flag1)
                    num1 = 800f;
                int num2 = 15;
                Vector2 vector2_2;
                if ((double)projectile.ai[0] == 0.0 && flag2)
                {
                    NPC minionAttackTargetNpc = projectile.OwnerMinionAttackTargetNPC;
                    if (minionAttackTargetNpc != null && minionAttackTargetNpc.CanBeChasedBy((object)projectile, false))
                    {
                        vector2_2 = minionAttackTargetNpc.Center - projectile.Center;
                        float num3 = vector2_2.Length();
                        if ((double)num3 < (double)num1)
                        {
                            index1 = minionAttackTargetNpc.whoAmI;
                            num1 = num3;
                        }
                    }
                    if (index1 < 0)
                    {
                        for (int index2 = 0; index2 < 200; ++index2)
                        {
                            NPC npc = Main.npc[index2];
                            if (npc.CanBeChasedBy((object)this, false))
                            {
                                vector2_2 = npc.Center - projectile.Center;
                                float num3 = vector2_2.Length();
                                if ((double)num3 < (double)num1)
                                {
                                    index1 = index2;
                                    num1 = num3;
                                }
                            }
                        }
                    }
                }
                if ((double)projectile.ai[0] == 1.0)
                {
                    projectile.tileCollide = false;
                    float num3 = 0.2f;
                    float num4 = 10f;
                    int num5 = 200;
                    if ((double)num4 < (double)Math.Abs(player.velocity.X) + (double)Math.Abs(player.velocity.Y))
                        num4 = Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y);
                    Vector2 vector2_3 = player.Center - projectile.Center;
                    float num6 = vector2_3.Length();
                    if ((double)num6 > 2000.0)
                        projectile.position = player.Center - new Vector2((float)projectile.width, (float)projectile.height) / 2f;
                    if ((double)num6 < (double)num5 && (double)player.velocity.Y == 0.0 && ((double)projectile.position.Y + (double)projectile.height <= (double)player.position.Y + (double)player.height && !Collision.SolidCollision(projectile.position, projectile.width, projectile.height)))
                    {
                        projectile.ai[0] = 0.0f;
                        projectile.netUpdate = true;
                        if ((double)projectile.velocity.Y < -6.0)
                            projectile.velocity.Y = -6f;
                    }
                    if ((double)num6 >= 60.0)
                    {
                        vector2_3.Normalize();
                        vector2_3 *= num4;
                        if ((double)projectile.velocity.X < (double)vector2_3.X)
                        {
                            projectile.velocity.X += num3;
                            if ((double)projectile.velocity.X < 0.0)
                                projectile.velocity.X += num3 * 1.5f;
                        }
                        if ((double)projectile.velocity.X > (double)vector2_3.X)
                        {
                            projectile.velocity.X -= num3;
                            if ((double)projectile.velocity.X > 0.0)
                                projectile.velocity.X -= num3 * 1.5f;
                        }
                        if ((double)projectile.velocity.Y < (double)vector2_3.Y)
                        {
                            projectile.velocity.Y += num3;
                            if ((double)projectile.velocity.Y < 0.0)
                                projectile.velocity.Y += num3 * 1.5f;
                        }
                        if ((double)projectile.velocity.Y > (double)vector2_3.Y)
                        {
                            projectile.velocity.Y -= num3;
                            if ((double)projectile.velocity.Y > 0.0)
                                projectile.velocity.Y -= num3 * 1.5f;
                        }
                    }
                    if ((double)projectile.velocity.X != 0.0)
                        projectile.spriteDirection = Math.Sign(projectile.velocity.X);
                    if (flag1)
                    {
                        ++projectile.frameCounter;
                        if (projectile.frameCounter > 3)
                        {
                            ++projectile.frame;
                            projectile.frameCounter = 0;
                        }
                        if (projectile.frame < 10 | projectile.frame > 13)
                            projectile.frame = 10;
                        projectile.rotation = projectile.velocity.X * 0.1f;
                    }
                }
                if ((double)projectile.ai[0] == 2.0)
                {
                    projectile.friendly = true;
                    projectile.spriteDirection = projectile.direction;
                    projectile.rotation = 0.0f;
                    projectile.frame = 4 + (int)((double)num2 - (double)projectile.ai[1]) / (num2 / 3);
                    if ((double)projectile.velocity.Y != 0.0)
                        projectile.frame += 3;
                    projectile.velocity.Y += 0.4f;
                    if ((double)projectile.velocity.Y > 10.0)
                        projectile.velocity.Y = 10f;
                    --projectile.ai[1];
                    if ((double)projectile.ai[1] <= 0.0)
                    {
                        projectile.ai[1] = 0.0f;
                        projectile.ai[0] = 0.0f;
                        projectile.friendly = false;
                        projectile.netUpdate = true;
                        return;
                    }
                }
                if (index1 >= 0)
                {
                    float num3 = 400f;
                    float num4 = 20f;
                    if (flag1)
                        num3 = 700f;
                    if ((double)projectile.position.Y > Main.worldSurface * 16.0)
                        num3 *= 0.7f;
                    NPC npc = Main.npc[index1];
                    Vector2 center = npc.Center;
                    vector2_2 = center - projectile.Center;
                    float num5 = vector2_2.Length();
                    Collision.CanHit(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height);
                    if ((double)num5 < (double)num3)
                    {
                        vector2_1 = center;
                        if ((double)center.Y < (double)projectile.Center.Y - 30.0 && (double)projectile.velocity.Y == 0.0)
                        {
                            float num6 = Math.Abs(center.Y - projectile.Center.Y);
                            if ((double)num6 < 120.0)
                                projectile.velocity.Y = -10f;
                            else if ((double)num6 < 210.0)
                                projectile.velocity.Y = -13f;
                            else if ((double)num6 < 270.0)
                                projectile.velocity.Y = -15f;
                            else if ((double)num6 < 310.0)
                                projectile.velocity.Y = -17f;
                            else if ((double)num6 < 380.0)
                                projectile.velocity.Y = -18f;
                        }
                    }
                    if ((double)num5 < (double)num4)
                    {
                        projectile.ai[0] = 2f;
                        projectile.ai[1] = (float)num2;
                        projectile.netUpdate = true;
                    }
                }
                if ((double)projectile.ai[0] == 0.0 && index1 < 0)
                {
                    float num3 = 500f;
                    if (projectile.type == mod.ProjectileType("LivingEmerald"))
                        num3 = 200f;
                    if (projectile.type == 653)
                        num3 = 170f;
                    if (Main.player[projectile.owner].rocketDelay2 > 0)
                    {
                        projectile.ai[0] = 1f;
                        projectile.netUpdate = true;
                    }
                    Vector2 vector2_3 = player.Center - projectile.Center;
                    if ((double)vector2_3.Length() > 2000.0)
                        projectile.position = player.Center - new Vector2((float)projectile.width, (float)projectile.height) / 2f;
                    else if ((double)vector2_3.Length() > (double)num3 || (double)Math.Abs(vector2_3.Y) > 300.0)
                    {
                        projectile.ai[0] = 1f;
                        projectile.netUpdate = true;
                        if ((double)projectile.velocity.Y > 0.0 && (double)vector2_3.Y < 0.0)
                            projectile.velocity.Y = 0.0f;
                        if ((double)projectile.velocity.Y < 0.0 && (double)vector2_3.Y > 0.0)
                            projectile.velocity.Y = 0.0f;
                    }
                }
                if ((double)projectile.ai[0] == 0.0)
                {
                    projectile.tileCollide = true;
                    float num3 = 0.5f;
                    float num4 = 4f;
                    float num5 = 4f;
                    float num6 = 0.1f;
                    if ((double)num5 < (double)Math.Abs(player.velocity.X) + (double)Math.Abs(player.velocity.Y))
                    {
                        num5 = Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y);
                        num3 = 0.7f;
                    }
                    int num7 = 0;
                    bool flag3 = false;
                    float num8 = vector2_1.X - projectile.Center.X;
                    if ((double)Math.Abs(num8) > 5.0)
                    {
                        if ((double)num8 < 0.0)
                        {
                            num7 = -1;
                            if ((double)projectile.velocity.X > -(double)num4)
                                projectile.velocity.X -= num3;
                            else
                                projectile.velocity.X -= num6;
                        }
                        else
                        {
                            num7 = 1;
                            if ((double)projectile.velocity.X < (double)num4)
                                projectile.velocity.X += num3;
                            else
                                projectile.velocity.X += num6;
                        }
                        if (!flag1)
                            flag3 = true;
                    }
                    else
                    {
                        projectile.velocity.X *= 0.9f;
                        if ((double)Math.Abs(projectile.velocity.X) < (double)num3 * 2.0)
                            projectile.velocity.X = 0.0f;
                    }
                    if (num7 != 0)
                    {
                        int num9 = (int)((double)projectile.position.X + (double)(projectile.width / 2)) / 16;
                        int num10 = (int)projectile.position.Y / 16;
                        int i = num9 + num7 + (int)projectile.velocity.X;
                        for (int j = num10; j < num10 + projectile.height / 16 + 1; ++j)
                        {
                            if (WorldGen.SolidTile(i, j))
                                flag3 = true;
                        }
                    }
                    if (projectile.type == mod.ProjectileType("LivingEmerald") && (double)projectile.velocity.X != 0.0)
                        flag3 = true;
                    if (projectile.type == 653 && (double)projectile.velocity.X != 0.0)
                        flag3 = true;
                    Collision.StepUp(ref projectile.position, ref projectile.velocity, projectile.width, projectile.height, ref projectile.stepSpeed, ref projectile.gfxOffY, 1, false, 0);
                    if ((double)projectile.velocity.Y == 0.0 && flag3)
                    {
                        for (int index2 = 0; index2 < 3; ++index2)
                        {
                            int i1 = (int)((double)projectile.position.X + (double)(projectile.width / 2)) / 16;
                            if (index2 == 0)
                                i1 = (int)projectile.position.X / 16;
                            if (index2 == 2)
                                i1 = (int)((double)projectile.position.X + (double)projectile.width) / 16;
                            int j = (int)((double)projectile.position.Y + (double)projectile.height) / 16;
                            if (!WorldGen.SolidTile(i1, j))
                            {
                                if (!Main.tile[i1, j].halfBrick())
                                {
                                    if ((int)Main.tile[i1, j].slope() <= 0)
                                    {
                                        if (TileID.Sets.Platforms[(int)Main.tile[i1, j].type] && Main.tile[i1, j].active())
                                        {
                                            if (Main.tile[i1, j].inActive())
                                                continue;
                                        }
                                        else
                                            continue;
                                    }
                                }
                            }
                            try
                            {
                                int num9 = (int)((double)projectile.position.X + (double)(projectile.width / 2)) / 16;
                                int num10 = (int)((double)projectile.position.Y + (double)(projectile.height / 2)) / 16;
                                int i2 = num9 + num7 + (int)projectile.velocity.X;
                                if (!WorldGen.SolidTile(i2, num10 - 1) && !WorldGen.SolidTile(i2, num10 - 2))
                                    projectile.velocity.Y = -5.1f;
                                else if (!WorldGen.SolidTile(i2, num10 - 2))
                                    projectile.velocity.Y = -7.1f;
                                else if (WorldGen.SolidTile(i2, num10 - 5))
                                    projectile.velocity.Y = -11.1f;
                                else if (WorldGen.SolidTile(i2, num10 - 4))
                                    projectile.velocity.Y = -10.1f;
                                else
                                    projectile.velocity.Y = -9.1f;
                            }
                            catch
                            {
                                projectile.velocity.Y = -9.1f;
                            }
                        }
                    }
                    if ((double)projectile.velocity.X > (double)num5)
                        projectile.velocity.X = num5;
                    if ((double)projectile.velocity.X < -(double)num5)
                        projectile.velocity.X = -num5;
                    if ((double)projectile.velocity.X < 0.0)
                        projectile.direction = -1;
                    if ((double)projectile.velocity.X > 0.0)
                        projectile.direction = 1;
                    if ((double)projectile.velocity.X > (double)num3 && num7 == 1)
                        projectile.direction = 1;
                    if ((double)projectile.velocity.X < -(double)num3 && num7 == -1)
                        projectile.direction = -1;
                    projectile.spriteDirection = projectile.direction;
                    projectile.velocity.Y += 0.4f;
                    if ((double)projectile.velocity.Y > 10.0)
                        projectile.velocity.Y = 10f;
                }
            }
        }
    }
}