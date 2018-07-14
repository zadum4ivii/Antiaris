	using System.Collections.Generic;
	using Microsoft.Xna.Framework;
	using Terraria;
	using Terraria.ID;
	using Terraria.Localization;
	using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Summoning    
{
    public class AntlionStave : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 20; 
            item.mana = 10;    
            item.width = 38;   
            item.height = 38;    
            item.useTime = 36;
            item.useAnimation = 36;
            item.useStyle = 1; 
            item.noMelee = true;
            item.knockBack = 2.5f; 
            item.value = Item.buyPrice(0, 3, 0, 0); 
            item.rare = 3;
            item.UseSound = SoundID.Item44;  
            item.autoReuse = true; 
            item.shoot = mod.ProjectileType("Antlion");   
            item.summon = true;   
        }

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Antlion Stave");
            DisplayName.AddTranslation(GameCulture.Russian, "Посох муравьиного льва");
            DisplayName.AddTranslation(GameCulture.Chinese, "蚁狮法杖");
			Tooltip.SetDefault("Summons an antlion that rapidly spits out a burst of sand");
            Tooltip.AddTranslation(GameCulture.Chinese, "召唤一个能够迅速发射沙子的蚁狮");          
            Tooltip.AddTranslation(GameCulture.Russian, "Призывает муравьиного льва, который часто выплёвывает песок");
		}

        public override bool CanUseItem(Player player)
        {
            List<Projectile> projectileList = new List<Projectile>();
            for (int k = 0; k < 1000; k++)
            {
                if (Main.projectile[k].WipableTurret)
                    projectileList.Add(Main.projectile[k]);
            }
            int projectiles = 0;
            while (projectileList.Count >= player.maxTurrets && ++projectiles < 1000)
            {
                Projectile projectile = projectileList[0];
                for (int k = 1; k < projectileList.Count; k++)
                {
                    if (projectileList[k].timeLeft < projectile.timeLeft)
                        projectile = projectileList[k];
                }
                projectile.Kill();
                projectileList.Remove(projectile);
            }
            return true;
        }
 
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 SPos = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);   
            position = SPos;
            return true;
        }
    }
}
