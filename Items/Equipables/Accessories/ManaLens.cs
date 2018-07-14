using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    public class ManaLens : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 38;
            item.rare = 4;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mana Lens");
            Tooltip.SetDefault("Attacks has a chance to inflict Lovestruck effect on enemies\nGrants a chance to restore mana when hitting an enemy which is under Lovestruck effect");
            DisplayName.AddTranslation(GameCulture.Chinese, "魔力晶状体");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、攻击有概率对敌人造成“坠入爱河”效果\n2、击中获得“坠入爱河”效果下的敌人时，有概率恢复魔力值");
            DisplayName.AddTranslation(GameCulture.Russian, "Линза маны");
            Tooltip.AddTranslation(GameCulture.Russian, "Атаки имеют шанс наложить эффект Влюблённости на врагов\nДаёт шанс восстановить ману при ударе по врагу, находящемуся под эффектом Влюблённости");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
            aPlayer.manaPrism = true;
        }
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Glass, 25);
            recipe.AddIngredient(ItemID.CrystalShard, 12);
			recipe.AddIngredient(ItemID.ManaCrystal, 2);
			recipe.AddIngredient(ItemID.SoulofLight, 6);
            recipe.SetResult(this);
            recipe.AddTile(125);
            recipe.AddRecipe();
        }
    }
}