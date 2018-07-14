using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Materials
{
    public class GreenCrystalPixieDust : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
			item.value = Item.sellPrice(0, 0, 5, 5);
            item.rare = 2;
            item.maxStack = 999;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Green Crystal Pixie Dust");
            DisplayName.AddTranslation(GameCulture.Russian, "Зеленая кристальная пыльца пикси");
            DisplayName.AddTranslation(GameCulture.Chinese, "绿水晶精灵尘");
        }
    }
}
