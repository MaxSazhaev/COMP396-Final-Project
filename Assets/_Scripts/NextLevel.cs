/* Author: Max Sazhaev, Joshua Korovesi
 * File: NextLevel.cs
 * Creation Date: December 18th 2015
 * Description: This script controls the collision between the door and player on the first level.
 */

using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Application.LoadLevel(2);
        }
    }
}
