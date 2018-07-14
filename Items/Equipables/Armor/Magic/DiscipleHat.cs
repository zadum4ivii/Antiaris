using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Magic
{
    [AutoloadEquip(EquipType.Head)]
    public class DiscipleHat : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 30;
            item.rare = 1;
            item.defense = 2;
            item.value = Item.sellPrice(0, 0, 15, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Disciple's Hat");
            Tooltip.SetDefault("5% increased magic critical strike chance");
            DisplayName.AddTranslation(GameCulture.Chinese, "门徒法帽");
            Tooltip.AddTranslation(GameCulture.Chinese, "魔法致命一击概率增加 5%");
            DisplayName.AddTranslation(GameCulture.Russian, "Шляпа ученика");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает шанс магического критического урона на 5%");
        }

        public override void UpdateEquip(Player player)
        {
            player.magicCrit += 5;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("DiscipleRobe") && legs.type == mod.ItemType("DisciplePants");
        }

        public override void UpdateArmorSet(Player player)
        {
			AntiarisPlayer.spellFail -= 3;
            player.statManaMax2 += 20;
            string DiscipleSetBonus = Language.GetTextValue("Mods.Antiaris.DiscipleSetBonus");
            player.setBonus = DiscipleSetBonus;
            var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
            aPlayer.discipleSet = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "RuneStone", 3);
            recipe.AddIngredient(ItemID.Silk, 3);
            recipe.SetResult(this);
            recipe.AddTile(86);
            recipe.AddRecipe();
        }
    }
}
