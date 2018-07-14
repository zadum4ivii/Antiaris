using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Magic
{
    public class ThousandNeedles : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 18;
            item.magic = true;
			item.mana = 4;
            item.width = 40;
            item.height = 40;
            item.useTime = 19;
            item.useAnimation = 19;
            item.useStyle = 1;
			item.noUseGraphic = true;
            item.noMelee = true;
            item.knockBack = 3;
            item.rare = 3;
            item.UseSound = SoundID.Item39;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("Splinter");
            item.shootSpeed = 90f;
			item.value = Item.sellPrice(0, 2, 0, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thousand Needles");
            Tooltip.SetDefault("Throws splinters that stick to enemies dealing damage\nAlso throws a piercing splinter");
            DisplayName.AddTranslation(GameCulture.Chinese, "千针石林");
            Tooltip.AddTranslation(GameCulture.Chinese, "投掷出锋利且可以刺入敌人体内的尖刺");
            DisplayName.AddTranslation(GameCulture.Russian, "Тысяча игол");
            Tooltip.AddTranslation(GameCulture.Russian, "Стреляет занозам, которые застряют во врагах, нанося урон\nТакже выстреливает большой проникающей занозой");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberProjectiles = 4;
			float rotation = MathHelper.ToRadians(20);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("BigSplinter"), damage, knockBack, player.whoAmI);
			return false;
		}
    }
}
