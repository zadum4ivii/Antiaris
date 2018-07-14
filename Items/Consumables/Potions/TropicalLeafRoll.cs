using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Antiaris.Items.Consumables.Potions
{
    public class TropicalLeafRoll : ModItem
    {
        bool Sickness = false;

        byte Uses = 5;

        public override bool CloneNewInstances
        {
            get
            {
                return true;
            }
        }

        public override void SetDefaults()
        {
            item.maxStack = 1;
            item.width = 22;
            item.height = 22;
            item.useStyle = 3;
            item.useTime = 25;
            item.useAnimation = 25;
            item.UseSound = SoundID.Item1;
            item.consumable = true;
            item.rare = 0;
			item.buffType = mod.BuffType("NatureShield");
            item.buffTime = 3600;
            item.value = Item.sellPrice(0, 0, 5, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tropical Leaf Roll");
            Tooltip.SetDefault("Restores 1 health each second for 10 seconds\nCan be used 5 times\nProvides immunity to some debuffs");
            DisplayName.AddTranslation(GameCulture.Chinese, "热带叶卷");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、10 秒内每秒可以恢复 1 点体力\n2、能够使用 5 次\n3、对一些Debuff提供免疫");
            DisplayName.AddTranslation(GameCulture.Russian, "Рулон тропических листьев");
            Tooltip.AddTranslation(GameCulture.Russian, "Восстанавливает 1 здоровье каждую секунду в течение 10 секунд\nМожно использовать 5 раз\nДаёт иммунитет к некоторым дебаффам");
        }

        public override bool ConsumeItem(Player player)
        {
            return false;
        }

        public override bool UseItem(Player player)
        {
			player.AddBuff(mod.BuffType("PatchedUp"), 600);
            Uses--;
            item.scale -= 0.087f;
            if (Uses <= 0)
            {
                item.SetDefaults(0);
            }
            return true;
        }

        public override bool CanUseItem(Player player)
		{
			if(player.FindBuffIndex(BuffID.PotionSickness) != -1)
			{
				Sickness = true;
			}
			else 
			{
				Sickness = false;
			}
			return !Sickness;
		}

        public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips)
        {
			string LeafRoll = Language.GetTextValue("Mods.Antiaris.LeafRoll");
            TooltipLine Tip = new TooltipLine(mod, "Antiaris:Tooltip", LeafRoll + Uses + "/5");
            tooltips.Insert(4, Tip);
        }

        public override void NetSend(BinaryWriter writer)
        {
            writer.Write(Uses);
        }

        public override void NetRecieve(BinaryReader reader)
        {
            Uses = reader.ReadByte();
        }

        public override TagCompound Save()
        {
            return new TagCompound
            {
                {
                    "U", Uses
                }
            };
        }

        public override void Load(TagCompound tag)
        {
            Uses = tag.GetByte("U");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "TropicalLeaf", 10);
			recipe.AddIngredient(ItemID.VineRope, 4);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
