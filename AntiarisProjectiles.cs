using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Antiaris
{
    public class AntiarisProjectiles : GlobalProjectile
    {
        public override void SetDefaults(Projectile projectile)
		{
            if (AntiarisPlayer.TrapsImmune && (projectile.type == 98 || projectile.type == 99 || projectile.type == 184 || projectile.type == 185 || projectile.type == 186 || projectile.type == 187 || projectile.type == 188 || projectile.type == 189))
			{
				projectile.friendly = true;
				projectile.hostile = false;
			}
		}

        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
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
			
			if(projectile.minion)
			{
				if(aPlayer.necromancerSet && Main.rand.Next(3) == 0)
				{
					int newLife = (projectile.damage / 10) * 2;
					if(newLife > 0)
					{
						player.statLife += newLife;
						player.HealEffect(newLife);
						NetMessage.SendData(MessageID.SpiritHeal, -1, -1, null, projectile.owner, newLife);
					}
				}
			}
			
			if (projectile.aiStyle == 88 && (projectile.knockBack >= .2f && projectile.knockBack <= .5f))
            {
                target.immune[projectile.owner] = 6;
            }
        }

        public override void Kill(Projectile projectile, int timeLeft)
		{
			if (projectile.type == 134 || projectile.type == 137 || projectile.type == 140 || projectile.type == 143)
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
				if (projectile.owner == Main.myPlayer && aPlayer.Bonebardier)
				{
					int num220 = 3;
					for (int num221 = 0; num221 < num220; num221++)
					{
						Vector2 value17 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
						value17.Normalize();
						value17 *= (float)Main.rand.Next(10, 201) * 0.01f;
						Projectile.NewProjectile(projectile.position.X, projectile.position.Y, value17.X, value17.Y, 532, projectile.damage, 1f, projectile.owner, 0f, (float)Main.rand.Next(-45, 1));
					}
				}
			}
		}

        public override void AI(Projectile projectile)
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
			
            if (projectile.minion)
            {
                if (player.GetModPlayer<AntiarisPlayer>(mod).bigMinions)
                {
                    if (!player.active)
                        return;
                    projectile.scale *= 1.5f;
                    Projectile projectile1 = projectile;
                    var width = projectile1.width;
                    projectile1.width = width;
                    Projectile projectile2 = projectile;
                    var height = projectile2.height;
                    projectile2.height = height;
                    if ((double)projectile.scale >= 1.5)
                    {
                        projectile.scale = 1.5f;
                    }
                }
            }
        }
    }
}

   
    