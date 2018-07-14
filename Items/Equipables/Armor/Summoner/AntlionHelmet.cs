using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Summoner
{
    [AutoloadEquip(EquipType.Head)]
    public class AntlionHelmet : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.rare = 3;
            item.defense = 4;
			item.value = Item.sellPrice(0, 1, 0, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Antlion Helmet");
			DisplayName.AddTranslation(GameCulture.Chinese, "蚁狮头盔");
            DisplayName.AddTranslation(GameCulture.Russian, "Шлем муравьиного льва");
            Tooltip.SetDefault("5% increased minion damage\nIncreases your max number of minions");
			Tooltip.AddTranslation(GameCulture.Chinese, "增加 5% 召唤伤害\n2、增加召唤物最大上限");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает урон миньонов на 5%\nУвеличивает максимальное количество миньонов");
        }

        public override void UpdateEquip(Player player)
        {
			player.minionDamage += 0.05f;
			player.maxMinions += 1;
		}

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("AntlionBreastplate") && legs.type == mod.ItemType("AntlionLeggings");
        }

        public override void UpdateArmorSet(Player player)
        {
            string AntlionSetBonus = Language.GetTextValue("Mods.Antiaris.AntlionSetBonus");
            player.setBonus = AntlionSetBonus;
            var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
            aPlayer.swarmerS = true;
			aPlayer.antlionSet = true;
            if (player.ownedProjectileCounts[mod.ProjectileType("AntlionSummon")] > 0)
            {
                player.minionDamage += 0.1f * player.ownedProjectileCounts[mod.ProjectileType("AntlionSummon")];
                player.statDefense += 2 * player.ownedProjectileCounts[mod.ProjectileType("AntlionSummon")];
                player.endurance += 0.05f * player.ownedProjectileCounts[mod.ProjectileType("AntlionSummon")];
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AntlionMandible, 2);
			recipe.AddIngredient(ItemID.BeeHeadgear);
            recipe.AddIngredient(null, "AntlionCarapace", 12);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
