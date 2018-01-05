/* Author: Max Sazhaev, Joshua Korovesi
 * File: NextLevel2.cs
 * Creation Date: December 18th 2015
 * Description: This script controls the collision between the door and player on the second level.
 */

using UnityEngine;
using System.Collections;

public class NextLevel2 : MonoBehaviour {
    private int numberConverted = 0;
    public int numberToContinue;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Man")
        {
            numberConverted++;
            if(numberConverted >= numberToContinue)
            {
                Application.LoadLevel(4);
            }
        }
    }
}
