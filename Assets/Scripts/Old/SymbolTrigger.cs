using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolTrigger : MonoBehaviour {
    private GameObject _player;
    private SymbolManagement _symbolManagement;
    public Node _node;

    public Camera cammy;

    public ParticleSystem startDrawing;

    public AudioSource soundBoard;
    public AudioClip noClicc;
    public AudioClip firstClicc;
    public AudioClip endClicc;
    public AudioClip puzzleFinish;
    public AudioClip roomFinish;

    public float lineStartWidth = 0.1f;
    public float lineEndWidth = 0.25f;

    public Color lineStartColor;
    public Color lineEndColor;

    public GameObject sphereLaser;
    public GameObject triLaser;

    public GameObject puzzle;
    public GameObject room;



    void Start () {
        _player = GameObject.FindGameObjectWithTag("Player"); //searches for Player
        _symbolManagement = _player.GetComponent<SymbolManagement>(); //inherits from SymbolManagement script 
        startDrawing.Stop(); //pauses particle system
        _node = GetComponent<Node>(); //inherits from Node class
        lineStartWidth = 0.1f; //sets initial startWidth of all symbols in the scene
        lineEndWidth = 0.25f; //sets initial endWidth of all symbols in the scene
        sphereLaser.SetActive(true);
        triLaser.SetActive(false);

    }

    void Update()
    {
        if (_symbolManagement.startLine == this.gameObject)
        {
            startDrawing.Emit(2); //particle system emits while symbol is selected
        }
    }

    void OnMouseEnter()
    {

        //detects symbol and changes cursor to triangle
        if (gameObject.tag == "Symbol" && _symbolManagement.startLine == null)
        {
            sphereLaser.SetActive(false);
            triLaser.SetActive(true);
            cammy.GetComponent<camMouseLook>().sensitivityX = 0.75f;
            cammy.GetComponent<camMouseLook>().sensitivityY = 0.75f;
        }

        //when drawing line, looks for compatible symbol and then changes cursor
        else if (gameObject.tag == "Symbol" && _symbolManagement.startLine != null && _symbolManagement.startLine.GetComponent<Node>().Sending.Contains(this.gameObject))
        {
            sphereLaser.SetActive(true);
            triLaser.SetActive(true);
            cammy.GetComponent<camMouseLook>().sensitivityX = 0.75f;
            cammy.GetComponent<camMouseLook>().sensitivityY = 0.75f;
        }
    }

    void OnMouseExit()
    {
        sphereLaser.SetActive(true);
        triLaser.SetActive(false);
        cammy.GetComponent<camMouseLook>().sensitivityX = 3f;
        cammy.GetComponent<camMouseLook>().sensitivityY = 3f;
    }

    void OnMouseDown() //function called when mouse is clicked
    {
        if (_symbolManagement.startLine == null && _node.Sending.Count > 0) //runs if there is no starting point currently assigned to line
        {
            _symbolManagement.startLine = gameObject; //assigns starting point of new line to center of game object which holds this script
            soundBoard.PlayOneShot(firstClicc);
        }
        else
        {
            //if starting point has already been assigned, determines whether new object/ending point has adjacency
            if (_symbolManagement.startLine.GetComponent<Node>().Sending.Contains(this.gameObject))
            {
                //symbol Clicked becomes end of line
                _symbolManagement.endLine = gameObject;

                //removes Adjacency
                _node.Receiving.Remove(_symbolManagement.startLine.gameObject);
                _node.Sending.Remove(_symbolManagement.startLine.gameObject);
                _symbolManagement.startLine.GetComponent<Node>().Sending.Remove(this.gameObject);
                _symbolManagement.startLine.GetComponent<Node>().Receiving.Remove(this.gameObject);

                //removes StartLine Symbol from Room and Puzzle if no longer has adjacency
                if (_symbolManagement.startLine.GetComponent<Node>().Sending.Count == 0 && _symbolManagement.startLine.GetComponent<Node>().Receiving.Count == 0)
                {
                    puzzle.GetComponent<Node>().Puzzle.Remove(_symbolManagement.startLine.gameObject);
                    room.GetComponent<Node>().Room.Remove(_symbolManagement.startLine.gameObject);
                    _symbolManagement.startLine.gameObject.tag = "Puzzle";
                }

                //removes end Line symbol from Room and Puzzle if no longer has adjacency
                if (_node.Receiving.Count == 0 && _node.Sending.Count == 0)
                {
                    puzzle.GetComponent<Node>().Puzzle.Remove(this.gameObject);
                    room.GetComponent<Node>().Room.Remove(this.gameObject);
                    gameObject.tag = "Puzzle";
                }

                //Sound management and puzzle / room clearance
                if (puzzle.GetComponent<Node>().Puzzle.Count == 0) //checks if Puzzle node has any remaining symbols
                {
                    soundBoard.PlayOneShot(puzzleFinish);
                }
                if (room.GetComponent<Node>().Room.Count == 0) //checks if Room node has any remaining symbols
                {
                    soundBoard.PlayOneShot(roomFinish);
                    room.GetComponent<Node>().MoveDoors(); 
                    //spawns modeled objects???
                }
                else
                {
                    soundBoard.PlayOneShot(endClicc);
                }
                //draws the actual line
                _symbolManagement.drawLine(_symbolManagement.startLine.transform.position, _symbolManagement.endLine.transform.position, lineStartColor, lineEndColor, lineStartWidth, lineEndWidth);
              
            }
            //lets player know that they cannot draw line to this object
            else
            {
                soundBoard.PlayOneShot(noClicc); //plays sound
                _symbolManagement.startLine = null; //resets start line if mistake
                Debug.LogError("u fuckin idiot");
            }
        }
    }
    
}
