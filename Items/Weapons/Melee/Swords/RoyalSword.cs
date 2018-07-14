using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Melee.Swords
{
    public class RoyalSword : ModItem
    {
        private int timer = 0;

        public override void SetDefaults()
        {
            item.damage = 23;
            item.melee = true;
            item.width = 50;
            item.height = 56;
            item.useTime = 35;
            item.useAnimation = 35;
            item.useStyle = 1;
            item.knockBack = 4;
            item.value = Item.sellPrice(0, 15, 0, 0);
            item.rare = 2;
            item.UseSound = SoundID.Item71;
            item.autoReuse = true;
            item.useTurn = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Royal Sword");
            DisplayName.AddTranslation(GameCulture.Russian, "Королевский меч");
            DisplayName.AddTranslation(GameCulture.Chinese, "皇家宝刀");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、挥动速度会随着挥动时间而上升\n2、被其击中的敌人施加Debuff，获得Debuff后被击杀的敌人掉落的钱币更多");
            Tooltip.SetDefault("Increases attack speed for some time after attacking\nHas a chance to inflict Midas on enemies");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает скорость атаки на время после атаки\nИмеет шанс наложить эффект Мидаса на врагов");
        }

        public void OverhaulInit()
        {
            this.SetTag("broadsword");
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(2) == 0)
            {
                target.AddBuff(BuffID.Midas, 100);
            }
            Main.PlaySound(SoundID.Item10, item.position);
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 59);
        }

        public override void UseStyle(Player player)
        {
            ++timer;
            if (timer % 7 == 0)
            {
                item.useTime--;
                item.useAnimation--;
                if (item.useTime <= 3)
                {
                    item.useTime = 35;
                    item.useAnimation = 35;
                }
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "RoyalWeaponParts", 6);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
