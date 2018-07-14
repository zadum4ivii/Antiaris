using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Weapons
{
	public class Deceleration : ModBuff
	{
	    public override void SetDefaults()
		{
            DisplayName.SetDefault("Deceleration");
            Description.SetDefault("The power of Aqua has corrupted your moving abilities and slowed down your speed");
			DisplayName.AddTranslation(GameCulture.Chinese, "减速");
            Description.AddTranslation(GameCulture.Chinese, "水的力量干涉了你的移动速度");
            DisplayName.AddTranslation(GameCulture.Russian, "Замедление");
            Description.AddTranslation(GameCulture.Russian, "Сила Аквы повредила Ваши способности передвижения и уменьшила скорость перемещения");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

	    public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<AntiarisPlayer>(mod).deceleration = true;
            player.velocity = Vector2.Clamp(player.velocity, -Vector2.One * 0.25f, Vector2.One * 0.25f);
        }

	    public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<AntiarisNPC>(mod).deceleration = true;
            npc.velocity = Vector2.Clamp(npc.velocity, -Vector2.One * 0.25f, Vector2.One * 0.25f);
        }
	}
}
