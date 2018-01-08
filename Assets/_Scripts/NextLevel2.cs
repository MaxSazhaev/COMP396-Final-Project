/* Author: Max Sazhaev, Joshua Korovesi
 * File: NextLevel2.cs
 * Creation Date: December 18th 2015
 * Description: This script controls the collision between the door and player on the second level.
 */
 // doesnt do anything

using UnityEngine;
using System.Collections;

public class NextLevel2 : MonoBehaviour {
    //private int numberConverted = 0;
    //public int numberToContinue;
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
        if (col.tag == "Man")
        {
            //numberConverted++;
            Debug.Log(gameController._remainingValue);
            if (gameController._remainingValue <= 0)
            {
                GameObject thePlayer = GameObject.Find("Game Controller");
                GameController playerScript = thePlayer.GetComponent<GameController>();
                PlayerPrefs.SetInt("score", playerScript._scoreValue + PlayerPrefs.GetInt("score", 0));
                Debug.Log(playerScript._scoreValue);
                Debug.Log(PlayerPrefs.GetInt("score", 0));
                Application.LoadLevel(4);
            }
        }
    }
}
