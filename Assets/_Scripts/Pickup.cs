﻿/* Author: Max Sazhaev, Joshua Korovesi
 * File: Pickup.cs
 * Creation Date: December 18th 2015
 * Description: This script controls the functionality of collecting gas cans.
 */

using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

    public int scoreValue;
    private GameController gameController;
    public AudioClip pickup;

    // Use this for initialization
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = pickup;
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
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
            
            AudioSource.PlayClipAtPoint(pickup, transform.position, 0.2f);
            gameController.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
