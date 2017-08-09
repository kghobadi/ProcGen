using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining : MonoBehaviour {


    private int rockHealth = 5;


    void Update()
    {
        if(rockHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PickAxe")
        {
            rockHealth--;
        }
    }
}
