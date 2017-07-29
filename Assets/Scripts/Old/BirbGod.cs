using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirbGod : MonoBehaviour {

    // you don't have to use GameObject or Transform to instantiate,
    // you can also use your own scripts, e.g. to enforce specific scripts being on the prefab
    public Bird birdPrefab; // assign in Inspector!

    List<Bird> allMyBirds = new List<Bird>(); // list is to remember all the birbs

	void Update () {
        // if I press B, then instantiate another bird
        if (Input.GetKeyDown(KeyCode.B))
        {
            Bird newBirdClone = Instantiate(birdPrefab, Random.insideUnitSphere * 10f, Quaternion.Euler(0f, 0f, 0f));
            if(Random.Range(0f, 100f) < 50f)
            {
                newBirdClone.speed = Random.Range(1f, 50f); //50% chance for slow bird
            }
            else
            {
                newBirdClone.speed = Random.Range(50f, 100f); //50% chance for fast birb
            }
            allMyBirds.Add(newBirdClone); //remember this new birb in the list
        }

        //if we hold down SPACE, have all the birds come home
        if (Input.GetKey(KeyCode.Space))
        {
            foreach (Bird thisBird in allMyBirds)
            {
                thisBird.transform.LookAt(Camera.main.transform.position);
            }
        }
		
	}
}
