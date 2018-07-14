using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Arrows
{
    public class BlueCrystalArrow : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.damage = 12;
            item.ranged = true;
            item.maxStack = 999;
            item.consumable = true;
            item.width = 14;
            item.height = 44;		
            item.shoot = mod.ProjectileType("BlueCrystalArrow");
            item.shootSpeed = 14.0f; 
            item.knockBack = 3.0f;
            item.value = Item.sellPrice(0, 0, 1, 0);
            item.rare = 5;
            item.ammo = AmmoID.Arrow;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blue Crystal Arrow");
            Tooltip.SetDefault("Crazy velocity and infinity piercing");
            DisplayName.AddTranslation(GameCulture.Russian, "Голубая кристальная стрела");
            Tooltip.AddTranslation(GameCulture.Russian, "Безумная скорость и бесконечная пробиваемость");
            DisplayName.AddTranslation(GameCulture.Chinese, "蓝水晶箭");
            Tooltip.AddTranslation(GameCulture.Chinese, "疯狂的攻速与无尽的穿透");
        }
    }
}
