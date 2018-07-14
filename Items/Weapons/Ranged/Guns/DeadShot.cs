using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Guns
{
    public class DeadShot : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.damage = 168;
            item.ranged = true;
            item.width = 98;
            item.height = 28;
            item.useTime = 65;
            item.useAnimation = 65;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 5;
            item.rare = 9;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Items/DwarfShark");
            item.value = Item.buyPrice(0, 8, 50, 0);
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("BloodyBullet");
            item.shootSpeed = 220f;
            item.useAmmo = AmmoID.Bullet;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dead Shot");
            Tooltip.SetDefault("Transforms bullets into fast piercing bloody bullets\nBloody bullet increases damage for each enemy it hits\n<right> to zoom out\n33% chance to not consume ammo");
            DisplayName.AddTranslation(GameCulture.Chinese, "夺命枪手");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、将子弹变成快且锋利的血之弹\n2、血之弹击中的敌人越多，伤害越高\n3、33%的概率不消耗弹药");
            DisplayName.AddTranslation(GameCulture.Russian, "Мёртвый выстрел");
            Tooltip.AddTranslation(GameCulture.Russian, "Превращает пули в быстрые проникающие кровавые пули\nКровавая пуля повышает урон за каждого врага, в которого она попадает\n<right> для приближения\n33% шанс не потратить пулю");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 95f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
            type = mod.ProjectileType("BloodyBullet");
            return true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-18, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DwarfShark");
            recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddIngredient(null, "BloodDroplet", 28);
			recipe.AddIngredient(null, "WrathElement", 6);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}