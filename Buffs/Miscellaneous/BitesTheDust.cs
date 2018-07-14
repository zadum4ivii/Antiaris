using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Miscellaneous
{
	public class BitesTheDust : ModBuff
	{
	    public override void SetDefaults()
		{
            DisplayName.SetDefault("???");
            Description.SetDefault("There's something in your eye...");
            DisplayName.AddTranslation(GameCulture.Chinese, "？？？");
            Description.AddTranslation(GameCulture.Chinese, "你的眼里有些东西...");
            DisplayName.AddTranslation(GameCulture.Russian, "???");
            Description.AddTranslation(GameCulture.Russian, "В вашем глазу что-то есть...");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			canBeCleared = false;
		}

	    public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<AntiarisPlayer>(mod).bitesTheDust = true;
			if(player.buffTime[buffIndex] == 60)
			{
				Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Items/Detonator"), player.position);
			}
			if(player.buffTime[buffIndex] == 0)
            {
				string BitesTheDust = Language.GetTextValue("Mods.Antiaris.BitesTheDust", Main.LocalPlayer.name);
				player.KillMe(PlayerDeathReason.ByCustomReason(BitesTheDust), 1, 1);	
				Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 62);
				//vanilla code
				for (int num628 = 0; num628 < 40; num628++)
				{
					int num629 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 31, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num629].velocity *= 3f;
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num629].scale = 0.5f;
						Main.dust[num629].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
					}
				}
				for (int num630 = 0; num630 < 70; num630++)
				{
					int num631 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 6, 0f, 0f, 100, default(Color), 3f);
					Main.dust[num631].noGravity = true;
					Main.dust[num631].velocity *= 5f;
					num631 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 6, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num631].velocity *= 2f;
				}
				for (int num632 = 0; num632 < 3; num632++)
				{
					float scaleFactor10 = 0.33f;
					if (num632 == 1)
					{
						scaleFactor10 = 0.66f;
					}
					if (num632 == 2)
					{
						scaleFactor10 = 1f;
					}
					int num633 = Gore.NewGore(new Vector2(player.position.X + (float)(player.width / 2) - 24f, player.position.Y + (float)(player.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num633].velocity *= scaleFactor10;
					Gore expr_13E6D_cp_0 = Main.gore[num633];
					expr_13E6D_cp_0.velocity.X = expr_13E6D_cp_0.velocity.X + 1f;
					Gore expr_13E8D_cp_0 = Main.gore[num633];
					expr_13E8D_cp_0.velocity.Y = expr_13E8D_cp_0.velocity.Y + 1f;
					num633 = Gore.NewGore(new Vector2(player.position.X + (float)(player.width / 2) - 24f, player.position.Y + (float)(player.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 2f);
					Main.gore[num633].velocity *= scaleFactor10;
					Gore expr_13F30_cp_0 = Main.gore[num633];
					expr_13F30_cp_0.velocity.X = expr_13F30_cp_0.velocity.X - 1f;
					Gore expr_13F50_cp_0 = Main.gore[num633];
					expr_13F50_cp_0.velocity.Y = expr_13F50_cp_0.velocity.Y + 1f;
					num633 = Gore.NewGore(new Vector2(player.position.X + (float)(player.width / 2) - 24f, player.position.Y + (float)(player.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num633].velocity *= scaleFactor10;
					Gore expr_13FF3_cp_0 = Main.gore[num633];
					expr_13FF3_cp_0.velocity.X = expr_13FF3_cp_0.velocity.X + 1f;
					Gore expr_14013_cp_0 = Main.gore[num633];
					expr_14013_cp_0.velocity.Y = expr_14013_cp_0.velocity.Y - 1f;
					num633 = Gore.NewGore(new Vector2(player.position.X + (float)(player.width / 2) - 24f, player.position.Y + (float)(player.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
					Main.gore[num633].velocity *= scaleFactor10;
					Gore expr_140B6_cp_0 = Main.gore[num633];
					expr_140B6_cp_0.velocity.X = expr_140B6_cp_0.velocity.X - 1f;
					Gore expr_140D6_cp_0 = Main.gore[num633];
					expr_140D6_cp_0.velocity.Y = expr_140D6_cp_0.velocity.Y - 1f;
				}
			}
		}
	}
}
