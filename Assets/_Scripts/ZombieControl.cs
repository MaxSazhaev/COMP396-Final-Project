using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class ZombieControl : MonoBehaviour {

    private GameObject zombie;

	void Update () {
		if(Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit))
            {
                Debug.Log(hit.transform.tag);
                if (hit.transform.tag == "Enemy")
                    zombie = hit.transform.gameObject;
            }
        }
        else if (Input.GetButtonDown("Fire2") && zombie!=null)
        {
            RaycastHit hit;
            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit))
            {
                NavMeshAgent z = zombie.GetComponent<UnityEngine.AI.NavMeshAgent>();
                z.destination = hit.point;
            }

        }
    }
}
