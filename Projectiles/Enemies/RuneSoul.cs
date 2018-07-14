using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Enemies
{
    public class RuneSoul : ModProjectile
    {
        public float Distance;
        public int Target;

        float Rotation
        {
            get { return projectile.ai[0]; }
            set { projectile.ai[0] = value; }
        }

        int Owner
        {
            get { return (int)projectile.ai[1]; }
            set { projectile.ai[1] = value; }
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor) { AntiarisUtils.DrawProjectileGlowMaskWorld(spriteBatch, projectile, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), projectile.rotation, projectile.scale); }

        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 60;
            projectile.tileCollide = false;
            ProjectileID.Sets.Homing[projectile.type] = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rune Soul");
            DisplayName.AddTranslation(GameCulture.Chinese, "符文之魂");
            DisplayName.AddTranslation(GameCulture.Russian, "Душа рун");
        }

        public override void AI()
        {
			projectile.timeLeft = 60;
            if (!Main.npc[Owner].active)
            {
                projectile.Kill();
            }
            projectile.tileCollide = false;
            if (Distance <= 64f)
            {
                Distance += 1.5f;
            }
            Rotation = MathHelper.WrapAngle(Rotation + MathHelper.TwoPi / 200f);
            NPC npc = Main.npc[Owner];
            projectile.Center = npc.Center + new Vector2(0, Distance);
            projectile.Center = projectile.Center.RotatedBy(Rotation, npc.Center);
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 15, projectile.velocity.X, projectile.velocity.Y);
            }
        }
    }
}
