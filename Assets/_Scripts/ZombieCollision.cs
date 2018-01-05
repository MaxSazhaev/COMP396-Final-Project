/* Author: Max Sazhaev, Joshua Korovesi
 * File: ZombieCollision.cs
 * Creation Date: December 18th 2015
 * Description: This script controls the collision between the player and the enemy.
 */

using UnityEngine;
using System.Collections;

public class ZombieCollision : MonoBehaviour {

    private GameController gameController;
    private int lifeValue = 20;
    public int scoreValue = 1000;
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
        // If the zombie collides with player it takes away health
        if (other.tag == "Player")
        {
            //Instantiate(prefab, c.transform.position, someRotation);
            if (this.tag == "Man")
            {
                SpawnZombie();
                Destroy(this.gameObject);
            }
            gameController.AddScore(scoreValue);
            gameController.AddLife(lifeValue);
        }
        
    }

    void SpawnZombie()
    {
        zombieClone[0] = Instantiate(zombiePrefab[0], this.transform.position, Quaternion.Euler(0,0,0)) as GameObject;
    }
}
