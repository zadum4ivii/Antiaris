using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Antiaris
{
	public static class AntiarisUtils
	{
	    public static bool HasBuff(this Player player, int buffType)
		{
			if (player.whoAmI != -1 || buffType < 0 || buffType >= player.buffImmune.Length)
				return false;

			return player.FindBuffIndex(buffType) != -1;
		}

	    public static bool AddItem(this Chest chest, int type, int? stack = null)
		{
			foreach (Item item in chest.item)
			{
				if (item.IsAir)
				{
					item.SetDefaults(type);
					if (stack.HasValue)
						item.stack = stack.Value;
					return true;
				}
			}
			return false;
		}

	    public static bool AddUniqueItem(this Chest shop, ref int nextSlot, int type)
		{
			if (shop.item.Any(x => x.type == type))
				return false;

			shop.item[nextSlot].SetDefaults(type);
			nextSlot++;
			return true;
		}

	    public static void DrawArmorGlowMask(EquipType type, Texture2D texture, PlayerDrawInfo info)
		{
			switch (type)
			{
				case EquipType.Head:
					{
						DrawData drawData = new DrawData(texture, new Vector2((int)(info.position.X - Main.screenPosition.X) + ((info.drawPlayer.width - info.drawPlayer.bodyFrame.Width) / 2), (int)(info.position.Y - Main.screenPosition.Y) + info.drawPlayer.height - info.drawPlayer.bodyFrame.Height + 4) + info.drawPlayer.headPosition + info.headOrigin, info.drawPlayer.bodyFrame, info.headGlowMaskColor, info.drawPlayer.headRotation, info.headOrigin, 1f, info.spriteEffects, 0);
						drawData.shader = info.headArmorShader;
						Main.playerDrawData.Add(drawData);
					}
					return;
				case EquipType.Body:
					{
						int k = 0;
						Rectangle bodyFrame = info.drawPlayer.bodyFrame;
						int k2 = k;
						bodyFrame.X += k2;
						bodyFrame.Width -= k2;
						if (info.drawPlayer.direction == -1)
						{
							k2 = 0;
						}
						if (!info.drawPlayer.invis)
						{
							DrawData drawData = new DrawData(texture, new Vector2((int)(info.position.X - Main.screenPosition.X - (info.drawPlayer.bodyFrame.Width / 2) + (info.drawPlayer.width / 2) + k2), ((int)(info.position.Y - Main.screenPosition.Y + info.drawPlayer.height - info.drawPlayer.bodyFrame.Height + 4))) + info.drawPlayer.bodyPosition + new Vector2(info.drawPlayer.bodyFrame.Width / 2, info.drawPlayer.bodyFrame.Height / 2), bodyFrame, info.bodyGlowMaskColor, info.drawPlayer.bodyRotation, info.bodyOrigin, 1f, info.spriteEffects, 0);
							drawData.shader = info.bodyArmorShader;
							Main.playerDrawData.Add(drawData);
						}
					}
					return;
				case EquipType.Legs:
					{
						if (info.drawPlayer.shoe != 15 || info.drawPlayer.wearsRobe)
						{
							if (!info.drawPlayer.invis)
							{
								DrawData drawData = new DrawData(texture, new Vector2((int)(info.position.X - Main.screenPosition.X - (info.drawPlayer.legFrame.Width / 2) + (info.drawPlayer.width / 2)), (int)(info.position.Y - Main.screenPosition.Y + info.drawPlayer.height - info.drawPlayer.legFrame.Height + 4)) + info.drawPlayer.legPosition + info.legOrigin, info.drawPlayer.legFrame, info.legGlowMaskColor, info.drawPlayer.legRotation, info.legOrigin, 1f, info.spriteEffects, 0);
								drawData.shader = info.legArmorShader;
								Main.playerDrawData.Add(drawData);
							}
						}
					}
					return;
			}
		}

	    public static void DrawItemGlowMask(Texture2D texture, PlayerDrawInfo info)
		{
			Item item = info.drawPlayer.HeldItem;
			if (info.shadow != 0f || info.drawPlayer.frozen || ((info.drawPlayer.itemAnimation <= 0 || item.useStyle == 0) && (item.holdStyle <= 0 || info.drawPlayer.pulley)) || info.drawPlayer.dead || item.noUseGraphic || (info.drawPlayer.wet && item.noWet))
			{
				return;
			}
			Vector2 offset = new Vector2();
			float rotOffset = 0;
			Vector2 origin = new Vector2();
			if (item.useStyle == 5)
			{
				if (Item.staff[item.type])
				{
					rotOffset = 0.785f * info.drawPlayer.direction;
					if (info.drawPlayer.gravDir == -1f) { rotOffset -= 1.57f * info.drawPlayer.direction; }
					origin = new Vector2(texture.Width * 0.5f * (1 - info.drawPlayer.direction), (info.drawPlayer.gravDir == -1f) ? 0 : texture.Height);
					int x = -(int)origin.X;
					ItemLoader.HoldoutOrigin(info.drawPlayer, ref origin);
					offset = new Vector2(origin.X + x, 0);
				}
				else
				{
					offset = new Vector2(10, texture.Height/2);
					ItemLoader.HoldoutOffset(info.drawPlayer.gravDir, item.type, ref offset);
					origin = new Vector2(-offset.X, texture.Height / 2);
					if(info.drawPlayer.direction == -1)
						origin.X = texture.Width + offset.X;
					offset = new Vector2(texture.Width / 2, offset.Y);
				}
			}
			else
			{
				origin = new Vector2(texture.Width * 0.5f * (1 - info.drawPlayer.direction), (info.drawPlayer.gravDir == -1f) ? 0 : texture.Height);
			}
			Main.playerDrawData.Add
			(
				new DrawData
				(
					texture,
					info.itemLocation-Main.screenPosition+offset,
					texture.Bounds,
					new Color(250, 250, 250, item.alpha),
					info.drawPlayer.itemRotation + rotOffset,
					origin,
					item.scale, info.spriteEffects, 0
				)
			);
		}

	    public static void DrawItemGlowMaskWorld(SpriteBatch spriteBatch, Item item, Texture2D texture, float rotation, float scale)
		{
			Main.spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					item.position.X - Main.screenPosition.X + item.width / 2,
					item.position.Y - Main.screenPosition.Y + item.height - (texture.Height / 2) + 2f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				new Color(250, 250, 250, item.alpha), rotation,
				new Vector2(texture.Width / 2, texture.Height / 2),
				scale, SpriteEffects.None, 0f
			);
		}

	    public static void DrawProjectileGlowMaskWorld(SpriteBatch spriteBatch, Projectile projectile, Texture2D texture, float rotation, float scale)
        {
            Main.spriteBatch.Draw
            (
                texture,
                new Vector2
                (
                    projectile.position.X - Main.screenPosition.X + projectile.width / 2,
                    projectile.position.Y - Main.screenPosition.Y + projectile.height - (texture.Height / 2) + 2f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                new Color(250, 250, 250, projectile.alpha), rotation,
                new Vector2(texture.Width / 2, texture.Height / 2),
                scale, SpriteEffects.None, 0f
            );
        }

	    public static void DrawNPCGlowMask(SpriteBatch spriteBatch, Texture2D texture, NPC npc, Color color, float rotation, float scale)
        {
            if (texture == null || texture.IsDisposed) return;
            SpriteEffects effects = npc.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            Vector2 origin = new Vector2((float)(texture.Width / 2), (float)(texture.Height / Main.npcFrameCount[npc.type] / 2));
            Vector2 position = npc.Center - Main.screenPosition;
            Main.spriteBatch.Draw
            (
                texture,
                position, 
                new Rectangle?(npc.frame), 
                Color.White, 
                rotation, 
                origin,
                scale, effects, 0f
            );
        }

	    public static void MoveTowards(this NPC npc, Vector2 playerTarget, float speed, float turnResistance)
        {
            Vector2 move = playerTarget - npc.Center;
            float length = move.Length();
            if (length > speed)
            {
                move *= speed / length;
            }
            move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
            length = move.Length();
            if (length > speed) move *= speed / length;
            npc.velocity = move;
        }

	    public static Vector2 RotateVector(Vector2 origin, Vector2 vecToRot, float rot)
        {
            return new Vector2((float)(Math.Cos((double)rot) * ((double)vecToRot.X - (double)origin.X) - Math.Sin((double)rot) * ((double)vecToRot.Y - (double)origin.Y)) + origin.X, (float)(Math.Sin((double)rot) * ((double)vecToRot.X - (double)origin.X) + Math.Cos((double)rot) * ((double)vecToRot.Y - (double)origin.Y)) + origin.Y);
        }

	    public static Vector2 VelocityToPoint(Vector2 A, Vector2 B, float speed)
        {
            Vector2 move = (B - A);
            return move * (speed / (float)Math.Sqrt(move.X * move.X + move.Y * move.Y));
        }

	    public static void FindSentryPosition(Player player, out int worldX, out int worldY, out int pushYUp)
        {
            bool flag = false;
            int i = (int)((double)Main.mouseX + (double)Main.screenPosition.X) / 16;
            int j = (int)((double)Main.mouseY + (double)Main.screenPosition.Y) / 16;
            if ((double)player.gravDir == -1.0)
                j = (int)((double)Main.screenPosition.Y + (double)Main.screenHeight - (double)Main.mouseY) / 16;
            worldX = i * 16 + 8;
            pushYUp = 41;
            if (!flag)
            {
                while (j < Main.maxTilesY - 10 && Main.tile[i, j] != null && (!WorldGen.SolidTile2(i, j) && Main.tile[i - 1, j] != null) && (!WorldGen.SolidTile2(i - 1, j) && Main.tile[i + 1, j] != null && !WorldGen.SolidTile2(i + 1, j)))
                    ++j;
                ++j;
            }
            int position = j - 1;
            pushYUp -= 26;
            worldY = position * 16;
        }

	    public static bool HitTileOnSide(Entity codable, int dir, bool noYMovement = true)
        {
            if (!noYMovement || codable.velocity.Y == 0f)
            {
                Vector2 dummyVec = default(Vector2);
                return HitTileOnSide(codable.position, codable.width, codable.height, dir, ref dummyVec);
            }
            return false;
        }

	    public static void WalkupHalfBricks(NPC npc)
        {
            WalkupHalfBricks(npc, ref npc.gfxOffY, ref npc.stepSpeed);
        }

	    public static int GetFirstTileCeiling(int x, int startY, bool solid = true)
        {
            for (int y = startY; y > 0; y--)
            {
                Tile tile = Main.tile[x, y];
                if (tile != null && tile.nactive() && (!solid || Main.tileSolid[(int)tile.type])) { return y; }
            }
            return 0;
        }

	    public static void WalkupHalfBricks(Entity codable, ref float gfxOffY, ref float stepSpeed)
        {
            if (codable.velocity.Y >= 0f)
            {
                int offset = 0;
                if (codable.velocity.X < 0f) offset = -1;
                if (codable.velocity.X > 0f) offset = 1;
                Vector2 pos = codable.position;
                pos.X += codable.velocity.X;
                int tileX = (int)(((double)pos.X + (double)(codable.width / 2) + (double)((codable.width / 2 + 1) * offset)) / 16.0);
                int tileY = (int)(((double)pos.Y + (double)codable.height - 1.0) / 16.0);
                if (Main.tile[tileX, tileY] == null) Main.tile[tileX, tileY] = new Tile();
                if (Main.tile[tileX, tileY - 1] == null) Main.tile[tileX, tileY - 1] = new Tile();
                if (Main.tile[tileX, tileY - 2] == null) Main.tile[tileX, tileY - 2] = new Tile();
                if (Main.tile[tileX, tileY - 3] == null) Main.tile[tileX, tileY - 3] = new Tile();
                if (Main.tile[tileX, tileY + 1] == null) Main.tile[tileX, tileY + 1] = new Tile();
                if (Main.tile[tileX - offset, tileY - 3] == null) Main.tile[tileX - offset, tileY - 3] = new Tile();
                if ((double)(tileX * 16) < (double)pos.X + (double)codable.width && (double)(tileX * 16 + 16) > (double)pos.X && (Main.tile[tileX, tileY].nactive() && (int)Main.tile[tileX, tileY].slope() == 0 && ((int)Main.tile[tileX, tileY - 1].slope() == 0 && Main.tileSolid[(int)Main.tile[tileX, tileY].type]) && !Main.tileSolidTop[(int)Main.tile[tileX, tileY].type] || Main.tile[tileX, tileY - 1].halfBrick() && Main.tile[tileX, tileY - 1].nactive()) && ((!Main.tile[tileX, tileY - 1].nactive() || !Main.tileSolid[(int)Main.tile[tileX, tileY - 1].type] || Main.tileSolidTop[(int)Main.tile[tileX, tileY - 1].type] || Main.tile[tileX, tileY - 1].halfBrick() && (!Main.tile[tileX, tileY - 4].nactive() || !Main.tileSolid[(int)Main.tile[tileX, tileY - 4].type] || Main.tileSolidTop[(int)Main.tile[tileX, tileY - 4].type])) && ((!Main.tile[tileX, tileY - 2].nactive() || !Main.tileSolid[(int)Main.tile[tileX, tileY - 2].type] || Main.tileSolidTop[(int)Main.tile[tileX, tileY - 2].type]) && (!Main.tile[tileX, tileY - 3].nactive() || !Main.tileSolid[(int)Main.tile[tileX, tileY - 3].type] || Main.tileSolidTop[(int)Main.tile[tileX, tileY - 3].type]) && (!Main.tile[tileX - offset, tileY - 3].nactive() || !Main.tileSolid[(int)Main.tile[tileX - offset, tileY - 3].type]))))
                {
                    float tileWorldY = (float)(tileY * 16);
                    if (Main.tile[tileX, tileY].halfBrick())
                        tileWorldY += 8f;
                    if (Main.tile[tileX, tileY - 1].halfBrick())
                        tileWorldY -= 8f;
                    if ((double)tileWorldY < (double)pos.Y + (double)codable.height)
                    {
                        float tileWorldYHeight = pos.Y + (float)codable.height - tileWorldY;
                        float heightNeeded = 16.1f;
                        if ((double)tileWorldYHeight <= (double)heightNeeded)
                        {
                            gfxOffY += codable.position.Y + (float)codable.height - tileWorldY;
                            codable.position.Y = tileWorldY - (float)codable.height;
                            stepSpeed = (double)tileWorldYHeight >= 9.0 ? 2f : 1f;
                        }
                    }
                    else
                        gfxOffY = Math.Max(0f, gfxOffY - stepSpeed);
                }
                else
                    gfxOffY = Math.Max(0f, gfxOffY - stepSpeed);
            }
            else
                gfxOffY = Math.Max(0f, gfxOffY - stepSpeed);
        }

	    public static bool HitTileOnSide(Vector2 position, int width, int height, int dir, ref Vector2 hitTilePos)
        {
            int tilePosX = 0;
            int tilePosY = 0;
            int tilePosWidth = 0;
            int tilePosHeight = 0;
            if (dir == 0)
            {
                tilePosX = (int)(position.X - 8f) / 16;
                tilePosY = (int)position.Y / 16;
                tilePosWidth = tilePosX + 1;
                tilePosHeight = (int)(position.Y + (float)height) / 16;
            }
            else if (dir == 1)
            {
                tilePosX = (int)(position.X + (float)width + 8f) / 16;
                tilePosY = (int)position.Y / 16;
                tilePosWidth = tilePosX + 1;
                tilePosHeight = (int)(position.Y + (float)height) / 16;
            }
            else if (dir == 2)
            {
                tilePosX = (int)position.X / 16;
                tilePosY = (int)(position.Y - 8f) / 16;
                tilePosWidth = (int)(position.X + (float)width) / 16;
                tilePosHeight = tilePosY + 1;
            }
            else if (dir == 3)
            {
                tilePosX = (int)position.X / 16;
                tilePosY = (int)(position.Y + (float)height + 8f) / 16;
                tilePosWidth = (int)(position.X + (float)width) / 16;
                tilePosHeight = tilePosY + 1;
            }
            for (int x2 = tilePosX; x2 < tilePosWidth; x2++)
            {
                for (int y2 = tilePosY; y2 < tilePosHeight; y2++)
                {
                    if (Main.tile[x2, y2] == null) { return false; }
                    if (Main.tile[x2, y2].nactive() && Main.tileSolid[(int)Main.tile[x2, y2].type])
                    {
                        hitTilePos = new Vector2(x2, y2);
                        return true;
                    }
                }
            }
            return false;
        }

	    public static Vector2 AttemptJump(Vector2 position, Vector2 velocity, int width, int height, int direction, float directionY = 0, int tileDistX = 3, int tileDistY = 4, float maxSpeedX = 1f, bool jumpUpPlatforms = false, Entity target = null, bool ignoreTiles = false)
        {
            try
            {
                tileDistX -= 2;
                Vector2 newVelocity = velocity;
                int tileX = Math.Max(10, Math.Min(Main.maxTilesX - 10, (int)((position.X + (width * 0.5f) + (float)(((width * 0.5f) + 8f) * direction)) / 16f)));
                int tileY = Math.Max(10, Math.Min(Main.maxTilesY - 10, (int)((position.Y + (float)height - 15f) / 16f)));
                int tileItX = Math.Max(10, Math.Min(Main.maxTilesX - 10, tileX + (direction * tileDistX)));
                int tileItY = Math.Max(10, Math.Min(Main.maxTilesY - 10, tileY - tileDistY));
                int lastY = tileY;
                int tileHeight = (int)(height / 16f);
                if (height > tileHeight * 16) { tileHeight += 1; }
                Rectangle hitbox = new Rectangle((int)position.X, (int)position.Y, width, height);
                if (ignoreTiles && target != null && Math.Abs((position.X + (width * 0.5f)) - target.Center.X) < width + 120)
                {
                    float dist = (int)Math.Abs(position.Y + ((float)height * 0.5f) - target.Center.Y) / 16;
                    if (dist < tileDistY + 2) { newVelocity.Y = -8f + (dist * -0.5f); } 
                }
                if (newVelocity.Y == velocity.Y)
                {
                    for (int y = tileY; y >= tileItY; y--)
                    {
                        Tile tile = Main.tile[tileX, y];
                        Tile tileNear = Main.tile[Math.Min(Main.maxTilesX, tileX - direction), y];
                        if (tile == null) { tile = Main.tile[tileX, y] = new Tile(); }
                        if (tileNear == null) { tileNear = Main.tile[Math.Min(Main.maxTilesX, tileX - direction), y] = new Tile(); }
                        if (tile.nactive() && (y != tileY || (!tile.halfBrick() && tile.slope() == 0)) && Main.tileSolid[tile.type] && (jumpUpPlatforms || !Main.tileSolidTop[tile.type]))
                        {
                            if (!Main.tileSolidTop[tile.type])
                            {
                                Rectangle tileHitbox = new Rectangle(tileX * 16, y * 16, 16, 16);
                                tileHitbox.Y = hitbox.Y;
                                if (tileHitbox.Intersects(hitbox)) { newVelocity = velocity; break; }
                            }
                            if (tileNear.nactive() && Main.tileSolid[tileNear.type] && !Main.tileSolidTop[tileNear.type]) { newVelocity = velocity; break; }
                            if (target != null && y * 16 < target.Center.Y) { continue; }
                            lastY = y;
                            newVelocity.Y = -(5f + (float)(tileY - y) * (tileY - y > 3 ? 1f - ((tileY - y - 2) * 0.0525f) : 1f));
                        }
                        else
                        if (lastY - y >= tileHeight) { break; }
                    }
                }
                if (newVelocity.Y == velocity.Y)
                {
                    if (Main.tile[tileX, tileY + 1] == null) { Main.tile[tileX, tileY + 1] = new Tile(); }
                    if (Main.tile[tileX + direction, tileY + 1] == null) { Main.tile[tileX, tileY + 1] = new Tile(); }
                    if (Main.tile[tileX + direction, tileY + 2] == null) { Main.tile[tileX, tileY + 2] = new Tile(); }
                    if (directionY < 0 && (!Main.tile[tileX, tileY + 1].nactive() || !Main.tileSolid[(int)Main.tile[tileX, tileY + 1].type]) && (!Main.tile[tileX + direction, tileY + 1].nactive() || !Main.tileSolid[(int)Main.tile[tileX + direction, tileY + 1].type]))
                    {
                        if (!Main.tile[tileX + direction, tileY + 2].nactive() || !Main.tileSolid[(int)Main.tile[tileX, tileY + 2].type] || (target == null || ((target.Center.Y + (target.height * 0.25f)) < tileY * 16f)))
                        {
                            newVelocity.Y = -8f;
                            newVelocity.X *= 1.5f * (1f / maxSpeedX);
                            if (tileX <= tileItX)
                            {
                                for (int x = tileX; x < tileItX; x++)
                                {
                                    Tile tile = Main.tile[x, tileY + 1];
                                    if (tile == null) { tile = Main.tile[x, tileY + 1] = new Tile(); }
                                    if (x != tileX && !tile.nactive())
                                    {
                                        newVelocity.Y -= 0.0325f;
                                        newVelocity.X += direction * 0.255f;
                                    }
                                }
                            }
                            else
                            if (tileX > tileItX)
                            {
                                for (int x = tileItX; x < tileX; x++)
                                {
                                    Tile tile = Main.tile[x, tileY + 1];
                                    if (tile == null) { tile = Main.tile[x, tileY + 1] = new Tile(); }
                                    if (x != tileItX && !tile.nactive())
                                    {
                                        newVelocity.Y -= 0.0325f;
                                        newVelocity.X += direction * 0.255f;
                                    }
                                }
                            }
                        }
                    }
                }
                return newVelocity;
            }
            catch (Exception e) { ErrorLogger.Log(e.Message); ErrorLogger.Log(e.StackTrace); return velocity; }
        }

	    public static void RedundantFunc()
		{
			var something = Enumerable.Range(1, 10);
		}
	}
}
