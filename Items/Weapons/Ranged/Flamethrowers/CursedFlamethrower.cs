using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Flamethrowers
{
    public class CursedFlamethrower : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.damage = 30;
            item.ranged = true;
            item.width = 98;
            item.height = 46;
            item.useTime = 6;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 1;
            item.rare = 5;
            item.UseSound = SoundID.Item34;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("CursedFlames");
            item.shootSpeed = 8f;
            item.value = Item.buyPrice(0, 11, 0, 0);
            item.useAmmo = AmmoID.Gel;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Flamethrower");
            DisplayName.AddTranslation(GameCulture.Chinese, "咒火喷火器");
            DisplayName.AddTranslation(GameCulture.Russian, "Проклятый огнемёт");
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8, 4);
        }

        public override bool ConsumeAmmo(Player player)
        {
            return !(player.itemAnimation < item.useAnimation - 2);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Flamethrower);
            recipe.AddIngredient(ItemID.CursedFlame, 15);
            recipe.AddIngredient(ItemID.SoulofNight, 6);
			recipe.AddIngredient(ItemID.HallowedBar, 10);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
