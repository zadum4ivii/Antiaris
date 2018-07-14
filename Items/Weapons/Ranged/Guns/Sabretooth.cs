using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Guns
{
    public class Sabretooth : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 38;
            item.ranged = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = 1;
			item.noUseGraphic = true;
            item.noMelee = true;
            item.knockBack = 3;
            item.rare = 8;
            item.UseSound = SoundID.Item39;
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 55f;
			item.value = Item.sellPrice(0, 12, 0, 0);
            item.useAmmo = AmmoID.Bullet;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sabretooth");
            Tooltip.SetDefault("Rapidly throws shroomite needles\nUses bullets as ammo");
            DisplayName.AddTranslation(GameCulture.Chinese, "剑齿真菌");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、使用子弹作为弹药\n2、迅速的抛射出针状真菌");
            DisplayName.AddTranslation(GameCulture.Russian, "Саблезубый");
            Tooltip.AddTranslation(GameCulture.Russian, "Быстро стреляет грибнитовыми иголками\nИспользует пули в качестве патронов");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {   
            int ShotAmt = 5;
            int spread = 250; 
            float spreadMult = 0.35f;

			Vector2 vector2 = new Vector2();
			
			for(int i = 0; i < ShotAmt; i++)
            {
                float vX = 8*speedX+(float)Main.rand.Next(-spread,spread+1) * spreadMult;
                float vY = 8*speedY+(float)Main.rand.Next(-spread,spread+1) * spreadMult;
				
				float angle = (float)Math.Atan(vY/vX);
				vector2 = new Vector2(position.X+75f*(float)Math.Cos(angle), position.Y+75f*(float)Math.Sin(angle));
				float mouseX = (float)Main.mouseX + Main.screenPosition.X;
				if(mouseX < player.position.X)
				{
					vector2 = new Vector2(position.X-75f*(float)Math.Cos(angle), position.Y-75f*(float)Math.Sin(angle));
				}

               Projectile.NewProjectile(vector2.X,vector2.Y,vX,vY,mod.ProjectileType("ShroomiteNeedle"),damage,knockBack,Main.myPlayer);

     
            }
            return false;
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ShroomiteBar, 30);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
