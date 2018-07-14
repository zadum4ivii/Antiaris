using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Summoning
{
    public class SandstormScroll : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 32;
            item.maxStack = 999;
            item.rare = 0;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.consumable = true;
			item.UseSound = SoundID.Item34;
        }

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sandstorm Scroll");
			Tooltip.SetDefault("Starts sandstorm");
			DisplayName.AddTranslation(GameCulture.Russian, "Свиток песчаной бури");
			Tooltip.AddTranslation(GameCulture.Russian, "Начинает песчаную бурю");
			DisplayName.AddTranslation(GameCulture.Chinese, "沙暴卷轴");
			Tooltip.AddTranslation(GameCulture.Chinese, "召唤沙暴");
		}

        public override bool UseItem(Player player)
        {
            SandstormScroll.StartSandstorm();
			return true;
        }

        private static void StartSandstorm()
        {
            Sandstorm.Happening = true;
            Sandstorm.TimeLeft = (int)(3600.0 * (8.0 + (double)Main.rand.NextFloat() * 16.0));
            SandstormScroll.ChangeSeverityIntentions();
        }

        private static void ChangeSeverityIntentions()
        {
            Sandstorm.IntendedSeverity = !Sandstorm.Happening ? (Main.rand.Next(3) != 0 ? Main.rand.NextFloat() * 0.3f : 0.0f) : 0.4f + Main.rand.NextFloat();
        }
    }
}