using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Summoning    
{
    public class StardustMothercellStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 200; 
            item.mana = 10;    
            item.width = 48;   
            item.height = 48;    
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 1; 
            item.noMelee = true;
            item.knockBack = 2.5f; 
            item.value = Item.buyPrice(0, 21, 0, 0); 
            item.rare = 10;
            item.UseSound = SoundID.Item44;  
            item.autoReuse = true; 
            item.shoot = mod.ProjectileType("StardustMothercell");   
            item.summon = true;   
            item.sentry = true; 
        }

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stardust Mothercell Staff");
            DisplayName.AddTranslation(GameCulture.Russian, "Посох материнской клетки звездной пыли");
            DisplayName.AddTranslation(GameCulture.Chinese, "星尘母体细胞法杖");
			Tooltip.SetDefault("Summons a stardust mothercell\nMothercell shoot fast moving homing stardust energy at your enemies");
            Tooltip.AddTranslation(GameCulture.Chinese, "召唤一个快速向敌人发射跟踪性星尘能量的星尘母体细胞");          
            Tooltip.AddTranslation(GameCulture.Russian, "Призывает материнскую клетку звёздной пыли\nКлетка стреляет во врагов быстродвигающейся самонаводящейся энергией звёздной пыли");
		}

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse != 2)
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
            }
            return true;
        }

        public override bool AltFunctionUse(Player player)
		{
			return true;
		}

        public override bool UseItem(Player player)
		{
			if(player.altFunctionUse == 2)
			{
				player.MinionNPCTargetAim();
			}
			return base.UseItem(player);
		}

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 SPos = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);   
            position = SPos;
            for (int l = 0; l < Main.projectile.Length; l++)
            {                                                                 
                Projectile proj = Main.projectile[l];
                if (proj.active && proj.type == item.shoot && proj.owner == player.whoAmI)
                {
                    proj.active = false;
                }
            }
            return player.altFunctionUse != 2;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RainbowCrystalStaff);
            recipe.AddIngredient(ItemID.StardustCellStaff);
			recipe.AddIngredient(3459, 14);
			recipe.AddIngredient(3467, 12);
			recipe.AddIngredient(null, "WrathElement", 12);
            recipe.SetResult(this);
            recipe.AddTile(412);
            recipe.AddRecipe();
        }
    }
}
