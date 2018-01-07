/* Author: Max Sazhaev, Joshua Korovesi
 * File: EnemyAI.cs
 * Creation Date: December 18th 2015
 * Description: This script controls way enemies move towards the player.
 */

using UnityEngine;
using System.Collections;

public class HumanAI : MonoBehaviour {
    public bool evading;

    Vector3 playerPos, enemyPos;
    GameObject player;

    float playerMaxSpeed = 7f;
    float distance;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        enemyPos = transform.position;

        Vector3 chaseDirection = (playerPos - enemyPos).normalized;

        bool a3_face_b3 = Vector3.Dot(chaseDirection, player.transform.forward) > 0;

        distance = Vector3.Distance(playerPos, enemyPos);

        // chasing
        if (evading && !a3_face_b3 && distance <= 3.0)
        {
            transform.LookAt(playerPos);
            transform.Rotate(0, 180, 0);
            transform.position -= chaseDirection * playerMaxSpeed * Time.deltaTime;
        }
    }
}
/*
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
*/
