using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerationVariables : MonoBehaviour {

    public static int globalTileCount = 500;
    

    public List<Vector3> allTheFloorTiles = new List<Vector3>();
    public List<Transform> allPathMakers = new List<Transform>();

    public static FloorGenerationVariables Instance;

    void Awake()
    {
        Instance = this;
    }

}
