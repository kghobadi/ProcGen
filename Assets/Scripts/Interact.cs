using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

    private GameObject _player;
    private FirstPersonController _fpc;
    private Mining _mining; // this will change based on what the object is: rock, fish, cook, plant, etc. this will be called _Object
    //create ArrayList of possible Scripts to be referenced

    public Camera cammy;

    public AudioSource soundBoard;

    public GameObject interactSymbol;
    public GameObject miningSymbol;

    public float withinDistance = 5f;

    void Start () {
        _player = GameObject.FindGameObjectWithTag("Player"); //searches for Player
        _fpc = GetComponent<FirstPersonController>();
        _mining = GetComponent<Mining>();
        //if(gameobject.tag == "Rock")     this will be used once array is created
        //_Object.GetComponent<Mining>(); 

        interactSymbol.SetActive(false);
        miningSymbol.SetActive(false);

    }
	

	void Update () {
		
        //Not sure I will need this at all!
	}


    void OnMouseEnter()
    {
        if(gameObject.tag == "Rock" && Vector3.Distance(transform.position, _player.transform.position) <= withinDistance)
        {
            miningSymbol.SetActive(true);
            cammy.GetComponent<camMouseLook>().sensitivityX = 0.75f;
            cammy.GetComponent<camMouseLook>().sensitivityY = 0.75f;
        }

        //must repeat if Statements based on which Object is being interacted with from ArrayList
        
    }

    void OnMouseExit()
    {
        interactSymbol.SetActive(false);
        miningSymbol.SetActive(false);
        cammy.GetComponent<camMouseLook>().sensitivityX = 3f;
        cammy.GetComponent<camMouseLook>().sensitivityY = 3f;

    }

    void OnMouseDown()
    {
        if (gameObject.tag == "Rock" && Vector3.Distance(transform.position, _player.transform.position) <= withinDistance)
        {
            miningSymbol.SetActive(true);
            //_fpc.StartCoroutine(Mine()); need to find way to reference this coroutine from FPC
            //Symbol should change? 
        }

        //must repeat if Statements based on which Object is being interacted with from ArrayList
    }
}
