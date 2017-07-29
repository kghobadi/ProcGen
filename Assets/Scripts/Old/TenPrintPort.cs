using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TenPrintPort : MonoBehaviour {

    // 1. define your prefab variables
    public GameObject corn1, corn2;

	void Start () {
        // 2 call the Instantiate function
        //Quaternion.Identity is shortcut for Quaternion.Euler(0,0,0)
        //Instantiate(prefabA, new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));

        //For Loops:
        //1st: usually define a counter
        //2nd: the if() statement it will use to know whether to keep going
        //3rd: what to do at the end
        for (int y = 0; y < 50; y++) //rows
        {
            for (int x = 0; x < 50; x++) // columns
            {
                if (Random.Range(0f, 1f) < 0.5f) // 50% chance of happening
                {
                    Instantiate(corn1, new Vector3(x * 5f, 0f, y * 5f), Quaternion.Euler(0f, 45f, 0f));
                }
                else //50% chance of happening
                {
                    Instantiate(corn2, new Vector3(x * 5f, 0f, y * 5f), Quaternion.Euler(0f, 45f, 0f));
                }
            }
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
		
	}
}