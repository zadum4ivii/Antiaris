using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Miscellaneous
{
    public class GoldenHeart : ModItem
    {
        public override Color? GetAlpha(Color lightColor) { return Color.White; }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Heart);
            item.width = 18;
            item.height = 18;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Golden Heart");
			DisplayName.AddTranslation(GameCulture.Chinese, "黄金之心");
            DisplayName.AddTranslation(GameCulture.Russian, "Золотое сердце");
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
            Lighting.AddLight((int)(((double)item.position.X + (double)(item.width / 2)) / 16.0), (int)(((double)item.position.Y + (double)(item.height / 2)) / 16.0), 0.8f * scale, 0.7f * scale, 0.2f * scale);
        }

        public override bool OnPickup(Player player)
        {
            Main.PlaySound(7, (int)player.position.X, (int)player.position.Y, 1);
            player.statLife += 50;
            if (Main.myPlayer == player.whoAmI)
                player.HealEffect(50);
            return false;
        }
    }
}
