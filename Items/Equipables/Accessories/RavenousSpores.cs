using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    public class RavenousSpores : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.rare = 2;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ravenous Spores");
            Tooltip.SetDefault("Enemies have a chance to spawn damaging spores on death");
            DisplayName.AddTranslation(GameCulture.Chinese, "强欲孢子");
            Tooltip.AddTranslation(GameCulture.Chinese, "当杀死敌人时有概率生长出有伤害的孢子");
            DisplayName.AddTranslation(GameCulture.Russian, "Хищные споры");
            Tooltip.AddTranslation(GameCulture.Russian, "Враги имеют шанс призвать наносящую урон спору при смерти");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
            aPlayer.RavenousSpores = true;
        }
    }
}
