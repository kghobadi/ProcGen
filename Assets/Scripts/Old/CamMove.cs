using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{

    Vector3 average = Vector3.zero;

    private Vector3 GetMeanVector(Vector3[] positions)
    {
        if (positions.Length == 0)
            return Vector3.zero;
        float x = 0f;
        float y = 0f;
        float z = 0f;
        foreach (Vector3 pos in positions)
        {
            x += pos.x;
            y += pos.y;
            z += pos.z;
        }
        return new Vector3(x / positions.Length, y / positions.Length, z / positions.Length);
    }

    void Update()
    {
        Vector3[] tiles = FloorGenerationVariables.Instance.allTheFloorTiles.ToArray();
        Vector3 movement = GetMeanVector(tiles);
        transform.position.Set(movement.x, movement.y, movement.z);
    }

}
