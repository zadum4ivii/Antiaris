using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Antiaris;
using Terraria.Localization;
using Antiaris.NPCs.Town;
namespace Antiaris.UIs
{
    class QuestTrackerUI : UIState
    {
        /// <summary>
        /// Код по трекер квестов by ShitcoderXXX ака Дерьмовый Мемер
        /// Задум, если код гавно - я не виноват, сам меня позвал xD
        /// олсо, буду оставлять коменты на русском подо всё шо делаю
        /// </summary>
        public const float defaultTextPos = 73f;
        public const float defaultTextPos2 = 5.2f;
        public const float defaultNamePos = 48f;
        public const float defaultNamePos2 = 10.2f;
        public static UIPanel QuestTrackerPanel; // сама панелька интерфейса. К ней будем цеплять кнопочки и на ней же будем письмена делать
        public static bool visible = true; // видна ли панелька али нет.
        public UIText currentQuest;
        public UIText currentQuestName;
        public UIText currentQuestText;
        public UISilentButton description;
        public float textScale = 1f;// чтобы изменять размер текста в будующем 
        public override void OnInitialize()
        {
            #region UI panel
            QuestTrackerPanel = new UIPanel();
            QuestTrackerPanel.Top.Set(200f, 0f);//Позиция сверху на экране
            QuestTrackerPanel.Left.Set(Main.screenWidth / 2, 0f);//Позиция слева на экране
            QuestTrackerPanel.Width.Set(250f, 0f);//размер по ширине в пикселях
            QuestTrackerPanel.Height.Set(102f, 0f);//размер по высоте в пикселях
            QuestTrackerPanel.SetPadding(0f); //Честно, сам без понятия, но вроде надо :shrug:
            QuestTrackerPanel.BackgroundColor = new Color(255, 255, 255) * 0f; //чтобы прозрачно было
            QuestTrackerPanel.BorderColor = new Color(255, 255, 255) * 0f; // ^

            QuestTrackerPanel.OnMouseDown += new UIElement.MouseEvent(DragStart);
            QuestTrackerPanel.OnMouseUp += new UIElement.MouseEvent(DragEnd);
            // ^ вот это нужно, чтобы панельку можно было таскать
            #endregion
            //Вот дальше идёт хардкоре, ибо дальше идут текста
            #region tracker texts
            currentQuest = new UIText("", textScale); //Ставим пока так, дабы не крашнуло
            currentQuest.Top.Set(10, 0);
            currentQuest.Left.Set(10.2f, 0);
            currentQuest.Width.Set(250, 0);
            currentQuest.Height.Set(102, 0);
            currentQuest.SetPadding(0);
            currentQuest.TextColor = Color.DarkGray;

            currentQuestName = new UIText("", textScale); //Ставим пока так, дабы не крашнуло
            currentQuestName.Top.Set(48, 0);
            currentQuestName.Left.Set(10.2f, 0);
            currentQuestName.Width.Set(250, 0);
            currentQuestName.Height.Set(102, 0);
            currentQuestName.SetPadding(0);
            currentQuestName.TextColor = Color.DarkGray;

            currentQuestText = new UIText("", textScale); //Ставим пока так, дабы не крашнуло
            currentQuestText.Top.Set(73, 0);
            currentQuestText.Left.Set(5.2f, 0);
            currentQuestText.Width.Set(250, 0);
            currentQuestText.Height.Set(102, 0);
            currentQuestText.SetPadding(0);
            currentQuestText.TextColor = Color.DarkGray;
            #endregion          
            description = new UISilentButton(ModLoader.GetTexture("Antiaris/Miscellaneous/QuestIconUI"));
            description.Top.Set(5f, 0f);
            description.Left.Set(222f, 0f);
            description.Height.Set(26, 0f);
            description.Width.Set(78, 0f);
            description.SetPadding(0f);
            description.OnClick += new MouseEvent(PrintInfo);
            QuestTrackerPanel.Append(description);

            QuestTrackerPanel.Append(currentQuest);
            QuestTrackerPanel.Append(currentQuestText);
            QuestTrackerPanel.Append(currentQuestName);
            base.Append(QuestTrackerPanel);
        }
        public override void Update(GameTime gameTime)
        {
            string TrackerButton1 = Language.GetTextValue("Mods.Antiaris.TrackerButton1");
            string TrackerButton2 = Language.GetTextValue("Mods.Antiaris.TrackerButton2");
            string TrackerNoQuest1 = Language.GetTextValue("Mods.Antiaris.TrackerNoQuest1");
            string TrackerNoQuest2 = Language.GetTextValue("Mods.Antiaris.TrackerNoQuest2");
            string TrackerNoQuest3 = Language.GetTextValue("Mods.Antiaris.TrackerNoQuest3");
            string cQuestTranslation = Language.GetTextValue("Mods.Antiaris.CurrentQuest");
            float adjustMore = 0f;
            Player player = Main.LocalPlayer;
            QuestSystem mPlayer = player.GetModPlayer<QuestSystem>();
            currentQuest.SetText(cQuestTranslation);
            if (mPlayer.CurrentQuest == -1)
                adjustMore = 8f;
            else
                adjustMore = 0f;
            if (!Main.gameMenu && player.active && mPlayer.CurrentQuest != -1)
            {
                int cQuest = mPlayer.CurrentQuest;
                string questName = "";
                string questText = "";
                if (mPlayer.CurrentQuest != -1)
                {
                    questName = Language.GetTextValue("Mods.Antiaris.Name" + (cQuest));
                    questText = Something();
                }
                else
                {
                    questName = "";
                    questText = "";
                }
                currentQuestName.SetText(questName, ChangeScale(questName), false);
                currentQuestText.SetText(questText, ChangeScale(questText), false);
                currentQuestText.Top.Set(defaultTextPos + AdjustTextPosition(questText), 0f);
                currentQuestName.Top.Set(defaultNamePos + AdjustTextPosition(questName), 0f);
                currentQuestText.Left.Set(defaultTextPos2 - AdjustTextPosition(questText), 0f);
                currentQuestName.Left.Set(defaultTextPos2 - AdjustTextPosition(questName), 0f);
            }
            else
            {
                string noQuest = TrackerNoQuest1;
                string noQuestText;
                    if (!mPlayer.CompletedToday)
                    noQuestText = TrackerNoQuest2;
                else
                    noQuestText = TrackerNoQuest3;
                currentQuestName.SetText(noQuest, ChangeScale(noQuest), false);
                currentQuestName.Top.Set(defaultNamePos + AdjustTextPosition(noQuest) + adjustMore, 0f);
                currentQuestName.Left.Set(defaultTextPos2 - AdjustTextPosition(noQuest), 0f);
                currentQuestText.SetText(noQuestText, ChangeScale(noQuestText), false);
            }
            Recalculate();
        }

