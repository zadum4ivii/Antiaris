using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(EquipType.Wings)]
	public class SatWings : ModItem
	{
	    public override void SetDefaults()
		{
			item.width = 34;
			item.height = 38;
			item.value = 10000;
			item.rare = 8;
			item.accessory = true;
		}

	    public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sat's Wings");
            Tooltip.SetDefault("Allows flight and slow fall");
            DisplayName.AddTranslation(GameCulture.Chinese, "Sat的双翼");
            Tooltip.AddTranslation(GameCulture.Chinese, "允许飞行和缓慢降落");
            DisplayName.AddTranslation(GameCulture.Russian, "Крылья Сата");
            Tooltip.AddTranslation(GameCulture.Russian, "Позволяют летать и медленно падать");
        }

	    public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 150;
			if(Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y) > 1f && !player.rocketFrame)
			{
				if (player.direction == 1)
				{
			    	for (var i = 0; i < 5; i++) 
					{ 
						Dust.NewDust(player.position - new Vector2(24f, 0f), player.width, player.height, 62, 0, 0, 0, Color.White); 
					} 
				}
				
				if (player.direction == -1)
				{
			    	for (var i = 0; i < 5; i++) 
					{ 
						Dust.NewDust(player.position + new Vector2(24f, 0f), player.width, player.height, 62, 0, 0, 0, Color.White); 
					} 
				}
			}	
		}

	    public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.35f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.135f;
		}

	    public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 14f;
			acceleration *= 2.5f;
		}

	    public override void AddRecipes()
	    {
	        ModRecipe recipe = new ModRecipe(mod);
	        recipe.AddIngredient(ItemID.DemonWings);
	        recipe.AddIngredient(null, "Shadowflame", 14);
	        recipe.AddIngredient(null, "WrathElement", 10);
            recipe.AddIngredient(ItemID.SoulofFlight, 10);
	        recipe.SetResult(this);
	        recipe.AddTile(412);
	        recipe.AddRecipe();
	    }
    }
}