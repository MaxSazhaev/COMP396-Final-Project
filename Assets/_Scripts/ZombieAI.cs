﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour {

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

        transform.position += transform.forward * f_MoveSpeed * Time.deltaTime;
    }
}
