using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorGenerator : MonoBehaviour {
    
    public Transform beachBallPrefab;
    public Transform umbrellaPrefab;
    public Transform beachChairPrefab;
    public Transform pathMakerSpherePrefab;
    public float moveSpeed;
    private int timeCounter = 0;
    public static int globalTileCounter = 0;
    

    //Use the list to calculate the average position at the end for dynamic camera pos
    // Sliders will need variables in place of all the 'percentage' chance numbers
    //Tune it some more
    
	void Update () {

        int globalTileCountTemp = FloorGenerationVariables.globalTileCount;

        if (timeCounter < 75 && globalTileCounter < globalTileCountTemp) 
        {
            float mainValue = Random.Range(0f, 1f); //decides which way it will go
            if (mainValue < 0.25f) //rotates and transform.up
            {
                float randRotate = (Random.Range(0f, 100f));
                if (randRotate < 37.5f)
                {
                    transform.Rotate(90f, 0f, 0f);
                }
                else if (randRotate > 37.5f && randRotate < 75f)
                {
                    transform.Rotate(-90f, 0f, 0f);
                }
                else if (randRotate > 75f)
                {
                    transform.Rotate(180f, 0f, 0f);
                }
                transform.localPosition += transform.up * moveSpeed;
                Transform newTileClone = Instantiate(umbrellaPrefab, transform.position, Quaternion.Euler(0f, 0f, 90f));
                if (FloorGenerationVariables.Instance.allTheFloorTiles.Contains(newTileClone.position))
                {
                    Destroy(newTileClone.gameObject);
                    Debug.Log("destroyed tile");
                }
                else
                {
                    FloorGenerationVariables.Instance.allTheFloorTiles.Add(newTileClone.position);
                    globalTileCounter += 1;
                }
            }
            else if (mainValue > 0.25f && mainValue < 0.5f) //rotates and transform.forward
            {
                float randRotate = (Random.Range(0f, 100f));
                if (randRotate < 37.5f)
                {
                    transform.Rotate(90f, 0f, 0f);
                }
                else if (randRotate > 37.5f && randRotate < 75f)
                {
                    transform.Rotate(-90f, 0f, 0f);
                }
                else if (randRotate > 75f)
                {
                    transform.Rotate(180f, 0f, 0f);
                }
                transform.localPosition += transform.forward * moveSpeed;
                Transform newTileClone = Instantiate(beachBallPrefab, transform.position, Quaternion.Euler(0f, 0f, 90f));
                if (FloorGenerationVariables.Instance.allTheFloorTiles.Contains(newTileClone.position))
                {
                    Destroy(newTileClone.gameObject);
                    Debug.Log("destroyed tile");
                }
                else
                {
                    FloorGenerationVariables.Instance.allTheFloorTiles.Add(newTileClone.position);
                    globalTileCounter += 1;
                }
            }
            else if (mainValue > 0.5f && mainValue < 0.975f) //no rotation and moves either forward/backward
            {
                if (Random.Range(0f, 100f) < 75f)
                {
                    transform.localPosition += transform.forward * moveSpeed;
                }
                else
                {
                    transform.localPosition += transform.up * moveSpeed;
                }
                Transform newTileClone = Instantiate(beachChairPrefab, transform.position, Quaternion.Euler(0f, 0f, 90f));
                if (FloorGenerationVariables.Instance.allTheFloorTiles.Contains(newTileClone.position))
                {
                    Destroy(newTileClone.gameObject);
                    Debug.Log("destroyed tile");
                }
                else
                {
                    FloorGenerationVariables.Instance.allTheFloorTiles.Add(newTileClone.position);
                    globalTileCounter += 1;
                }
            }
            else if (mainValue >= 0.975f && mainValue <= 1.0f)
            {
                Transform newPathMakerClone = Instantiate(pathMakerSpherePrefab, transform.position, Quaternion.identity);
                FloorGenerationVariables.Instance.allPathMakers.Add(newPathMakerClone);
            }
            timeCounter += 1;
        }
        else
        {
            Destroy(this.gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(this.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene();
        }

    }
}
