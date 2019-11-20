using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Poogle.UI
{
    public class StartScreen : UIScreen
    {
        [SerializeField]
        protected Button PlayButton = null;
        protected Button HelpButton = null;
        protected Button InfoButton = null;
        protected Button ExitButton = null;

        void Start()
        {
            PlayButton.SetButtonAction(() =>
            {
                var uiManager = UIManager.Singleton;
                var inGameScreen = uiManager.Screens.Find(screen => screen.ScreenInfo == UIScreenInfo.IN_GAME_SCREEN);
                if (inGameScreen != null)
                {
                    uiManager.OpenScreen(inGameScreen);
                    //GameManager.Singleton.StartGame();
                }
            });

            ExitButton.SetButtonAction(() =>
            {
                //GameManager.Singleton.ExitGame();
            });
        }

        public override void UpdateScreenStatus(bool open)
        {
            base.UpdateScreenStatus(open);
        }
    }
}
