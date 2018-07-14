using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Melee.Boomerangs
{
    public class GoldBoomerang : ModProjectile
    {
        const int ShootRate = 36;
        const float ShootDistance = 500f;
        const float ShootSpeed = 12f;
        const int ShootDamage = 22;
        const float ShootKnockback = 2;
        int ShootType = -1;
        string ShootTypeMod = "GoldBoomerangSpark";
        int TimeToShoot = ShootRate;

        public override void SetDefaults()
        {
            projectile.CloneDefaults(106);
            aiType = 106;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gold Boomerang");
            DisplayName.AddTranslation(GameCulture.Chinese, "金回旋镖");
            DisplayName.AddTranslation(GameCulture.Russian, "Золотой бумеранг");
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 10;
			height = 10;
			return true;
		}

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
