/* Author: Max Sazhaev, Joshua Korovesi
 * File: ZombieCollision.cs
 * Creation Date: December 18th 2015
 * Description: This script controls the collision between the player and the enemy.
 */

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ManCollision : MonoBehaviour {

    private GameController gameController;
    private int lifeValue = 20;
    public int scoreValue = 1000;
    public int remainingValue = 1;
    public GameObject[] zombieClone;
    public GameObject[] zombiePrefab;
    public AudioClip conversion;
    //public Transform[] spawnPoint;

    

    // Use this for initialization
    void Start()
    {

        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = conversion;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        // If the zombie collides with player it takes away health
        if (other.tag == "Player" || other.tag == "Enemy")
        {
            //Debug.Log("test coll");
            //Instantiate(prefab, c.transform.position, someRotation);
            if (this.tag == "Man")
            {
                //GetComponent<AudioSource>().Play();
                AudioSource.PlayClipAtPoint(conversion, transform.position, 0.5f);
                gameController.SubtractRemaining(remainingValue);
                gameController.AddScore(scoreValue);
                gameController.AddLife(lifeValue);
                if (gameController._remainingValue <= 0 && sceneName == "Level2")
                {
                    GameObject thePlayer = GameObject.Find("Game Controller");
                    GameController playerScript = thePlayer.GetComponent<GameController>();
                    PlayerPrefs.SetInt("score", playerScript._scoreValue + PlayerPrefs.GetInt("score", 0));
                    //Debug.Log(playerScript._scoreValue);
                    //Debug.Log(PlayerPrefs.GetInt("score", 0));
                    Application.LoadLevel(4);
                }
                if (gameController._remainingValue <= 0 && sceneName == "Level3")
                {
                    PlayerPrefs.SetInt("finished", 1);
                    GameObject thePlayer = GameObject.Find("Game Controller");
                    GameController playerScript = thePlayer.GetComponent<GameController>();
                    PlayerPrefs.SetInt("score", playerScript._scoreValue + PlayerPrefs.GetInt("score", 0));
                    //Debug.Log(playerScript._scoreValue);
                    //Debug.Log(PlayerPrefs.GetInt("score", 0));
                    Application.LoadLevel(5);
                }
                SpawnZombie();
                Destroy(this.gameObject);
            }
            
        }
        
    }

    void SpawnZombie()
    {
        zombieClone[0] = Instantiate(zombiePrefab[0], this.transform.position, Quaternion.Euler(0,0,0)) as GameObject;
    }
}
