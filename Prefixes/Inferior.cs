using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Prefixes
{
    public class Inferior : ModPrefix
    {
        internal static List<byte> Syncing = new List<byte>();
        internal int spellFailAmount;
        public Inferior() { }

        public Inferior(int fail = 0)
        {
            spellFailAmount = fail;
        }

        public override PrefixCategory Category { get { return PrefixCategory.AnyWeapon; } }

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Inferior");
            DisplayName.AddTranslation(GameCulture.Russian, "Низший");
            DisplayName.AddTranslation(GameCulture.Chinese, "劣等的");
        }

        public override bool Autoload(ref string name)
        {
            if (base.Autoload(ref name))
            {
                mod.AddPrefix(name, new Inferior(4));
                Syncing.Add(mod.GetPrefix(name).Type);
            }
            return false;
        }

        public override void Apply(Item item)
        {
            if (item.magic) item.GetGlobalItem<InstancedAntiarisItems>().spellFail = spellFailAmount;
        }

        public override void ModifyValue(ref float valueMult)
        {
            valueMult *= 1.0f;
        }

        public override float RollChance(Item item) // 33.33% chance of getting a accessory prefix, assuming all of them can be applied and no other modded prefixes were added. May check for other mods prefixes in the future.
        {
            return item.magic ? 3.3f : 0.0f;
        }
    }
}