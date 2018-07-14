using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Arrows
{
    public class RedCrystalArrow : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.damage = 20;
            item.ranged = true;
            item.maxStack = 999;
            item.consumable = true;
            item.width = 14;
            item.height = 44;		
            item.shoot = mod.ProjectileType("RedCrystalArrow");
            item.shootSpeed = 7.0f; 
            item.knockBack = 8.0f;
            item.value = Item.sellPrice(0, 0, 1, 0);
            item.rare = 5;
            item.ammo = AmmoID.Arrow;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Red Crystal Arrow");
            Tooltip.SetDefault("More power at the cost of piercing ability");
            Tooltip.AddTranslation(GameCulture.Russian, "Больше силы, но меньше пробиваемости");
            DisplayName.AddTranslation(GameCulture.Russian, "Красная кристальная стрела");
            DisplayName.AddTranslation(GameCulture.Chinese, "红水晶箭");
			Tooltip.AddTranslation(GameCulture.Chinese, "以穿透力为代价的更高伤害");
        }
    }
}
