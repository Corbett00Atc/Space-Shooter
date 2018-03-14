using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    // Bool to change true when game is over
    static public bool gameOver = false;
    private bool restart = false;

    // Text to be displayed
    public GUIText restartText;
    public GUIText gameOverText;

    // Sets initial text to blank to keep invisible
    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
    }

    // Scans every frame to check if player is destroyed
    // If so, tag will be null, updates text "game over" and "restart"
    void Update()
    {

        if (GameObject.FindWithTag("Player") == null)
        {
            gameOverText.text = "Game Over!";
            restart = true;

            // if restart it true, loads scene again on press r and displays text
            if (restart)
            {
                restartText.text = "Press 'R' for Restart";
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }

            gameOver = true;
        }
    }
}
