using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornPlanting : MonoBehaviour {

    public Transform cornModelPrefab;
    int cornPrefabCounter = 0;
    
	void Start () {
		
	}
	
	void Update () {

        //HOW TO CODE THIS TO ONLY MAKE 500 CORN PLANTS?
        // 1. Put this in a for(0 loop inside Start(), like in TenPrintPort
        // 2. keep a variable that counts up for each clone you make
        if(cornPrefabCounter < 500)
        {
            Instantiate(cornModelPrefab, new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f)), //where we want it
                Quaternion.Euler(0f, Random.Range(0f, 360f), 0f)); //the clone's rotation
            cornPrefabCounter++;
        }
        
		
	}
}
