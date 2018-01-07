/* Author: Max Sazhaev, Joshua Korovesi
 * File: EnemyAI.cs
 * Creation Date: December 18th 2015
 * Description: This script controls way enemies move towards the player.
 */

using UnityEngine;
using System.Collections;

public class HumanAI : MonoBehaviour {

    Transform tr_Player;
    float f_RotSpeed = 3.0f, f_MoveSpeed = 3.0f;
    void Start()
    {
        tr_Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation
            , Quaternion.LookRotation(tr_Player.position - transform.position)
            , f_RotSpeed * Time.deltaTime);

        transform.position -= transform.forward * f_MoveSpeed * Time.deltaTime;
    }
}
