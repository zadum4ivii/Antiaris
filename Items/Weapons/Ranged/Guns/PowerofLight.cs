using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Guns
{
    public class PowerofLight : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.damage = 34;
            item.ranged = true;
            item.width = 56;
            item.height = 24;
            item.useTime = 15;
            item.useAnimation = 15;
            item.shoot = mod.ProjectileType("LightEnergy");
            item.shootSpeed = 13f;
            item.useStyle = 5;
            item.knockBack = 6;
            item.value = Item.sellPrice(0, 15, 0, 0);
            item.rare = 3;
            item.UseSound = SoundID.Item91;
            item.autoReuse = true;
			item.useAmmo = AmmoID.Bullet;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Power of Light");
			Tooltip.SetDefault("Shoots bouncing clots of light which increase their damage with each bounce\n<right> to shoot a powerful piercing clot");
            DisplayName.AddTranslation(GameCulture.Chinese, "强光体");
			Tooltip.AddTranslation(GameCulture.Chinese, "发射可以反弹的光凝聚体，反弹次数越多伤害越高\n<right> 发射强力的光凝聚体");
            DisplayName.AddTranslation(GameCulture.Russian, "Сила света");
			Tooltip.AddTranslation(GameCulture.Russian, "Выстреливает отскакивающими сгустками света, которые повышают свой урон при каждом отскоке\n<right>, чтобы выстрелить мощным пронизывающим сгустком");
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			return true;
		}

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.damage = 50;
				item.shoot = mod.ProjectileType("LightEnergy2");
				item.shootSpeed = 13f;
				item.useAnimation = 42;
				item.useTime = 42;
				item.autoReuse = true;
            }
            else
            {
                item.damage = 38;
				item.shoot = mod.ProjectileType("LightEnergy");
				item.shootSpeed = 13f;
				item.useAnimation = 15;
				item.useTime = 15;
				item.autoReuse = true;
            }
            return base.CanUseItem(player);
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, -2);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 20);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
            recipe.AddIngredient(ItemID.IllegalGunParts);
            recipe.AddIngredient(null, "TranquilityElement", 8);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
