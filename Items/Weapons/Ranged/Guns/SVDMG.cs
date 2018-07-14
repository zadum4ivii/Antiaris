using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Guns
{
    public class SVDMG : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.damage = 86;
            item.ranged = true;
            item.width = 68;
            item.height = 32;
			item.useTime = 5;
			item.useAnimation = 5;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 4;
            item.rare = 10;
            item.shoot = mod.ProjectileType("SplitBullet");
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Items/SVDMG");
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 40f;
            item.value = Item.buyPrice(0, 17, 0, 0);
            item.useAmmo = AmmoID.Bullet;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("S.V.D.M.G.");
            Tooltip.SetDefault("66% chance not to consume ammo\nTransforms bullets into split bullets\nSplit bullets explode into bullets on hits");
			Tooltip.AddTranslation(GameCulture.Russian, "66% шанс не потратить патроны\nПревращает пули в разрывные пули\nРазрывные пули создают взрыв из пуль при попадании");
            DisplayName.AddTranslation(GameCulture.Chinese, "S.V.D.M.G.");
			Tooltip.AddTranslation(GameCulture.Chinese, "1、66%的概率不消耗弹药\n2、将所有子弹转化为子母弹\n3、子母弹击中敌人会爆炸且会分裂出数个子弹");
            DisplayName.AddTranslation(GameCulture.Russian, "S.V.D.M.G.");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("SplitBullet");
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }

        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= 0.66f;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8, -2);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SDMG);
            recipe.AddIngredient(ItemID.VortexBeater);
			recipe.AddIngredient(3456, 14);
			recipe.AddIngredient(3467, 12);
			recipe.AddIngredient(null, "WrathElement", 12);
            recipe.SetResult(this);
            recipe.AddTile(412);
            recipe.AddRecipe();
        }
    }
}
