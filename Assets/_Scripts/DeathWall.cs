/* Author: Max Sazhaev, Joshua Korovesi
 * File: Deathwall.cs
 * Creation Date: December 18th 2015
 * Description: This script controls the collision between the instant death area and the player.
 */

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathWall : MonoBehaviour   
{
    public int remainingValue = 1;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
            // Send to death screen 1
            Application.LoadLevel(3);
        }
        if (col.tag == "Man")
        {
            gameController.SubtractRemaining(remainingValue);
            Destroy(col.gameObject);
        }
    }
}
