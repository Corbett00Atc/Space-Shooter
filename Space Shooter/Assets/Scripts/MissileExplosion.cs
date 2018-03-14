using UnityEngine;
using System.Collections;

public class MissileExplosion : GameController
{
    private GameController gameController;
    private int hp = 20;
    public GameObject explosionOnCollide;
    public GameObject explosionOnBoltHit;
    public GameObject explosionOnDestroyed;
    public GameObject explosionOnNuked;
    public GameObject explosionSound;
    private GameObject[] hazards;
    private int scoreValue = 50;
    static bool gameOver = false;



    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }

        if (other.tag == "Player")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            Instantiate(explosionOnCollide, transform.position, transform.rotation);
            Debug.Log("it hit player");
        }

        if (other.tag == "Missile Boundary")
        {
            Destroy(gameObject);
            Instantiate(explosionOnNuked, transform.position, transform.rotation);
            Instantiate(explosionSound, transform.position, transform.rotation);
            Destroy(GameObject.FindWithTag("Player"));
            Instantiate(explosionOnNuked, GameObject.FindWithTag("Player").transform.position, transform.rotation);

            hazards = GameObject.FindGameObjectsWithTag("Hazard");
            for (int i = 0; i < hazards.Length; i++)
            {
                Destroy(hazards[i]);
                Instantiate(explosionOnNuked, hazards[i].transform.position, transform.rotation);
            }
        }

        if (other.tag == "Bolt")
        {
            if (hp > 0)
            {
                hp--;
                gameController.AddScore(1);
            }


            if (hp == 0)
            {
                Destroy(gameObject);
                Instantiate(explosionOnDestroyed, transform.position, transform.rotation);
                gameController.AddScore(scoreValue);
            }
        }
    }
}
