using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Guns
{
    public class AssaultRifle : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 16;
            item.ranged = true;
            item.width = 60;
            item.height = 22;
            item.useAnimation = 12;
            item.useTime = 6;
            item.reuseDelay = 18;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.rare = 3;
            item.UseSound = SoundID.Item31;
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 8f;
            item.value = Item.buyPrice(0, 65, 0, 0);
            item.useAmmo = AmmoID.Bullet;
        }

        public override bool ConsumeAmmo(Player player)
        {
            return !(player.itemAnimation < item.useAnimation - 2);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Assault Rifle");
            Tooltip.SetDefault("Two round burst\nOnly consumes ammo for first shot");
            DisplayName.AddTranslation(GameCulture.Chinese, "突击步枪");
            Tooltip.AddTranslation(GameCulture.Chinese, "消耗一颗子弹，连续发射三颗子弹");
            DisplayName.AddTranslation(GameCulture.Russian, "Штурмовая винтовка");
            Tooltip.AddTranslation(GameCulture.Russian, "Очередь из двух пуль\nБоеприпасы расходуются только на первый выстрел");
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-18, 1);
        }
    }
}
