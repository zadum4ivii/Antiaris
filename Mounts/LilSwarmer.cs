using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Antiaris.Mounts
{
	public class LilSwarmer : ModMountData
	{
	    public override void SetDefaults()
		{
			mountData.buff = mod.BuffType("LilSwarmer");
			mountData.heightBoost = 30;
			mountData.fallDamage = 0.5f;
			mountData.runSpeed = 5f;
			mountData.dashSpeed = 6f;
			mountData.flightTimeMax = 600;
			mountData.fatigueMax = 0;
			mountData.jumpHeight = 20;
			mountData.acceleration = 0.19f;
			mountData.jumpSpeed = 10f;
			mountData.blockExtraJumps = false;
			mountData.totalFrames = 5;
			mountData.constantJump = true;
			int[] array = new int[mountData.totalFrames];
			for (int l = 0; l < array.Length; l++)
			{
				array[l] = 20;
			}
			mountData.playerYOffsets = array;
			mountData.xOffset = 0;
			mountData.bodyFrame = 3;
			mountData.yOffset = 13;
			mountData.playerHeadOffset = 22;
			mountData.standingFrameCount = 0;
			mountData.standingFrameDelay = 0;
			mountData.standingFrameStart = 0;
			mountData.runningFrameCount = 5;
			mountData.runningFrameDelay = 22;
			mountData.runningFrameStart = 0;
			mountData.flyingFrameCount = 5;
			mountData.flyingFrameDelay = 5;
			mountData.flyingFrameStart = 0;
			mountData.inAirFrameCount = 5;
			mountData.inAirFrameDelay = 12;
			mountData.inAirFrameStart = 0;
			mountData.idleFrameCount = 5;
			mountData.idleFrameDelay = 12;
			mountData.idleFrameStart = 0;
			mountData.idleFrameLoop = true;
			mountData.swimFrameCount = mountData.inAirFrameCount;
			mountData.swimFrameDelay = mountData.inAirFrameDelay;
			mountData.swimFrameStart = mountData.inAirFrameStart;
			if (Main.netMode != 2)
			{
				mountData.textureWidth = mountData.backTexture.Width + 20;
				mountData.textureHeight = mountData.backTexture.Height;
			}
		}

	    public override void UpdateEffects(Player player)
        {
            if ((double)Math.Abs(player.velocity.X) >= 4.0)
            {
                var rect = player.getRect();
                Dust.NewDust(new Vector2((float)rect.X, (float)rect.Y), rect.Width, rect.Height, 19, 0.0f, 0.0f, 0, new Color(), 1f);
                Dust.NewDust(new Vector2((float)rect.X, (float)rect.Y), rect.Width, rect.Height, 32, 0.0f, 0.0f, 0, new Color(), 1f);
            }
        }
	}
}