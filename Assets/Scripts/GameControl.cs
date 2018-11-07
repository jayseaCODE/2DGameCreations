using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public static GameControl instance;             //Singleton pattern. A reference to our game control script so we can access it statically.
    public Text scoreText;                          //A reference to the UI text component that displays the player's score.
    public GameObject gameOverText;                 //A reference to the object that displays the text which appears when the player dies.
    public bool gameOver = false;                  //Is the game over?
    private int score = 0;                          //The player's score.
    public float scrollSpeed = -1.5f;               //Repeating background movement speed

    private void Awake()
    {
        //If we don't currently have a game control...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if (instance != this)
            //...destroy this one because it is a duplicate.
            Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {

        //If the game is over and the player has pressed some input...
        if (gameOver && Input.GetMouseButtonDown(0))
        {
            //...reload the current scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}

    public void CharacterScored()
    {
        //Character can't score if the game is over.
        if (gameOver)
            return;
        //If the game is not over, increase the score...
        score++;
        //...and adjust the score text.
        scoreText.text = "Score: " + score.ToString();
    }

    public void CharacterDied()
    {
        //Activate the game over text.
        gameOverText.SetActive(true);
        //Set the game to be over.
        gameOver = true;
    }
}
