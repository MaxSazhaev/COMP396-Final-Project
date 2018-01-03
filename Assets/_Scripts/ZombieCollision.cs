/* Author: Max Sazhaev, Joshua Korovesi
 * File: ZombieCollision.cs
 * Creation Date: December 18th 2015
 * Description: This script controls the collision between the player and the enemy.
 */

using UnityEngine;
using System.Collections;

public class ZombieCollision : MonoBehaviour {

    private GameController gameController;
    public int lifeValue;

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
            gameController.SubtractLife(lifeValue);
        }
        
    }
}
