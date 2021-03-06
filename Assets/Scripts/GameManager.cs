﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Poogle
{
    public class GameManager : MonoBehaviour
    {

        private static GameManager m_Singleton;
        public static GameManager Singleton
        {
            get
            {
                return m_Singleton;
            }
        }             //Singleton pattern. A reference to our game control script so we can access it statically.
        public Text scoreText;                          //A reference to the UI text component that displays the player's score.
        public GameObject gameOverText;                 //A reference to the object that displays the text which appears when the player dies.
        public GameObject gameOverBackground;           //A reference to the object that greys the background when the player dies.
        public bool gameOver = false;                  //Is the game over?
        private int m_Score = 0;                          //The player's score.
        public float scrollSpeed = -1.2f;               //Repeating background movement speed
        public float obstacleSpawnTimeInterval = 5f;            //How quickly obstacles spawn. One every spawnTimeInterval seconds.

        private bool m_GameStarted = false;
        private bool m_GameRunning = false;
        private bool m_AudioEnabled = true;

        private void Awake()
        {
            if (m_Singleton != null)
            {
                Destroy(gameObject);
                return;
            }
            m_Singleton = this;
        }

        private void Start()
        {
            Init();
        }

        // Update is called once per frame
        void Update()
        {

            //If the game is over and the player has pressed some input...
            if (gameOver && Input.GetMouseButtonDown(0))
            {
                //...reload the current scene.
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            //  Android back button is treated the same as the "Escape" KeyCode
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ExitGame();
            }
        }

        public void Init()
        {
            // Uncomment the lines below after UIManager is setup properly
            EndGame();
            UIManager.Singleton.Init();
            StartCoroutine(Load());
        }

        private IEnumerator Load()
        {
            var startScreen = UIManager.Singleton.Screens.Find(screen => screen.ScreenInfo == UIScreenInfo.START_SCREEN);
            yield return new WaitForSecondsRealtime(3f);
            UIManager.Singleton.OpenScreen(startScreen);
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void StartGame()
        {
            m_GameStarted = true;
            ResumeGame();
        }

        public void StopGame()
        {
            m_GameRunning = false;
            Time.timeScale = 0f;
        }

        public void ResumeGame()
        {
            m_GameRunning = true;
            Time.timeScale = 1f;
        }

        public void EndGame()
        {
            m_GameStarted = false;
            StopGame();
        }

        public void CharacterScored()
        {
            //Character can't score if the game is over.
            if (gameOver)
                return;
            //If the game is not over, increase the score...
            m_Score++;
            //...and adjust the score text.
            scoreText.text = "Score: " + m_Score.ToString();
            //...and increase the scroll speed
            scrollSpeed -= 0.2f;
            //...and decrease the spawn rate time interval
            obstacleSpawnTimeInterval -= 0.2f;
        }

        public void CharacterDied()
        {
            //Activate the game over background
            gameOverBackground.SetActive(true);
            //Activate the game over text.
            gameOverText.SetActive(true);
            //Set the game to be over.
            gameOver = true;
        }
    }
}
