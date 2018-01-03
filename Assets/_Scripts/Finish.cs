/* Author: Max Sazhaev, Joshua Korovesi
 * File: Finish.cs
 * Creation Date: December 18th 2015
 * Description: This script controls the collision between the car and the player.
 */

using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            // Send to end game scene
            Application.LoadLevel(6);
        }
    }
}
