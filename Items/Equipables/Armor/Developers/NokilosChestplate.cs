using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Developers
{
    [AutoloadEquip(EquipType.Body)]
    public class NokilosChestplate : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 22;
            item.rare = 9;
			item.vanity = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nokilos' Chestplate");
            Tooltip.SetDefault("'Great for impersonating devs!'");
            DisplayName.AddTranslation(GameCulture.Russian, "Нагрудник Nokilos");
            Tooltip.AddTranslation(GameCulture.Russian, "'Поможет вам выдать себя за разработчика!'");
			DisplayName.AddTranslation(GameCulture.Chinese, "Nokilos护胸");
            Tooltip.AddTranslation(GameCulture.Chinese, "“非常适合冒充开发者！”");
        }

        public override void UpdateEquip(Player player)
        {
            if (player.name == "Nockilos")
            {
                player.meleeDamage += 19f;
                player.thrownDamage += 19f;
                player.rangedDamage += 19f;
                player.magicDamage += 19f;
                player.lifeRegen = +999;
                player.moveSpeed += 0.15f;
                player.moveSpeed += 999f;
                player.manaRegen = +999;
                player.manaCost -= 1f;
                player.statLifeMax = 500;
                player.statManaMax2 += 400;
                player.manaRegen = 1555;
                player.buffImmune[44] = true;
                player.buffImmune[46] = true;
                player.buffImmune[47] = true;
                player.buffImmune[20] = true;
                player.buffImmune[22] = true;
                player.buffImmune[24] = true;
                player.buffImmune[23] = true;
                player.buffImmune[30] = true;
                player.buffImmune[31] = true;
                player.buffImmune[32] = true;
                player.buffImmune[33] = true;
                player.buffImmune[35] = true;
                player.buffImmune[36] = true;
                player.buffImmune[69] = true;
                player.buffImmune[70] = true;
                player.buffImmune[80] = true;
                player.buffImmune[144] = true;
                player.maxMinions += 999;
				AntiarisPlayer.spellFail = 0;
            }
        }
    }
}
