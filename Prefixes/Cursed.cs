using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Prefixes
{
    public class Cursed : ModPrefix
    {
        internal static List<byte> Syncing = new List<byte>();
        internal int spellFailAmount;
        public Cursed() { }

        public Cursed(int fail = 0)
        {
            spellFailAmount = fail;
        }

        public override PrefixCategory Category { get { return PrefixCategory.Accessory; } }

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Cursed");
            DisplayName.AddTranslation(GameCulture.Russian, "Проклятый");
            DisplayName.AddTranslation(GameCulture.Chinese, "咒怨的");
        }

        public override bool Autoload(ref string name)
        {
            if (base.Autoload(ref name))
            {
                mod.AddPrefix(name, new Cursed(3));
                Syncing.Add(mod.GetPrefix(name).Type);
            }
            return false;
        }

        public override void Apply(Item item)
        {
            item.GetGlobalItem<InstancedAntiarisItems>().spellFail = spellFailAmount;
        }

        public override void ModifyValue(ref float valueMult)
        {
            valueMult *= 1.0f;
        }

        public override float RollChance(Item item) // 33.33% chance of getting a accessory prefix, assuming all of them can be applied and no other modded prefixes were added. May check for other mods prefixes in the future.
        {
            return 3.3f;
        }
    }
}