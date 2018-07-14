using System.Collections.Generic;
using System.IO;
using Antiaris.Prefixes;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris
{
    public class InstancedAntiarisItems : GlobalItem
    {
        public int spellFail;

        public InstancedAntiarisItems()
        {
            spellFail = 0;
        }

        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public override GlobalItem Clone(Item item, Item itemClone)
        {
            InstancedAntiarisItems myClone = (InstancedAntiarisItems)base.Clone(item, itemClone);
            myClone.spellFail = spellFail;
            return myClone;
        }

        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if (spellFail != 0 && (Enchanted.Syncing.Contains(item.prefix) || Cursed.Syncing.Contains(item.prefix))) AntiarisPlayer.spellFail += spellFail;
        }

        public override bool UseItem(Item item, Player player)
        {
            if (spellFail != 0 && (Inferior.Syncing.Contains(item.prefix) || Elegant.Syncing.Contains(item.prefix)))
            {
                AntiarisPlayer.spellFail += spellFail;
                return true;
            }
            return base.UseItem(item, player);
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.prefix < 1 || item.social)
                return;
            if (Enchanted.Syncing.Contains(item.prefix))
            {
                TooltipLine line = new TooltipLine(mod, "spellFail", spellFail + Language.GetTextValue("Mods.Antiaris.SpellFail"));
                line.isModifier = true;
                tooltips.Add(line);
            }
            if (Cursed.Syncing.Contains(item.prefix))
            {
                TooltipLine line = new TooltipLine(mod, "spellFail", "+" + spellFail + Language.GetTextValue("Mods.Antiaris.SpellFail"));
                line.isModifier = true;
                line.isModifierBad = true;
                tooltips.Add(line);
            }
            if (Inferior.Syncing.Contains(item.prefix))
            {
                TooltipLine line = new TooltipLine(mod, "spellFail", "+" + spellFail + Language.GetTextValue("Mods.Antiaris.SpellFail"));
                line.isModifier = true;
                line.isModifierBad = true;
                tooltips.Add(line);
            }
            if (Elegant.Syncing.Contains(item.prefix))
            {
                TooltipLine line = new TooltipLine(mod, "spellFail", spellFail + Language.GetTextValue("Mods.Antiaris.SpellFail"));
                line.isModifier = true;
                tooltips.Add(line);
            }
        }

        public override void NetSend(Item item, BinaryWriter writer)
        {
            writer.Write(spellFail);
        }

        public override void NetReceive(Item item, BinaryReader reader)
        {
            spellFail = reader.ReadInt32();
        }
    }
}
