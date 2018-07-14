using Antiaris.NPCs.Town;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Melee.Swords
{
    public class AdventurersMachete : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 26;
            item.melee = true;
            item.width = 36;
            item.height = 38;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 1;
            item.knockBack = 10;
            item.value = Item.sellPrice(0, 4, 0, 0);
            item.rare = 4;
            item.UseSound = SoundID.Item71;
            item.autoReuse = true;
            item.useTurn = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adventurer's Machete");
            DisplayName.AddTranslation(GameCulture.Russian, "Мачете Путешественника");
            DisplayName.AddTranslation(GameCulture.Chinese, "冒险家弯刀");
            Tooltip.SetDefault("Increases it's damage for every Adventurer's quest finished");
            Tooltip.AddTranslation(GameCulture.Chinese, "每完成一次冒险家任务即可增加一次伤害");
            Tooltip.AddTranslation(GameCulture.Russian, "Повышает урон за каждый завершённый квест Путешественника");
        }

        public void OverhaulInit()
        {
            this.SetTag("broadsword");
        }

        public override void GetWeaponDamage(Player player, ref int damage)	
		{
			var questSystem = Main.player[Main.myPlayer].GetModPlayer<QuestSystem>(mod);
			damage += questSystem.CompletedTotal;
		}
    }
}