        #region Dragging
        Vector2 offset;
        public bool dragging = false;
        private void DragStart(UIMouseEvent evt, UIElement listeningElement)
        {
            if (visible)
            {
                offset = new Vector2(evt.MousePosition.X - QuestTrackerPanel.Left.Pixels, evt.MousePosition.Y - QuestTrackerPanel.Top.Pixels);
                dragging = true;
            }
        }

        private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            dragging = false;

            QuestTrackerPanel.Left.Set(end.X - offset.X, 0f);
            QuestTrackerPanel.Top.Set(end.Y - offset.Y, 0f);

            Recalculate();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
            if (QuestTrackerPanel.ContainsPoint(MousePosition))
            {
                Main.LocalPlayer.mouseInterface = true;
            }
            if (dragging)
            {
                QuestTrackerPanel.Left.Set(MousePosition.X - offset.X, 0f);
                QuestTrackerPanel.Top.Set(MousePosition.Y - offset.Y, 0f);
                Recalculate();
            }
            if (Antiaris.trackerTexture != null)
                spriteBatch.Draw(Antiaris.trackerTexture, new Vector2(QuestTrackerPanel.Left.Pixels, QuestTrackerPanel.Top.Pixels), Color.White);
        }

        #endregion
        // ^ Вот тут по большей части копипаст из examplemod,
        //ибо по другому хз как сделать интерфейс, который можно перетаскивать :shrug:

