using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePaint : MonoBehaviour {

    public GameObject spherePrefab;
	
	// Update is called once per frame
	void Update () {
        // 1. Construct our "Ray"
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // 2. declare RaycastHit, save some memory for later
        RaycastHit rayHit = new RaycastHit();

        // 3. shoot our raycast
        if(Physics.Raycast(ray, out rayHit) && Input.GetMouseButton(0))
        {
            // 4. Instantiate a sphere at "rayHit.point"
            Instantiate(spherePrefab, rayHit.point, Quaternion.Euler(0f, 0f, 0f));
        }
		
	}
}
