using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Poogle.UI;
using System;

namespace Poogle
{
    public enum UIScreenInfo
    {
        LOADING_SCREEN,
        START_SCREEN,
        END_SCREEN,
        PAUSE_SCREEN,
        IN_GAME_SCREEN
    }

    public sealed class UIManager : MonoBehaviour
    {
        private static UIManager m_Singleton;
        public static UIManager Singleton
        {
            get
            {
                return m_Singleton;
            }
        }

        [SerializeField]
        private List<UIScreen> m_Screens;
        private UIScreen m_ActiveScreen;


        public List<UIScreen> Screens
        {
            get
            {
                return m_Screens;
            }
        }

        public UIScreen GetScreen(UIScreenInfo screenInfo)
        {
            return m_Screens.Find(screen => screen.ScreenInfo == screenInfo);
        }

        void Awake()
        {
            if (m_Singleton != null)
            {
                Destroy(gameObject);
                return;
            }

            m_Singleton = this;
        }

        // Make sure UIManager initialises even though GameManager will init it
        void Start()
        {
            Init();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Init()
        {
            UIScreen loadingScreen = GetScreen(UIScreenInfo.LOADING_SCREEN);
            OpenScreen(loadingScreen);
        }

        public void OpenScreen(UIScreen screen)
        {
            CloseAllScreens();
            screen.UpdateScreenStatus(true);
            m_ActiveScreen = screen;
            
        }

        private void CloseAllScreens()
        {
            foreach (UIScreen screen in m_Screens)
            {
                CloseScreen(screen);
            }
        }

        private void CloseScreen(UIScreen screen)
        {
            if (m_ActiveScreen == screen)
            {
                m_ActiveScreen = null;
            }
            screen.UpdateScreenStatus(false);
        }
    }
}
