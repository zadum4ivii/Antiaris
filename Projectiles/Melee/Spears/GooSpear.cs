using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Melee.Spears
{
	public class GooSpear : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = 19;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.scale = 1.3f;
			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.alpha = 0;
			projectile.glowMask = AntiarisGlowMasks.GooSpear;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Goo Spear");
            DisplayName.AddTranslation(GameCulture.Chinese, "凝胶矛");
            DisplayName.AddTranslation(GameCulture.Russian, "Копье из слищи");
		}
		
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public float movementFactor 
		{
			get { return projectile.ai[0]; }
			set { projectile.ai[0] = value; }
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
            Player projOwner = player;
            Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
			projectile.direction = projOwner.direction;
			projOwner.heldProj = projectile.whoAmI;
			projOwner.itemTime = projOwner.itemAnimation;
			projectile.position.X = ownerMountedCenter.X - (float)(projectile.width / 2);
			projectile.position.Y = ownerMountedCenter.Y - (float)(projectile.height / 2);
			if (!projOwner.frozen)
			{
				if (movementFactor == 0f) 
				{
					movementFactor = 3f;
					projectile.netUpdate = true;
				}
				if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3)
				{
					movementFactor -= 2.4f;
				}
				else
				{
					movementFactor += 2.1f;
				}
			}
			projectile.position += projectile.velocity * movementFactor;
			if (projOwner.itemAnimation == 0)
			{
				projectile.Kill();
			}
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + MathHelper.ToRadians(135f);
			if (projectile.spriteDirection == -1)
			{
				projectile.rotation -= MathHelper.ToRadians(90f);
			}
            if (player.itemAnimation < player.itemAnimationMax / 3)
            {
                projectile.ai[0] -= 1.1f;
                if (projectile.localAI[0] == 0f)
                {
                    projectile.localAI[0] = 1f;
                    if (Collision.CanHit(player.position, player.width, player.height, new Vector2(projectile.Center.X + projectile.velocity.X * projectile.ai[0], projectile.Center.Y + projectile.velocity.Y * projectile.ai[0]), projectile.width, projectile.height))
                    {
                        Projectile.NewProjectile(projectile.Center.X + projectile.velocity.X, projectile.Center.Y + projectile.velocity.Y, projectile.velocity.X * 2f, projectile.velocity.Y * 2, mod.ProjectileType("SlimeGoo"), projectile.damage, projectile.knockBack * 0.85f, projectile.owner, 0f, 0f);
                    }
                }
            }
        }
	}
}
