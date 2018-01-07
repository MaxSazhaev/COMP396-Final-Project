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
    //public Transform[] spawnPoint;

    

    // Use this for initialization
    void Start()
    {
        
        
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
            Debug.Log("test coll");
            //Instantiate(prefab, c.transform.position, someRotation);
            if (this.tag == "Man")
            {
                gameController.SubtractRemaining(remainingValue);
                if (gameController._remainingValue <= 0 && sceneName == "Level2")
                {
                    Application.LoadLevel(4);
                }
                if (gameController._remainingValue <= 0 && sceneName == "Level3")
                {
                    Application.LoadLevel(5);
                }
                gameController.AddScore(scoreValue);
                gameController.AddLife(lifeValue);
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
