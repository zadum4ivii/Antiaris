using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Summoning
{
    public class PocketCursedMirror2 : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 30;
            item.maxStack = 20;
            item.rare = 4;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.consumable = true;
        }

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pocket Cursed Mirror");
			Tooltip.SetDefault("Summons Tower Keeper");
			DisplayName.AddTranslation(GameCulture.Russian, "Карманное проклятое зеркало");
			Tooltip.AddTranslation(GameCulture.Russian, "Призывает Хранителя башни");
			DisplayName.AddTranslation(GameCulture.Chinese, "袖珍魔镜");
			Tooltip.AddTranslation(GameCulture.Chinese, "召唤守塔魔像");
		}


        public override bool CanUseItem(Player player)
		{
			return Main.hardMode && player.ZoneCrimson && !NPC.AnyNPCs(mod.NPCType("TowerKeeperNonActive")) && !NPC.AnyNPCs(mod.NPCType("TowerKeeper")) && !NPC.AnyNPCs(mod.NPCType("TowerKeeper2"));
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneBar, 12);
			recipe.AddIngredient(ItemID.SoulofNight, 6);
			recipe.AddIngredient(null, "MirrorShard", 4);
			recipe.AddIngredient(null, "BloodyChargedCrystal", 5);
			recipe.AddIngredient(ItemID.Glass, 10);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }

        public override bool UseItem(Player player)
        {
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            if (Main.netMode != 1)
            {
                NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("TowerKeeper"));
            }
            return true;
        }
    }
}
