using UnityEngine;
using System.Collections;

public class Sun : MonoBehaviour {

    public float rotationSpeed = 10;
    public Transform rotation;

    public Light sun;
    
	
	void Update () {
        transform.RotateAround(Vector3.zero, Vector3.right, rotationSpeed * Time.deltaTime);
        transform.LookAt(Vector3.zero);
        float intensity = 0.01f * Time.deltaTime;
        sun.intensity -= intensity;
      

    }
}
