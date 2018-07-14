using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Melee.Miscellaneous
{
    public class CursedHand : ModItem
    {
        byte Uses = 0;

        public override bool CloneNewInstances
        {
            get
            {
                return true;
            }
        }

        public override void SetDefaults()
        {
            item.damage = 45;
            item.melee = true;
            item.width = 46;
            item.height = 48;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = 1;
            item.knockBack = 8;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.rare = 5;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Hand");
            DisplayName.AddTranslation(GameCulture.Chinese, "咒怨钢爪");
            DisplayName.AddTranslation(GameCulture.Russian, "Проклятая рука");
        }

        public void OverhaulInit()
        {
            this.SetTag("broadsword");
        }

        public override bool CanUseItem(Player player)
        {
            for (var i = 0; i < Main.projectile.Length; i++)
            {
                var projectile = Main.projectile[i];
                if (projectile.type == mod.ProjectileType("CursedHand") && projectile.active && projectile.owner == player.whoAmI)
                {
                    return false;
                }
            }
            Uses++;
            if (Uses == 4)
            {
                item.shoot = mod.ProjectileType("CursedHand");
                item.shootSpeed = 13f;
                item.noUseGraphic = true;
                item.noMelee = true;
            }
            else if (Uses >= 5)
            {
                Uses = 0;
                item.shoot = 0;
                item.shootSpeed = 0f;
                item.noUseGraphic = false;
                item.noMelee = false;
            }
            return true;
        }
    }
}
