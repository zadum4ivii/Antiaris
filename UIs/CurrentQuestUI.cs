using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
    class CurrentQuestUI : UIState
    {
        /// <summary>
        /// Код по трекер квестов by ShitcoderXXX ака Дерьмовый Мемер
        /// Задум, если код гавно - я не виноват, сам меня позвал xD
        /// олсо, буду оставлять коменты на русском подо всё шо делаю
        /// </summary>
        public UIPanel CurrentQuestPanel; // сама панелька интерфейса. К ней будем цеплять кнопочки и на ней же будем письмена делать
        public static bool visible = false; // видна ли панелька али нет.
        public UIText iText;
        public UISilentButton description;
        public const int chineseLength = 26;
        public const int russianLength = 34;
        public const int englishLength = 50;
        public const float defaultPos = 300f;
        public float textScale = 1f;// чтобы изменять размер текста в будующем
        public override void OnInitialize()
        {
            #region panel
            CurrentQuestPanel = new UIPanel();
            CurrentQuestPanel.Top.Set(200f, 0f);//Позиция сверху на экране
            CurrentQuestPanel.Left.Set(Main.screenWidth / 2 - 293f, 0f);//Позиция слева на экране
            CurrentQuestPanel.Width.Set(450f, 0f);//размер по ширине в пикселях
            CurrentQuestPanel.Height.Set(460f, 0f);//размер по высоте в пикселях
            CurrentQuestPanel.SetPadding(0f); //Честно, сам без понятия, но вроде надо :shrug:

            /*CurrentQuestPanel.OnMouseDown += new UIElement.MouseEvent(DragStart);
            CurrentQuestPanel.OnMouseUp += new UIElement.MouseEvent(DragEnd);*/
            #endregion
            iText = new UIText("");
            iText.Top.Set(15f, 0f);
            iText.Left.Set(17f, 0f);
            iText.Width.Set(253f, 0f);
            iText.Height.Set(158f, 0f);
            iText.SetPadding(0f);
            iText.MaxWidth.Set(253f, 0f);
            iText.Text.Split(' ');

            CurrentQuestPanel.Append(iText);

            base.Append(CurrentQuestPanel); 
        }

        public override void Update(GameTime gameTime)
        {
            if (!QuestTrackerUI.visible)
                visible = false;
            Player player = Main.LocalPlayer;
            QuestSystem mPlayer = player.GetModPlayer<QuestSystem>();
            string newText = "";
            string AdventurerHelp = Language.GetTextValue("Mods.Antiaris.AdventurerHelp");
            string AdventurerSaid = Language.GetTextValue("Mods.Antiaris.AdventurerSaid");
            string NoTask = Language.GetTextValue("Mods.Antiaris.NoTask");
            if (mPlayer.CurrentQuest != -1)
                newText = Language.GetTextValue("Mods.Antiaris.Quest" + (mPlayer.CurrentQuest));
            if (mPlayer.CurrentQuest != -1)
                if(Language.ActiveCulture == GameCulture.Russian)
                    iText.SetText(AdventurerSaid + "\n" + "`" + SpliceText(newText, russianLength) + "`" + SpliceText(AdventurerHelp, russianLength), .8f, false);
                else if(Language.ActiveCulture == GameCulture.Chinese)
                    iText.SetText(AdventurerSaid + "\n" + "`" + SpliceText(newText, chineseLength) + "`" + SpliceText(AdventurerHelp, chineseLength), .8f, false);
                else
                    iText.SetText(AdventurerSaid + "\n" + "`" + SpliceText(newText, englishLength) + "`" + SpliceText(AdventurerHelp, englishLength), .8f, false);
            else
                iText.SetText(SpliceText(NoTask, 38), .8f, false);
            if (QuestTrackerUI.visible)
            {
                CurrentQuestPanel.Top.Set(QuestTrackerUI.QuestTrackerPanel.Top.Pixels + 102f, 0f);
                CurrentQuestPanel.Left.Set(QuestTrackerUI.QuestTrackerPanel.Left.Pixels - 80f, 0f);
            }
            Recalculate();
        }

        /*Vector2 offset;
        public bool dragging = false;
        private void DragStart(UIMouseEvent evt, UIElement listeningElement)
        {
            offset = new Vector2(evt.MousePosition.X - CurrentQuestPanel.Left.Pixels, evt.MousePosition.Y - CurrentQuestPanel.Top.Pixels);
            dragging = true;
        }

        private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            dragging = false;

            CurrentQuestPanel.Left.Set(end.X - offset.X, 0f);
            CurrentQuestPanel.Top.Set(end.Y - offset.Y, 0f);

            Recalculate();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
            if (CurrentQuestPanel.ContainsPoint(MousePosition))
            {
                Main.LocalPlayer.mouseInterface = true;
            }
            if (dragging)
            {
                CurrentQuestPanel.Left.Set(MousePosition.X - offset.X, 0f);
                CurrentQuestPanel.Top.Set(MousePosition.Y - offset.Y, 0f);
                Recalculate();
            }
        }*/

        public string SpliceText(string text, int lineLength)
        {
            if (Language.ActiveCulture != GameCulture.Chinese)
                return Regex.Replace(text, "(.{" + lineLength + "})" + ' ', "$1" + Environment.NewLine);
            else
                return Regex.Replace(text, "(.{" + lineLength + "})", "$1" + Environment.NewLine);
        }
    }
}