using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Accessories
{
	public class VanGuard : ModBuff
	{
	    private int MinionID = -1;

	    private int MinionType = -1;

	    public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.SetDefault("Van Guard");
            Description.SetDefault("Protects your allies");
            DisplayName.AddTranslation(GameCulture.Russian, "Защитник");
            Description.AddTranslation(GameCulture.Russian, "Защищает ваших союзников");
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;
        }

	    public override void Update(Player player, ref int buffIndex)
		{
            if (MinionType == -1)
			{
                MinionType = mod.ProjectileType("VanGuard");
			}		
            if (MinionID == -1 || Main.projectile[MinionID].type != MinionType || !Main.projectile[MinionID].active || Main.projectile[MinionID].owner != player.whoAmI)
            {
                Projectile proj = new Projectile();
                proj.SetDefaults(MinionType);
                MinionID = Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, MinionType, proj.damage, proj.knockBack, player.whoAmI);
            }
            else
            {
                Main.projectile[MinionID].timeLeft = 5;
            }
		}
	}
}
