using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    public float speed = 5f;
    
	void Update () {
        // fly forward based on "speed"
        transform.Translate(0f, 0f, speed * Time.deltaTime);
        
        // every now and then, randomly turn left or right
        if(Random.Range(0f, 100f) > 99f) //runs at 1% of frames
        {
            if(Random.Range(0f, 100f) > 50f)
            {
                transform.Rotate(0f, 45f, 0f);
            }
            else
            {
                transform.Rotate(0f, -45f, 0f);
            }
        }

    }
}
