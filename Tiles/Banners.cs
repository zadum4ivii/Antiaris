using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Antiaris.Tiles 
{
    public class Banners : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.addTile(Type);
            dustType = -1;
            disableSmartCursor = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Banner");
            name.AddTranslation(GameCulture.Russian, "Знамя");
			name.AddTranslation(GameCulture.Chinese, "旗帜");
            AddMapEntry(new Color(13, 88, 130), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int style = frameX / 18;
            string item;
            switch (style)
            {
                case 0:
                item = "ForestGuardianBanner";
                break;
                case 1:
                item = "BoarBanner";
                break;
                case 2:
                item = "WrathEyeBanner";
                break;
                case 3:
                item = "RuneElementalBanner";
                break;
                case 4:
                item = "WrathZombieBanner";
                break;		
                case 5:
                item = "BabyCreeperBanner";
                break;	
				case 6:
                item = "RobberBanner";
                break;	
                //case 7:
                //item = "";
                //break;	
                case 8:
                item = "LivingSnowmanBanner";
                break;	
                case 9:
                item = "SuspiciousSpiritBanner";
                break;	
                case 10:
                item = "SporeCarrierBanner";
                break;	
                case 11:
                item = "BirdTravellerBanner";
                break;
				case 12:
                item = "JungleFiendBanner";
                break;
				case 13:
                item = "PetrousKnight1Banner";
                break;
				case 14:
                item = "PetrousKnight2Banner";
                break;
				case 15:
                item = "BluePixieBanner";
                break;
				case 16:
                item = "GreenPixieBanner";
                break;
				case 17:
                item = "PurplePixieBanner";
                break;
				case 18:
                item = "RedPixieBanner";
                break;
				case 19:
                item = "TreacherousConjurerBanner";
                break;
                default:
                return;
            }
            Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType(item), 1, false, 0, false, false);
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {
                Player player = Main.LocalPlayer;
                int style = Main.tile[i, j].frameX / 18;
                string type;
                switch (style)
                {
                    case 0:
                    type = "ForestGuardian";
                    break;
                    case 1:
                    type = "Boar";
                    break;	
                    case 2:
                    type = "WrathEye";
                    break;	
                    case 3:
                    type = "RuneElemental";
                    break;	
                    case 4:
                    type = "WrathZombie";
                    break;	
					case 5:
                    type = "BabyCreeper";
                    break;	
					case 6:
                    type = "Robber";
                    break;	
					//case 7:
                    //type = "";
                    //break;	
                    case 8:
                    type = "LivingSnowman";
                    break;	
                    case 9:
                    type = "SuspiciousSpirit";
                    break;	
                    case 10:
                    type = "SporeCarrier";
                    break;		
					case 11:
                    type = "BirdTraveller";
                    break;		
					case 12:
                    type = "JungleFiend";
                    break;
					case 13:
                    type = "PetrousKnight1";
                    break;
					case 14:
                    type = "PetrousKnight2";
                    break;
					case 15:
                    type = "BluePixie";
                    break;
					case 16:
                    type = "GreenPixie";
                    break;
					case 17:
                    type = "PurplePixie";
                    break;
					case 18:
                    type = "RedPixie";
                    break;
					case 19:
					type = "TreacherousConjurer";
					break;
                    default:
                    return;
                }
                player.NPCBannerBuff[mod.NPCType(type)] = true;
                player.hasBanner = true;
            }
        }

        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if (i % 2 == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
        }
    }
}
