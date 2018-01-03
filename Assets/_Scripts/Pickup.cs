/* Author: Max Sazhaev, Joshua Korovesi
 * File: Pickup.cs
 * Creation Date: December 18th 2015
 * Description: This script controls the functionality of collecting gas cans.
 */

using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

    public int scoreValue;
    private GameController gameController;

    // Use this for initialization
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameController.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
