using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Mixed
{
    [AutoloadEquip(EquipType.Head)]
    public class GooHelmet : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.rare = 2;
            item.defense = 4;
            item.value = Item.sellPrice(0, 0, 30, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Goo Helmet");
            Tooltip.SetDefault("Increases all damage by 5% if player is moving");
            DisplayName.AddTranslation(GameCulture.Chinese, "凝胶头盔");
            Tooltip.AddTranslation(GameCulture.Chinese, "自身移动时所有类型伤害增加 5%");
            DisplayName.AddTranslation(GameCulture.Russian, "Шлем из слизи");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает весь урон на 5%, если игрок двигается");
        }
		
		public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor)
        {
            glowMask = AntiarisGlowMasks.GooHelmet;
            glowMaskColor = Color.White;
        }

        public override void UpdateEquip(Player player)
        {
			if(Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y) > 1f && !player.rocketFrame)
			{
				player.meleeDamage += 0.05f;
				player.magicDamage += 0.05f;
				player.rangedDamage += 0.05f;
				player.minionDamage += 0.05f;
				player.thrownDamage += 0.05f;
			}
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("GooBreastplate") && legs.type == mod.ItemType("GooGreaves");
        }

        public override void UpdateArmorSet(Player player)
        {
            if (NPC.AnyNPCs(1) || NPC.AnyNPCs(16) || NPC.AnyNPCs(50) || NPC.AnyNPCs(59) || NPC.AnyNPCs(71) || NPC.AnyNPCs(81) || NPC.AnyNPCs(121) || NPC.AnyNPCs(138) || NPC.AnyNPCs(147) || NPC.AnyNPCs(183) || NPC.AnyNPCs(184) || NPC.AnyNPCs(204) || NPC.AnyNPCs(225) || NPC.AnyNPCs(244) || NPC.AnyNPCs(302) || NPC.AnyNPCs(333) || NPC.AnyNPCs(334) || NPC.AnyNPCs(335) || NPC.AnyNPCs(535) || NPC.AnyNPCs(537))
            {
                player.statDefense += 5;
            }
            string EmeraldGelSetBonus = Language.GetTextValue("Mods.Antiaris.GooSetBonus");
            player.setBonus = EmeraldGelSetBonus;
        }
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "LiquifiedGoo", 1);
            recipe.AddRecipeGroup("Antiaris:WoodHelmet");
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
