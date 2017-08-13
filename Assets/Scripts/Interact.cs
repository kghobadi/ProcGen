using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

    private GameObject _player;
    private FirstPersonController _fpc;
    private Mining _mining; // this will change based on what the object is: rock, fish, cook, plant, etc. this will be called _Object
    //create ArrayList of possible Scripts to be referenced

    private int objectSelect = 3; //for switch decider

    public GameObject cammy;

    public AudioSource soundBoard;
    public AudioClip rockPickUp;

    public GameObject interactSymbol;
    public GameObject pickAxeSymbol;
    public GameObject plantSymbol;
    public GameObject miningSymbol;
    public GameObject digSymbol;

    public float withinDistance = 10f;
    public float withinDistanceActive = 5f;

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player"); //searches for Player
        cammy = GameObject.FindGameObjectWithTag("MainCamera"); //searches for Camera
        soundBoard = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>(); //searches for AudioSource on Camera
        interactSymbol = GameObject.FindGameObjectWithTag("InteractSymbol");
        pickAxeSymbol = GameObject.FindGameObjectWithTag("PickAxeSymbol");
        plantSymbol = GameObject.FindGameObjectWithTag("PlantSymbol");
        miningSymbol = GameObject.FindGameObjectWithTag("MiningSymbol");
        digSymbol = GameObject.FindGameObjectWithTag("DigSymbol");
        _mining = GetComponent<Mining>();
    }

    void Start() {
        
        if (gameObject.tag == "Rock") {    //this will be used once array is created
            //_Object.GetComponent<Mining>(); 
            objectSelect = 3;
        }
        if (gameObject.tag == "RockBit")
        {    //this will be used once array is created
            //_Object.GetComponent<Mining>(); 
            objectSelect = 2;
        }
        if (gameObject.tag == "Door")
        {
            //_Object.GetComponent<Door>(); 
            objectSelect = 2;
        }
        if (gameObject.tag == "Plant")
        {
            //_Object.GetComponent<Plant>(); 
            objectSelect = 1;
        }

        interactSymbol.GetComponent<SpriteRenderer>().enabled = false;
        pickAxeSymbol.GetComponent<SpriteRenderer>().enabled = false;
        plantSymbol.GetComponent<SpriteRenderer>().enabled = false;
        miningSymbol.GetComponent<SpriteRenderer>().enabled = false;
        digSymbol.GetComponent<SpriteRenderer>().enabled = false;

    }


    void OnMouseEnter()
    {
        if(Vector3.Distance(transform.position, _player.transform.position) <= withinDistance)
        {
            cammy.GetComponent<camMouseLook>().sensitivityX = 1f;
            cammy.GetComponent<camMouseLook>().sensitivityY = 1f;

            switch (objectSelect)
            {
                case 3:
                    pickAxeSymbol.GetComponent<SpriteRenderer>().enabled = true;
                    break;

                case 2:
                    interactSymbol.GetComponent<SpriteRenderer>().enabled = true;
                    break;

                case 1:
                    plantSymbol.GetComponent<SpriteRenderer>().enabled = true;
                    break;

            }
        }
        

        //must repeat if Statements based on which Object is being interacted with from ArrayList
        
    }

    void OnMouseExit()
    {
        interactSymbol.GetComponent<SpriteRenderer>().enabled = false;
        miningSymbol.GetComponent<SpriteRenderer>().enabled = false;
        plantSymbol.GetComponent<SpriteRenderer>().enabled = false;
        pickAxeSymbol.GetComponent<SpriteRenderer>().enabled = false;
        digSymbol.GetComponent<SpriteRenderer>().enabled = false;
        cammy.GetComponent<camMouseLook>().sensitivityX = 3f;
        cammy.GetComponent<camMouseLook>().sensitivityY = 3f;

    }

    void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) <= withinDistanceActive)
        {
            cammy.GetComponent<camMouseLook>().sensitivityX = 0.5f;
            cammy.GetComponent<camMouseLook>().sensitivityY = 0.5f;

            switch (objectSelect)
            {
                case 3:
                    if(_player.GetComponent<FirstPersonController>().IAmMining == false)
                    {
                        pickAxeSymbol.GetComponent<SpriteRenderer>().enabled = false;
                        miningSymbol.GetComponent<SpriteRenderer>().enabled = true;
                        StartCoroutine(_player.GetComponent<FirstPersonController>().Mine());
                        _mining.rockHealth--;
                        //For some reason, the Mining wont stop on last hit
                    }
                    break;

                case 2:
                    interactSymbol.GetComponent<SpriteRenderer>().enabled = true;
                    soundBoard.PlayOneShot(rockPickUp);
                    Destroy(gameObject);
                    _player.GetComponent<FirstPersonController>().rockCounter++;
                    break;

                case 1:
                    digSymbol.GetComponent<SpriteRenderer>().enabled = true;
                    break;

            }
            //Symbol should change to Active State -- Pickaxe Breaking rock, or disappear?

            //NEED TO ADD LIMITER SO THAT MINING ANIMATION STOPS OVERLAPPING
        }

        
    }
}
