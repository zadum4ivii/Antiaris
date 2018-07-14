using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Summoning
{
    public class ParrotStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 19;
            item.summon = true;
            item.mana = 8;
            item.width = 52;
            item.height = 56;
            item.useTime = 18;
            item.channel = true;
            item.useAnimation = 18;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.buyPrice(0, 15, 0, 0);
            item.rare = 2;
            item.UseSound = SoundID.Item44;
            item.shoot = mod.ProjectileType("ParrotJunior");
            item.shootSpeed = 2f;
            item.buffType = mod.BuffType("ParrotJunior");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Parrot Staff");
            Tooltip.SetDefault("Summons a parrot junior to fight for you");
            DisplayName.AddTranslation(GameCulture.Chinese, "鹦鹉法杖");
            Tooltip.AddTranslation(GameCulture.Chinese, "召唤一只鹦鹉宝宝为你而战");
            DisplayName.AddTranslation(GameCulture.Russian, "Посох попугая");
            Tooltip.AddTranslation(GameCulture.Russian, "Призывает маленького попугая, который сражается за вас");
        }

        public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            return player.altFunctionUse != 2;
        }

        public override bool UseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                player.MinionNPCTargetAim();
            }
            return base.UseItem(player);
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
