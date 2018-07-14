using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Melee.Yoyos
{
	class Prescription : ModProjectile
	{
	    const int ShootRate = 60;
	    const float ShootDistance = 500f;
	    const float ShootSpeed = 10f;
	    const int ShootDamage = 38;
	    const float ShootKnockback = 4f;
	    int ShootType = -1;
	    string ShootTypeMod = "PrescriptionProjectile";
	    int TimeToShoot = ShootRate;

	    public override void SetDefaults()
		{
			projectile.extraUpdates = 0;
			projectile.width = 16;
			projectile.height = 16;
			// aiStyle 99 is used for all yoyos, and is Extremely suggested, as yoyo are extremely difficult without them
			projectile.aiStyle = 99;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1f;
		}

	    public override void SetStaticDefaults()
		{
			// The following sets are only applicable to yoyo that use aiStyle 99.
			// YoyosLifeTimeMultiplier is how long in seconds the yoyo will stay out before automatically returning to the player. 
			// Vanilla values range from 3f(Wood) to 16f(Chik), and defaults to -1f. Leaving as -1 will make the time infinite.
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 16f;
			// YoyosMaximumRange is the maximum distance the yoyo sleep away from the player. 
			// Vanilla values range from 130f(Wood) to 400f(Terrarian), and defaults to 200f
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 310f;
			// YoyosTopSpeed is top speed of the yoyo projectile. 
			// Vanilla values range from 9f(Wood) to 17.5f(Terrarian), and defaults to 10f
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 15f;
			DisplayName.SetDefault("Prescription");
            DisplayName.AddTranslation(GameCulture.Chinese, "处方药");
            DisplayName.AddTranslation(GameCulture.Russian, "Рецепт");
		}

	    // notes for aiStyle 99: 
	    // localAI[0] is used for timing up to YoyosLifeTimeMultiplier
	    // localAI[1] can be used freely by specific types
	    // ai[0] and ai[1] usually point towards the x and y world coordinate hover point
	    // ai[0] is -1f once YoyosLifeTimeMultiplier is reached, when the player is stoned/frozen, when the yoyo is too far away, or the player is no longer clicking the shoot button.
	    // ai[0] being negative makes the yoyo move back towards the player
	    // Any AI method can be used for dust, spawning projectiles, etc specific to your yoyo.

	    void Shoot()
        {
            if (--TimeToShoot <= 0)
            {
                TimeToShoot = ShootRate;
                if (ShootType == -1)
                    ShootType = mod.ProjectileType(ShootTypeMod);

                float NearestNPCDist = ShootDistance;
                int NearestNPC = -1;
                foreach (NPC npc in Main.npc)
                {
                    if (!npc.active)
                        continue;
                    if (npc.friendly || npc.lifeMax <= 5)
                        continue;
                    if (NearestNPCDist == -1 || npc.Distance(projectile.Center) < NearestNPCDist && Collision.CanHitLine(projectile.Center, 16, 16, npc.Center, 16, 16))
                    {
                        NearestNPCDist = npc.Distance(projectile.Center);
                        NearestNPC = npc.whoAmI;
                    }
                }
                if (NearestNPC == -1)
                    return;
                Vector2 Velocity = AntiarisHelper.VelocityToPoint(projectile.Center, Main.npc[NearestNPC].Center, ShootSpeed);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Velocity.X, Velocity.Y, ShootType, ShootDamage, ShootKnockback, projectile.owner);
            }
        }

	    public override void AI()
        {
            Shoot();
        }
	}
}
