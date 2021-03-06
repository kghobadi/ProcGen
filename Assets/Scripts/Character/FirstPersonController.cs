﻿using System.Collections;
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

    Vector3 targetPosition; // for point to click

    public int rockCounter;
    public bool IAmMining = false;


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
        
        



    }

    public void PlayMine()
    {
        StartCoroutine(Mine());
    }

    public IEnumerator Mine()
    {
        IAmMining = true;
        pickAxe.Play();
        miner.PlayOneShot(mining);
        
        yield return new WaitForSeconds(0.25f);
        rockBits.Play();
        yield return new WaitForSeconds(0.65f);

        pickAxe.Stop();
        rockBits.Stop();
        IAmMining = false;
        Debug.Log("MINING FINISHED!");
        yield break;
        //NEEd TO FIGURE OUT WHY THIS WONT STOP ON LAST HIT 
        


    }
}
