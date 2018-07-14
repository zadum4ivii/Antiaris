using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    [AutoloadEquip(new EquipType[] { EquipType.HandsOn })]
    public class CrimtaneSiphonRing : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.value = Item.sellPrice(0, 0, 80, 15);
            item.rare = 1;
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crimtane Siphon Ring");
            Tooltip.SetDefault("Summons a magical circle around the player\nKilling an enemy in the circle restores 15% of mana\n10% decreased maximum amount of mana");
			DisplayName.AddTranslation(GameCulture.Chinese, "虹吸血戒");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、在玩家周围召唤一个魔法圈\n2、在魔法圈内击中敌人时可以恢复 15% 的魔力\n3、减少 10% 最大魔力值");
            DisplayName.AddTranslation(GameCulture.Russian, "Кримтановое кольцо сифона");
            Tooltip.AddTranslation(GameCulture.Russian, "Призывает магическое кольцо вокруг игрока\nУбийство врага в кольце восстанавливает 15% маны\nНа 10% понижает максимальное количество маны");
        }

        public override bool CanEquipAccessory(Player player, int slot)
        {
            if (player.GetModPlayer<AntiarisPlayer>(mod).ringEquip) return false;
            return true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AntiarisPlayer>(mod).ringEquip = true;
            player.GetModPlayer<AntiarisPlayer>(mod).mRing = true;
            player.statManaMax2 -= player.statManaMax2 / 10;
            if (!hideVisual) for(int k = 0; k < 2; k++) Projectile.NewProjectile(player.Center.X, player.Center.Y, 0.0f, 0.0f, mod.ProjectileType("ManaRingEffect"), 0, 0.0f, player.whoAmI, (float)k, 0.0f);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneBar, 15);
            recipe.AddIngredient(ItemID.ManaCrystal, 2);
            recipe.SetResult(this);
            recipe.AddTile(TileID.Anvils);
            recipe.AddRecipe();
        }
    }
}
