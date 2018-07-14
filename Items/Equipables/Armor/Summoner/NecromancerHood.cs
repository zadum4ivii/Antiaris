using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Summoner
{
    [AutoloadEquip(EquipType.Head)]
    public class NecromancerHood : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 26;
            item.rare = 8;
            item.defense = 10;
			item.value = Item.sellPrice(0, 6, 0, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Necromancer Hood");
			DisplayName.AddTranslation(GameCulture.Chinese, "死灵法师护腿");
            DisplayName.AddTranslation(GameCulture.Russian, "Капюшон некроманта");
            Tooltip.SetDefault("Increases your max amount of minions\n10% increased minion damage");
			Tooltip.AddTranslation(GameCulture.Chinese, "1、增加召唤物最大上限\n2、增加 10% 召唤物伤害");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает максимальное количество миньонов\nУвеличивает урон миньонов на 10%");
        }

        public override void UpdateEquip(Player player)
        {
			player.maxMinions += 1;
			player.minionDamage += 0.1f;
		}

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("NecromancerRobe") && legs.type == mod.ItemType("NecromancerLeggings");
        }

        public override void UpdateArmorSet(Player player)
        {		
			player.boneArmor = true;
			var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
            aPlayer.necromancerSet = true;
			string NecromancerSetBonus = Language.GetTextValue("Mods.Antiaris.NecromancerSetBonus");
            player.setBonus = NecromancerSetBonus;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "NecroCloth", 12);
            recipe.AddIngredient(ItemID.Bone, 15);
            recipe.AddIngredient(ItemID.SoulofNight, 6);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
