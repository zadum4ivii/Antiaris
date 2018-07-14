using Antiaris.VEffects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Magic
{
	public class Lightning3 : ModProjectile
	{
	    LightningBolt bolt;

	    private float length
		{
			get
            {
                return projectile.ai[1];
            }
			set
            {
                projectile.ai[1] = value;
            }
		}

	    public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.width = 12;
			projectile.height = 12;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 120;
			projectile.tileCollide = false;
			projectile.friendly = true;
        }

	    public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lightning");
			DisplayName.AddTranslation(GameCulture.Chinese, "闪电");	
            DisplayName.AddTranslation(GameCulture.Russian, "Молния");
        }

	    public override void AI()
		{
            if (this.bolt == null)
            {
                this.bolt = new LightningBolt(projectile.position, 0, 3f);
            }
			if (projectile.wet)
			{
				projectile.hostile = true;
				projectile.friendly = false;
			}
			this.UpdateBolt();		
			if (this.bolt.Ticks <= 0 && Main.rand.NextBool(1, 2))
			{
				this.bolt = new LightningBolt(projectile.position, projectile.position + Vector2.Normalize(projectile.velocity) * this.length, Main.rand.Next(3, 5), 4f);
			}
		}

	    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			if (Main.rand.NextBool(1, 3)) target.AddBuff(mod.BuffType("Electrified"), 80, false);
        }

	    public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (projectile.wet) damage *= 3;
		}

	    public virtual void UpdateBolt()
		{
			this.length += projectile.velocity.Length();
			this.bolt.Ticks--;
		}

	    public override bool ShouldUpdatePosition()
		{
			return false;
		}

	    public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			this.bolt.Draw(spriteBatch, Color.White);
			return base.PreDraw(spriteBatch, lightColor);
		}

	    public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
		{
			Vector2 lineEnd = projectile.position + Vector2.Normalize(projectile.velocity) * this.length;
			float collisionPoint = 0f;
			return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), projectile.position, lineEnd, 10f, ref collisionPoint);
		}
	}
}
