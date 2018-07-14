using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Thrown
{
    public class Coconut : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 44;
            item.height = 40;
            item.damage = 34;
            item.thrown = true;
            item.useTime = 40;
            item.useAnimation = 40;
            item.useStyle = 1;
            item.UseSound = SoundID.Item1;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.knockBack = 5;
            item.value = Item.sellPrice(0, 0, 5, 0);
            item.rare = 1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("Coconut");
            item.shootSpeed = 10f;
            item.consumable = true;
            item.maxStack = 999;
            item.rare = 0;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Coconut");
            DisplayName.AddTranslation(GameCulture.Chinese, "椰子");
            DisplayName.AddTranslation(GameCulture.Russian, "Кокос");
        }

        public void OverhaulInit()
        {
            this.SetTag("throwable");
        }
    }
}
