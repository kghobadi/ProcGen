using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour {

    public float speed = 2.0f;
    public float scrollSpeed = 2.0f;
    CharacterController player;

    public Animation pickAxe;
    public AudioSource miner;
    public AudioClip mining;

    public ParticleSystem rockBits;
    

    float moveForwardBackward;
    float moveLeftRight;
    float moveUpDown;


    void Start () {
        player = GetComponent<CharacterController>();

    }
	
	void Update () {
        moveForwardBackward = Input.GetAxis("Vertical") * speed;
        moveLeftRight = Input.GetAxis("Horizontal") * speed;
        moveUpDown = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;

        Vector3 movement = new Vector3(moveLeftRight, moveUpDown , moveForwardBackward);

        movement = transform.rotation * movement;
        player.Move(movement * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Mine());
        }



    }

    public IEnumerator Mine()
    {
        pickAxe.Play();
        miner.PlayOneShot(mining);
        
        yield return new WaitForSeconds(0.25f);
        rockBits.Play();
        yield return new WaitForSeconds(0.75f);

        pickAxe.Stop();
        rockBits.Stop();
        


    }
}
