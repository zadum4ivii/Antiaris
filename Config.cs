using System.IO;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;

namespace Antiaris
{
	public static class Config
	{
	    const string QuestIconDrawKey = "Quest Tracker";
	    const string WeaponFailsKey = "Weapon Fails";
	    static string ConfigPath = Path.Combine(Main.SavePath, "Mod Configs", "Antiaris.json");
	    static string OldConfigFolderPath = Path.Combine(Main.SavePath, "Mod Configs", "Antiaris");
	    static string OldConfigPath = Path.Combine(OldConfigFolderPath, "config.json");
	    static string OldConfigVersionPath = Path.Combine(OldConfigFolderPath, "config.version");

	    static readonly Preferences Settings = new Preferences(ConfigPath);

	    public static bool QuestIconDraw = true;
	    public static bool WeaponFails = true;

	    public static void Load()
		{
			if(Directory.Exists(OldConfigFolderPath))
			{
				if(File.Exists(OldConfigPath))
				{
					AntiarisHelper.Log("Found config file in old folder! Moving config...");
					File.Move(OldConfigPath, ConfigPath);
				}
				if(File.Exists(OldConfigVersionPath))
					File.Delete(OldConfigVersionPath);
				if(Directory.GetFiles(OldConfigFolderPath).Length == 0 && Directory.GetDirectories(OldConfigFolderPath).Length == 0)
					Directory.Delete(OldConfigFolderPath);
				else
					AntiarisHelper.Log("Old config folder still cotains some files/directories. They will not get deleted.");
			}
			if(!ReadConfig())
				AntiarisHelper.Log("Failed to read config file! Recreating config...");
			SaveConfig();
		}

	    public static bool ReadConfig()
		{
			if(Settings.Load())
			{
				Settings.Get(QuestIconDrawKey, ref QuestIconDraw);
				Settings.Get(WeaponFailsKey, ref WeaponFails);
				return true;
			}
			return false;
		}

	    public static void SaveConfig()
		{
			Settings.Clear();
			Settings.Put(QuestIconDrawKey, QuestIconDraw);
			Settings.Put(WeaponFailsKey, WeaponFails);
			Settings.Save();
		}

	    class MultiplayerSyncWorld : ModWorld
        {
            public override void NetSend(BinaryWriter writer)
            {
                var data = new BitsByte();
                data[0] = QuestIconDraw;
                data[1] = WeaponFails;
                writer.Write((byte)data);
            }

            public override void NetReceive(BinaryReader reader)
            {
                SaveConfig();
                var data = (BitsByte)reader.ReadByte();
                QuestIconDraw = data[0];
                WeaponFails = data[1];
            }
        }

	    class MultiplayerSyncPlayer : ModPlayer
        {
            public override void PlayerDisconnect(Player player)
            {
                ReadConfig();
            }
        }
	}
}
