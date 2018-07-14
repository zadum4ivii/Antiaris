using Terraria;
using Terraria.ModLoader;

namespace Antiaris.Mounts
{
    public class EmeraldSlime : ModMountData
    {
        public override void SetDefaults()
        {
            mountData.spawnDust = 61;
            mountData.buff = mod.BuffType("EmeraldSlime");
            mountData.heightBoost = 20;
            mountData.flightTimeMax = 0;
            mountData.fallDamage = 0.3f;
            mountData.runSpeed = 6f;
            mountData.dashSpeed = 4f;
            mountData.acceleration = 0.18f;
            mountData.jumpHeight = 24;
            mountData.jumpSpeed = 12f;
            mountData.constantJump = true;
            mountData.totalFrames = 4;
            int[] array = new int[mountData.totalFrames];
            for (var l = 0; l < array.Length; l++)
            {
                array[l] = 20;
            }
            array[1] += 2;
            array[3] -= 2;
            mountData.playerYOffsets = array;
            mountData.xOffset = 1;
            mountData.bodyFrame = 3;
            mountData.yOffset = 10;
            mountData.playerHeadOffset = 22;
            mountData.standingFrameCount = 1;
            mountData.standingFrameDelay = 12;
            mountData.standingFrameStart = 0;
            mountData.runningFrameCount = 4;
            mountData.runningFrameDelay = 12;
            mountData.runningFrameStart = 0;
            mountData.flyingFrameCount = 0;
            mountData.flyingFrameDelay = 0;
            mountData.flyingFrameStart = 0;
            mountData.inAirFrameCount = 1;
            mountData.inAirFrameDelay = 12;
            mountData.inAirFrameStart = 1;
            mountData.idleFrameCount = 0;
            mountData.idleFrameDelay = 0;
            mountData.idleFrameStart = 0;
            mountData.idleFrameLoop = false;
            if (Main.netMode != 2)
            {
                mountData.backTextureExtra = null;
                mountData.frontTexture = null;
                mountData.frontTextureExtra = null;
                mountData.textureWidth = mountData.backTexture.Width;
                mountData.textureHeight = mountData.backTexture.Height;
            }
        }
    }
}