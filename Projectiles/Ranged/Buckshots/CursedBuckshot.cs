using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Projectiles.Ranged.Buckshots
{
    public class CursedBuckshot : ModProjectile
    {
        int timer;

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 28;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 600;
            projectile.extraUpdates = 1;
            projectile.alpha = 255;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 2;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            aiType = ProjectileID.Bullet;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Buckshot");
            DisplayName.AddTranslation(GameCulture.Chinese, "咒怨火铳弹");
            DisplayName.AddTranslation(GameCulture.Russian, "Проклятая картечь");
        }

        public void OverhaulInit()
        {
            this.SetTag("bullet");
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 10;
			height = 10;
			return true;
		}

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 8; k++)
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 75, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
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
            var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
            if (projectile.owner == Main.myPlayer && aPlayer.boilingPoint)
			{
				target.AddBuff(BuffID.OnFire, 120, false);
			}
			if (projectile.owner == Main.myPlayer && aPlayer.cherryBlossom)
			{
				target.AddBuff(BuffID.Poisoned, 120, false);
			}
			if (projectile.owner == Main.myPlayer && aPlayer.despairingFlames)
			{
				target.AddBuff(mod.BuffType("DespairingFlames"), 120, false);
			}
			if (projectile.owner == Main.myPlayer && aPlayer.thoriumBlunderbuss)
			{
				projectile.penetrate++;
			}
		}

        public override void AI()
		{
			timer++;
			foreach (NPC npc in Main.npc)
			{
				if((double)Vector2.Distance(npc.Center, projectile.Center) <= 100.0)
				{
					if(timer == 30)
					{
						npc.StrikeNPC((int)(projectile.damage / 5), 1f, 1, Main.rand.Next(2) == 0 ? true : false, false, false);
						if (Main.netMode != 0)
							NetMessage.SendData(28, -1, -1, NetworkText.FromLiteral(""), npc.whoAmI, (float)1, 1f, (float)1, (int)(projectile.damage / 5));
						timer = 0;
					}
				}
			}		
		}

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }
    }
}