        public void PrintInfo(UIMouseEvent evt, UIElement listeningElement)
        {
            Main.PlaySound(12, (int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 0);
            CurrentQuestUI.visible = !CurrentQuestUI.visible;
        }

        public string Something()
        {
            var mod = ModLoader.GetMod("Antiaris");
            var aPlayer = Main.player[Main.myPlayer].GetModPlayer<AntiarisPlayer>(mod);
            var questSystem = Main.player[Main.myPlayer].GetModPlayer<QuestSystem>(mod);
            string CurrentQuest = Language.GetTextValue("Mods.Antiaris.CurrentQuest");
            float scaleMultiplier = 0.5f + 1 * 0.5f;
            int width = (int)(250f * scaleMultiplier);
            int height = (int)(60f * scaleMultiplier);
            var background = mod.GetTexture("Miscellaneous/QuestTracker");
            string Name0 = Language.GetTextValue("Mods.Antiaris.Name0");
            string Name1 = Language.GetTextValue("Mods.Antiaris.Name1");
            string Name2 = Language.GetTextValue("Mods.Antiaris.Name2");
            string Name3 = Language.GetTextValue("Mods.Antiaris.Name3");
            string Name4 = Language.GetTextValue("Mods.Antiaris.Name4");
            string Name5 = Language.GetTextValue("Mods.Antiaris.Name5");
            string Name6 = Language.GetTextValue("Mods.Antiaris.Name6");
            string Name7 = Language.GetTextValue("Mods.Antiaris.Name7");
            string Name8 = Language.GetTextValue("Mods.Antiaris.Name8");
            string Name9 = Language.GetTextValue("Mods.Antiaris.Name9");
            string Name10 = Language.GetTextValue("Mods.Antiaris.Name10");
            string Name11 = Language.GetTextValue("Mods.Antiaris.Name11");
            string Name12 = Language.GetTextValue("Mods.Antiaris.Name12");
            string Name13 = Language.GetTextValue("Mods.Antiaris.Name13");
            string Name14 = Language.GetTextValue("Mods.Antiaris.Name14");
            string Name15 = Language.GetTextValue("Mods.Antiaris.Name15");
            string Name16 = Language.GetTextValue("Mods.Antiaris.Name16");
            string Name17 = Language.GetTextValue("Mods.Antiaris.Name17");
            string Name18 = Language.GetTextValue("Mods.Antiaris.Name18");
            string Name19 = Language.GetTextValue("Mods.Antiaris.Name19");
            string TurnIn = Language.GetTextValue("Mods.Antiaris.TurnIn");

            string[] QuestItems = { "OldCompass", "GlacialCrystal", "Leather", "MonsterSkull", "HarpyEgg", "GoldenApple", "Necronomicon", "Slimes",
            "UndeadMiner", "BirdTraveller", "SilkScarf", "AdventurerFishingRod", "Bonebardier", "DemonWingPiece", "AdventurerChest", "Coconut", "SpiderMass",
            "StolenPresent", "EmeraldShard", "Charcoal"};

            int[] QuestAmount = { 1, 1, 12, 1, 1, 1, 1, 25, 1, 5, 1, 1, 1, 12, 1, 16, 12, 20, 12, 25 };

            string[] QuestNamesEn = { "Old Compass", "Glacial Crystal", "Leather", "Monster Skull", "Harpy Egg", "Golden Apple", "Necronomicon", "Slime",
            "Undead Miner", "Bird Traveller", "Silk Scarf", "Adventurer's Fishing Rod", "Bonebardier", "Demon Wing Piece", "Adventurer's Chest", "Coconut", "Spider Mass",
            "Stolen Present", "Emerald Shard", "Charcoal"};

            string[] QuestNamesRu = { "Старый компас", "Ледяной кристалл", "Кожа", "Череп монстра", "Яйцо гарпии", "Золотое яблоко", "Некрономикон", "Слизень",
            "Мёртвый шахтёр", "Птица-путешественник", "Шёлковый шарф", "Удочка Путешественника", "Костордир", "Часть крыла демона", "Сундук Путешественника", "Кокос", "Паучья масса",
            "Украденные подарки", "Изумруднике осколки", "Древесный уголь"};

            string[] QuestNamesCn = { "旧罗盘", "冰晶体", "皮革", "古生物骸骨", "鹰身女妖的蛋", "金苹果", "死灵法书", "史莱姆",
            "不死矿工", "荼毒女王鸟", "丝绸围巾", "冒险家的鱼竿", "骸骨炮兵", "恶魔翅膀的碎片", "冒险家的箱子", "椰子", "蜘蛛分泌物",
            "偷来的礼物", "翡翠碎片", "木炭"};
			
            string QuestItemName = QuestNamesRu[questSystem.CurrentQuest];
            if (Language.ActiveCulture == GameCulture.Russian)
            {
                QuestItemName = QuestNamesRu[questSystem.CurrentQuest];
            }
            else if (Language.ActiveCulture == GameCulture.Chinese)
            {
                QuestItemName = QuestNamesCn[questSystem.CurrentQuest];
            }
            else
            {
                QuestItemName = QuestNamesEn[questSystem.CurrentQuest];
            }

            int CurrentItemAmount = 0;
            string[] QuestNames = { Name0, Name1, Name2, Name3, Name4, Name5, Name6, Name7, Name8, Name9, Name10, Name11, Name12, Name13, Name14, Name15, Name16, Name17, Name18, Name19 };
            string QuestName = QuestNames[questSystem.CurrentQuest];

            if (questSystem.CurrentQuest >= 0 && questSystem.CurrentQuest != QuestItemID.Leather && questSystem.CurrentQuest != QuestItemID.Charcoal)
            {
                foreach (var player in Main.player)
                {
                    if (player.active)
                    {
                        if (player.HasItem(mod.ItemType(QuestItems[questSystem.CurrentQuest])))
                        {
                            Item[] inventory = player.inventory;
                            for (int k = 0; k < inventory.Length; k++)
                            {
                                if (inventory[k].type == mod.ItemType(QuestItems[questSystem.CurrentQuest]))
                                {
                                    CurrentItemAmount += inventory[k].stack;
                                }
                            }
                        }
                    }
                }
            }

            //Leather Quest
            if (questSystem.CurrentQuest == QuestItemID.Leather)
            {
                foreach (var player in Main.player)
                {
                    if (player.active)
                    {
                        if (player.HasItem(259))
                        {
                            Item[] inventory = player.inventory;
                            for (int k = 0; k < inventory.Length; k++)
                            {
                                if (inventory[k].type == 259)
                                {
                                    CurrentItemAmount += inventory[k].stack; 
                                }
                            }
                        }
                    }
                }
            }
            //overhaul charcoal
            if (questSystem.CurrentQuest == QuestItemID.Charcoal)
            {
                foreach (var player in Main.player)
                {
                    if (player.active)
                    {
                        if (player.HasItem(Antiaris.TerrariaOverhaul.ItemType("Charcoal")))
                        {
                            Item[] inventory = player.inventory;
                            for (int k = 0; k < inventory.Length; k++)
                            {
                                if (inventory[k].type == Antiaris.TerrariaOverhaul.ItemType("Charcoal"))
                                {
                                    CurrentItemAmount += inventory[k].stack;
                                }
                            }
                        }
                    }
                }
            }
            //Mob Quests
            if (questSystem.CurrentQuest == QuestItemID.Traveler || questSystem.CurrentQuest == QuestItemID.Miner || questSystem.CurrentQuest == QuestItemID.Slimes)
            {
                CurrentItemAmount += questSystem.QuestKills;
            }
            if (CurrentItemAmount >= QuestAmount[questSystem.CurrentQuest])
                return TurnIn;
            string addLine = "";
            if (QuestAmount[questSystem.CurrentQuest] > 1)
                addLine = CurrentItemAmount + "/" + QuestAmount[questSystem.CurrentQuest];
            return QuestItemName + " " + addLine;
        }
            
        public float ChangeScale(string text)
        {
            if (text.Length >= 20)
                return .75f;
            else if (text.Length >= 18)
                return .80f;
            return 1f;
        }

        public float AdjustTextPosition(string text)
        {
            if (text.Length >= 20)
                return 4f;
            return 0f;
        }
    }
}
