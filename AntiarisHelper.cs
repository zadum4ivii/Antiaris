using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Antiaris
{
    public static class AntiarisHelper
    {
        public delegate void ExtraAction();

        public static byte GetLiquidLevel(int x, int y, LiquidType liquidType = LiquidType.Any)
        {
            if (x < 0 || x >= Main.maxTilesX)
                return 0;
            if (y < 0 || y >= Main.maxTilesY)
                return 0;
            var tile = Main.tile[x, y];
            if (tile == null || tile.liquid == 0)
                return 0;
            if (liquidType == LiquidType.Any)
            {
                return tile.liquid;
            }
            if (liquidType.HasFlag(LiquidType.Water) && !tile.lava() && !tile.honey())
            {
                return tile.liquid;
            }
            if (liquidType.HasFlag(LiquidType.Lava) && tile.lava())
            {
                return tile.liquid;
            }
            if (liquidType.HasFlag(LiquidType.Honey) && tile.honey())
            {
                return tile.liquid;
            }
            return 0;
        }

        public static float GradtoRad(float Grad)
        {
            return Grad * (float)Math.PI / 180.0f;
        }

        public static Vector2 RandomPositin(Vector2 pos1, Vector2 pos2)
        {
            var rand = new Random();
            return new Vector2(rand.Next((int)pos1.X, (int)pos2.X) + 1, rand.Next((int)pos1.Y, (int)pos2.Y) + 1);
        }

        public static int GetNearestAlivePlayer(Terraria.NPC npc)
        {
            var NearestPlayerDist = 4815162342f;
            var NearestPlayer = -1;
            foreach (Player player in Main.player)
            {
                if (player.Distance(npc.Center) < NearestPlayerDist && player.active)
                {
                    NearestPlayerDist = player.Distance(npc.Center);
                    NearestPlayer = player.whoAmI;
                }
            }
            return NearestPlayer;
        }

        public static Vector2 VelocityFPTP(Vector2 pos1, Vector2 pos2, float speed)
        {
            var move = pos2 - pos1;
            return move * (speed / (float)Math.Sqrt(move.X * move.X + move.Y * move.Y));
        }

        public static float RadtoGrad(float Rad)
        {
            return Rad * 180.0f / (float)Math.PI;
        }

        public static int GetNearestNPC(Vector2 Point, bool Friendly = false, bool NoBoss = false)
        {
            float NearestNPCDist = -1;
            int NearestNPC = -1;
            foreach (NPC npc in Main.npc)
            {
                if (!npc.active)
                    continue;
                if (NoBoss && npc.boss)
                    continue;
                if (!Friendly && (npc.friendly || npc.lifeMax <= 5))
                    continue;
                if (NearestNPCDist == -1 || npc.Distance(Point) < NearestNPCDist)
                {
                    NearestNPCDist = npc.Distance(Point);
                    NearestNPC = npc.whoAmI;
                }
            }
            return NearestNPC;
        }

        public static int GetNearestPlayer(Vector2 Point, bool Alive = false)
        {
            float NearestPlayerDist = -1;
            int NearestPlayer = -1;
            foreach (Player player in Main.player)
            {
                if (Alive && (!player.active || player.dead))
                    continue;
                if (NearestPlayerDist == -1 || player.Distance(Point) < NearestPlayerDist)
                {
                    NearestPlayerDist = player.Distance(Point);
                    NearestPlayer = player.whoAmI;
                }
            }
            return NearestPlayer;
        }

        public static Vector2 VelocityToPoint(Vector2 A, Vector2 B, float Speed)
        {
            var Move = (B - A);
            return Move * (Speed / (float)Math.Sqrt(Move.X * Move.X + Move.Y * Move.Y));
        }

        public static Vector2 RandomPointInArea(Vector2 A, Vector2 B)
        {
            return new Vector2(Main.rand.Next((int)A.X, (int)B.X) + 1, Main.rand.Next((int)A.Y, (int)B.Y) + 1);
        }

        public static Vector2 RandomPointInArea(Rectangle Area)
        {
            return new Vector2(Main.rand.Next(Area.X, Area.X + Area.Width), Main.rand.Next(Area.Y, Area.Y + Area.Height));
        }

        public static float rotateBetween2Points(Vector2 A, Vector2 B)
        {
            return (float)Math.Atan2(A.Y - B.Y, A.X - B.X);
        }

        public static Vector2 CenterPoint(Vector2 A, Vector2 B)
        {
            return new Vector2((A.X + B.X) / 2.0f, (A.Y + B.Y) / 2.0f);
        }

        public static Vector2 PolarPos(Vector2 Point, float Distance, float Angle, int XOffset = 0, int YOffset = 0)
        {
            var ReturnedValue = new Vector2();
            ReturnedValue.X = (Distance * (float)Math.Sin((double)AntiarisHelper.RadtoGrad(Angle)) + Point.X) + XOffset;
            ReturnedValue.Y = (Distance * (float)Math.Cos((double)AntiarisHelper.RadtoGrad(Angle)) + Point.Y) + YOffset;
            return ReturnedValue;
        }

        public static bool Chance(float chance)
        {
            return (Main.rand.NextFloat() <= chance);
        }

        public static Vector2 SmoothFromTo(Vector2 From, Vector2 To, float Smooth = 60f)
        {
            return From + ((To - From) / Smooth);
        }

        public static float DistortFloat(float Float, float Percent)
        {
            var DistortNumber = Float * Percent;
            var Counter = 0;
            while (DistortNumber.ToString().Split(',').Length > 1)
            {
                DistortNumber *= 10;
                Counter++;
            }
            return Float + (((float)(Main.rand.Next(0, (int)DistortNumber + 1)) / (float)(Math.Pow(10, Counter))) * ((Main.rand.Next(2) == 0) ? -1 : 1));
        }

        public static Vector2 FoundPosition(Vector2 tilePos)
        {
            var Screen = new Vector2(Main.screenWidth / 2, Main.screenHeight / 2);
            var FullScreen = tilePos - Main.mapFullscreenPos;
            FullScreen *= Main.mapFullscreenScale / 16;
            FullScreen = FullScreen * 16 + Screen;
            var Draw = new Vector2((int)FullScreen.X, (int)FullScreen.Y);
            return Draw;
        }

        //thanks blushiemagic!
        public static void MoveTowards(this NPC npc, Vector2 playerTarget, float speed, float turnResistance)
        {
            var Move = playerTarget - npc.Center;
            float Length = Move.Length();
            if (Length > speed)
            {
                Move *= speed / Length;
            }
            Move = (npc.velocity * turnResistance + Move) / (turnResistance + 1f);
            Length = Move.Length();
            if (Length > speed)
            {
                Move *= speed / Length;
            }
            npc.velocity = Move;
        }

        //thanks graydee!
        public static bool Placement(int x, int y)
        {
            for (var i = x - 16; i < x + 16; i++)
            {
                for (var j = y - 16; j < y + 16; j++)
                {
                    if (Main.tile[i, j].liquid > 0)
                    {
                        return false;
                    }
                    int[] TileArray = { TileID.BlueDungeonBrick, TileID.GreenDungeonBrick, TileID.PinkDungeonBrick, TileID.Cloud, TileID.RainCloud, 147, 53, 60, 40, 23, 199, 25, 203 };
                    for (var ohgodilovememes = 0; ohgodilovememes < TileArray.Length - 1; ohgodilovememes++)
                    {
                        if (Main.tile[i, j].type == (ushort)TileArray[ohgodilovememes])
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        //thanks graydee!
        public static bool PlacementTower(int x, int y)
        {
            for (var i = x - 16; i < x + 16; i++)
            {
                for (var j = y - 16; j < y + 16; j++)
                {
                    if (Main.tile[i, j].liquid > 0)
                    {
                        return false;
                    }
                    int[] TileArray = { TileID.BlueDungeonBrick, TileID.GreenDungeonBrick, TileID.PinkDungeonBrick, TileID.Cloud, TileID.RainCloud, 147, 53, 60, 40 };
                    for (var ohgodilovememes = 0; ohgodilovememes < TileArray.Length - 1; ohgodilovememes++)
                    {
                        if (Main.tile[i, j].type == (ushort)TileArray[ohgodilovememes])
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public static bool NextBool(this UnifiedRandom rand, int chance, int total)
        {
            return rand.Next(total) < chance;
        }

        public static void Log(object message)
        {
            ErrorLogger.Log(String.Format("[Antiaris][{0}] {1}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), message));
        }

        public static void Log(string format, params object[] args)
        {
            ErrorLogger.Log(String.Format("[Antiaris][{0}] {1}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), String.Format(format, args)));
        }

        public static void TeleportTo(Player player, Vector2 position)
        {
            player.grappling[0] = -1;
            player.grapCount = 0;
            for (var i = 0; i < 1000; i++)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == player.whoAmI && Main.projectile[i].aiStyle == 7)
                {
                    Main.projectile[i].Kill();
                }
            }
            player.gravity = 0f;
            Main.screenLastPosition = Main.screenPosition;
            Main.screenPosition.X = player.position.X + (float)(player.width / 2) - (float)(Main.screenWidth / 2);
            Main.screenPosition.Y = player.position.Y + (float)(player.height / 2) - (float)(Main.screenHeight / 2);
            player.position = position;
            player.fallStart = (int)(player.position.Y / 16f);
            player.oldPosition = player.position;
            Main.PlaySound(ModLoader.GetMod("Antiaris").GetLegacySoundSlot(SoundType.Custom, "Sounds/Items/AdventurerItem"), player.position);
        }

        public static void CreateDust(Player player, int dust, int count)
        {
            for (var i = 0; i < count; i++)
            {
                Dust.NewDust(player.position, player.width, player.height / 2, dust);
            }
        }

        public static void ChangeColorTo(Player player, double time, int red, int green, int blue, int value1, int value2, int value3, int value1_, int value2_, int value3_, bool change)
        {
            if (time % 1 == 0)
            {
                if (red > value1 && !change)
                {
                    red--;
                }
                if (blue < value3 && !change)
                {
                    blue++;
                }
                if (green < value2 && !change)
                {
                    green++;
                }
                if (red == value1 && blue == value3 && green == value2)
                {
                    change = true;
                }
                if (red < value1_ && change)
                {
                    red++;
                }
                if (blue > value3_ && change)
                {
                    blue--;
                }
                if (green > value2_ && change)
                {
                    green--;
                }
                if (red == value1_ && blue == value3_ && green == value2_)
                {
                    change = false;
                }
            }
        }

        public static Vector2 RotateVector(Vector2 origin, Vector2 vecToRot, float rot)
        {
            return new Vector2((float)(Math.Cos((double)rot) * ((double)vecToRot.X - (double)origin.X) - Math.Sin((double)rot) * ((double)vecToRot.Y - (double)origin.Y)) + origin.X, (float)(Math.Sin((double)rot) * ((double)vecToRot.X - (double)origin.X) + Math.Cos((double)rot) * ((double)vecToRot.Y - (double)origin.Y)) + origin.Y);
        }

        public static bool Contains(this Rectangle rect, Vector2 pos)
        {
            return rect.Contains((int)pos.X, (int)pos.Y);
        }

        public static void DropItemInstanced(NPC npc, Vector2 Position, Vector2 HitboxSize, int itemType, int itemStack = 1, bool interactionRequired = true)
		{	
			if (itemType <= 0)
				return;
			if (Main.netMode == 2)
			{
				int item = Item.NewItem((int)Position.X, (int)Position.Y, (int)HitboxSize.X, (int)HitboxSize.Y, itemType, itemStack, true, 0, false, false);
				Main.itemLockoutTime[item] = 54000;
				for (int remoteClient = 0; remoteClient < (int)byte.MaxValue; ++remoteClient)
				{
					if ((npc.playerInteraction[remoteClient] || !interactionRequired) && Main.player[remoteClient].active)
						NetMessage.SendData(90, remoteClient, -1, null, item, 0.0f, 0.0f, 0.0f, 0, 0, 0);
				}
				Main.item[item].active = false;
			}
			else if (Main.netMode == 0)
				Item.NewItem((int)Position.X, (int)Position.Y, (int)HitboxSize.X, (int)HitboxSize.Y, itemType, itemStack, false, 0, false, false);
			npc.value = 0.0f;
		}
    }

    [Flags]
    public enum LiquidType
    {
        None = 0,
        Water = 1,
        Lava = 2,
        Honey = 4,
        Any = Water + Lava + Honey
    }
}
