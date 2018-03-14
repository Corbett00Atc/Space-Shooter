using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public GameObject missile;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public float missileDelay;
    public float missileStartDelay;
    public GUIText scoreText;
    private int score;

    void Start()
    {

        score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves());
    }



    // spawn asteroids
    IEnumerator SpawnWaves()
    {

        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < (hazardCount + score / 50); i++)
            {
                Vector3 spawnPosition = new Vector3
                    (
                        Random.Range(-spawnValues.x, spawnValues.x),
                        spawnValues.y,
                        spawnValues.z
                    );

                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds((spawnWait - (float)(.5 * score * .001)));

                if (GameOver.gameOver == true)
                {
                    break;
                }
            }

            yield return new WaitForSeconds(waveWait - (float)((float)((int)score / 100) * .1));
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
    