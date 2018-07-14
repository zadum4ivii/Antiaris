using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Guns
{
    public class ArmyRifle : ModItem
    {
        private int timer = 0;

        public override void SetDefaults()
        {
            item.damage = 24;
            item.ranged = true;
            item.width = 74;
            item.height = 28;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 4;
            item.rare = 3;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 8f;
            item.value = Item.buyPrice(0, 5, 0, 0);
            item.useAmmo = AmmoID.Bullet;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Army Rifle");
            DisplayName.AddTranslation(GameCulture.Chinese, "军用步枪");
            DisplayName.AddTranslation(GameCulture.Russian, "Армейская винтовка");
        }

        public override void UseStyle(Player player)
        {
            ++timer;
            if (timer % 7 == 0)
            {
                item.useTime--;
                item.useAnimation--;
                item.shootSpeed += 2f;
                if (item.useTime <= 2)
                {
                    item.useTime = 30;
                    item.shootSpeed = 8f;
                    item.useAnimation = 30;
                }
            }
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8, 4);
        }
    }
}
