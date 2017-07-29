using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishInstantiate : MonoBehaviour {
    //THIS COULD BE USED TO MAKE WEATHER, HERDS OF ANIMALS MOVING, CARS MOVING, MANY MANY THINGS

    public Transform fishPrefab;
    // a list is like an array, except a lot better (it's resizable!)
    List<Transform> myFishList = new List<Transform>();
    public float unitSphereSize;
    public float moveSpeed;

	void Start () {
        //we're using this while() loop basically like a for() loop (see TenPrintPort)
        int fishCount = 0;
        while (fishCount < 100)
        {
            //instantiate fish
            Transform newFishClone = (Transform)Instantiate(fishPrefab, Random.insideUnitSphere * unitSphereSize, Random.rotation);
            // it's useful to remember your clone in a variable, so you can refer back to it.
            newFishClone.localScale = Vector3.one * Random.Range(0.5f, 2.5f);
            newFishClone.GetComponent<Renderer>().material.color = Random.ColorHSV();
            myFishList.Add(newFishClone); // add fish clone to the list, to do stuff with it later
            fishCount++;
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        // make every fish swim forward by going through every item in the list
        for (int i = 0; i<myFishList.Count; i++) // ".Count" = how many items in the list
        {
            myFishList[i].Translate(0f, 0f, moveSpeed, Space.World); // Space.World makes them move globally instead of locally
        }

        //when we press SPACE, tell all fish to rotate 90 degrees
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //foreach() is a special for() loop to go through an array or list
            foreach (Transform thisFish in myFishList)
            {
                //thisFish.Rotate(0f, 45f, 0f);
                thisFish.LookAt(Camera.main.transform.position);
            }
        }
		
	}
}
