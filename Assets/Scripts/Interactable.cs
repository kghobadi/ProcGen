﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected GameObject _player;
    protected GameObject cammy;
    protected SpriteRenderer symbol;
    public Sprite sprite;

    protected float withinDistance = 10f;
    protected float withinDistanceActive = 5f;

    protected AudioSource soundBoard;
    public AudioClip InteractSound;

    public virtual void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player"); //searches for Player
        cammy = GameObject.FindGameObjectWithTag("MainCamera"); //searches for Camera
        symbol = GameObject.FindGameObjectWithTag("Symbol").GetComponent<SpriteRenderer>(); //searches for InteractSymbol
        soundBoard = cammy.GetComponent<AudioSource>(); //assigns audio source
    }
    
    void OnMouseEnter()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) <= withinDistance)
        {
            cammy.GetComponent<camMouseLook>().sensitivityX = 1f;
            cammy.GetComponent<camMouseLook>().sensitivityY = 1f;
            symbol.sprite = sprite;
            symbol.enabled = true;
        }
    }

    void OnMouseExit()
    {
        symbol.GetComponent<SpriteRenderer>().enabled = false;
        cammy.GetComponent<camMouseLook>().sensitivityX = 3f;
        cammy.GetComponent<camMouseLook>().sensitivityY = 3f;
    }

    public virtual void handleClickSuccess()
    {
        symbol.GetComponent<SpriteRenderer>().enabled = true;
        cammy.GetComponent<camMouseLook>().sensitivityX = 0.5f;
        cammy.GetComponent<camMouseLook>().sensitivityY = 0.5f;
        Play();
    }

    public virtual void handleClickFailure()
    {
        // handlea click that's too far away or delete this method.
    }

    void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) <= withinDistanceActive)
        {
            handleClickSuccess();
        }
        else
        {
            handleClickFailure();
        }
    }

    void Play()
    {
        soundBoard.PlayOneShot(InteractSound);
    }
}









