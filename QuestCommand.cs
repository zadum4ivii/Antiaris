using Antiaris.NPCs.Town;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Commands
{
	public class QuestCommand : ModCommand
	{
	    public override string Command
		{
			get 
            {
                 return "quest";
            }
		}

	    public override string Usage
		{
			get 
            {
                 return "/quest";
            }
		}

	    public override string Description
		{
			get 
            {
                 return Language.GetTextValue("Mods.Antiaris.Information");
            }
		}

	    public override CommandType Type
		{
			get 
            {
                 return CommandType.Chat;
            }
		}

	    public override void Action(CommandCaller caller, string input, string[] args)
        {
            var questSystem = Main.player[Main.myPlayer].GetModPlayer<QuestSystem>(mod);
            var NewQuest = QuestSystem.ChooseNewQuest();
            Main.NewText("Current Quest" + ": " + questSystem.CurrentQuest);
			Main.NewText("Today Quest" + ": " + (questSystem.CompletedToday ? " Completed" : "Not completed"));
            Main.NewText("Total Score" + ": " + questSystem.CompletedTotal + " finished quests");
        }
	}
}