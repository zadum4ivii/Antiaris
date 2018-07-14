using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Miscellaneous
{
    public class PlatinumStar : ModItem
    {
        public override Color? GetAlpha(Color lightColor) { return Color.White; }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Star);
            item.width = 26;
            item.height = 24;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Platinum Star");
            DisplayName.AddTranslation(GameCulture.Chinese, "铂金之星");
            DisplayName.AddTranslation(GameCulture.Russian, "Платиновая звезда");
        }

        public override bool ItemSpace(Player player)
        {
            return true;
        }

        public override bool CanPickup(Player player)
        {
            return true;
        }

        public override void PostUpdate()
        {
            float scale = (float)Main.rand.Next(90, 111) * 0.01f * (Main.essScale * 0.5f);
            Lighting.AddLight((int)(((double)item.position.X + (double)(item.width / 2)) / 16.0), (int)(((double)item.position.Y + (double)(item.height / 2)) / 16.0), 0.2f * scale, 0.3f * scale, 0.8f * scale);
        }

        public override bool OnPickup(Player player)
        {
            Main.PlaySound(7, (int)player.position.X, (int)player.position.Y, 1);
            player.statMana += 150;
            if (Main.myPlayer == player.whoAmI)
                player.ManaEffect(150);
            return false;
        }
    }
}
