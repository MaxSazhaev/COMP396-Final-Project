/* Author: Max Sazhaev, Joshua Korovesi
 * File: NextLevel.cs
 * Creation Date: December 18th 2015
 * Description: This script controls the collision between the door and player on the first level.
 */

using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

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
            GameObject thePlayer = GameObject.Find("Game Controller");
            GameController playerScript = thePlayer.GetComponent<GameController>();
            PlayerPrefs.SetInt("score", playerScript._scoreValue);
            Debug.Log(playerScript._scoreValue);
            Application.LoadLevel(2);
        }
    }
}
