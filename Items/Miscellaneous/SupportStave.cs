using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Miscellaneous
{
    public class SupportStave : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Support Stave");
            Tooltip.SetDefault("Summons healing magic that can heal town NPCs\n<right> to heal yourself using mana");
            DisplayName.AddTranslation(GameCulture.Russian, "Посох поддержки");
            Tooltip.AddTranslation(GameCulture.Russian, "Призывает лечащую магию, которая может лечить городских НИПов\n<right>, чтобы восстановить своё здоровье, за счёт маны");
			DisplayName.AddTranslation(GameCulture.Chinese, "救援法杖");
            Tooltip.AddTranslation(GameCulture.Chinese, "使用治愈魔法治疗城镇NPC\n点击鼠标右键，使用魔法治疗自身");
        }

        public override void SetDefaults()
        {
            item.mana = 15;
            item.width = 44;
            item.height = 44;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 5;
            item.noMelee = true;
            item.value = Item.sellPrice(0, 0, 30, 0);
            item.rare = 1;
            item.UseSound = SoundID.Item20;
            Item.staff[item.type] = true;
            item.shoot = mod.ProjectileType("SupportStavePro");
            item.shootSpeed = 22f;
            item.mana = 5;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.autoReuse = false;
                item.useTime = 55;
                item.useAnimation = 55;
                item.shoot = 0;
                item.mana = 25;
                if (player.statMana >= 25)
                {
                    player.statLife += 25;
                    player.HealEffect(25);
                    NetMessage.SendData(MessageID.SpiritHeal, -1, -1, null, player.whoAmI, 10);
                }
            }
            else
            {
                item.useTime = 25;
                item.useAnimation = 25;
                item.autoReuse = true;
                item.shoot = mod.ProjectileType("SupportStavePro");
                item.mana = 5;
            }
            return base.CanUseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.AddIngredient(ItemID.IronBar, 8);
            recipe.anyIronBar = true;
            recipe.AddIngredient(ItemID.Emerald, 2);
            recipe.AddIngredient(null, "NatureEssence", 5);
            recipe.SetResult(this);
            recipe.AddTile(18);
            recipe.AddRecipe();
        }
    }
}
