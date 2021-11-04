using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public bool AIToggle = true;
    public GameController GameControllerScript;
    public GameObject firePointer;

   // public GameObject boatCollision1;
    public GameObject boatCollision2;
    public GameObject boatCollision3;
   // public GameObject boatCollision4;
    //public GameObject boatCollision5;

    public float spaceSize;
    public bool[,] boardArray;
    public bool[,] AIPlacementArray;
    int lastHitX, lastHitZ, originalHitX, originalHitZ;
        void Awake()
        {
            boardArray = new bool[11, 11]; //create boardArrays used for checking if a position is full
            AIPlacementArray = new bool[11, 11];
            for (int x = 0; x < 11; x++)
                   {
                       for (int y = 0; y < 11; y++)
                       {
                            boardArray[x,y] = false;
                            AIPlacementArray[x,y] = false;
                    }
                }
           }
    // Start is called before the first frame update
    void Start()
    {
        firePointer.SetActive(false);
        //GameControllerRef = GameObject.Find("GameController");
        //GameControlleScript = GameControllerRef.GetComponent<GameController>();
        int randX, randZ, rotation;
        //boat 1
        randX = Random.Range(0, 7); //generate random pos for boat 2
        randZ = Random.Range(0, 7);
        rotation = Random.Range(0, 1);
        if (AIPlacementArray[randX, randZ] == false && AIPlacementArray[randX + 1, randZ] == false && AIPlacementArray[randX + 2, randZ] == false)
        {
            boatCollision2.transform.position = new Vector3(boatCollision2.transform.position.x + (randX * -spaceSize), boatCollision2.transform.position.y - (randZ * spaceSize), boatCollision2.transform.position.z);
            AIPlacementArray[randX, randZ] = true;
            AIPlacementArray[randX + 1, randZ] = true;
            AIPlacementArray[randX + 2, randZ] = true;
        }
        randX = Random.Range(0, 7); //generate random pos for boat 3
        randZ = Random.Range(0, 7);
        rotation = Random.Range(0, 1);
        if (AIPlacementArray[randX, randZ] == false && AIPlacementArray[randX + 1, randZ] == false && AIPlacementArray[randX + 2, randZ] == false)
        {
            boatCollision3.transform.position = new Vector3(boatCollision3.transform.position.x + (randX * -spaceSize), boatCollision3.transform.position.y - (randZ * spaceSize), boatCollision3.transform.position.z);
            AIPlacementArray[randX, randZ] = true;
            AIPlacementArray[randX + 1, randZ] = true;
            AIPlacementArray[randX + 2, randZ] = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (AIToggle == true)
        {
            if (GameControllerScript.oppenTurn == true) //if the players move is over
            {
                firePointer.SetActive(true);
                firePointer.transform.position = new Vector3(22, firePointer.transform.position.y, -22); //reset firePointer position
                    int randX = Random.Range(0, 10); //generate random pos on the board
                    int randZ = Random.Range(0, 10);
                    if (boardArray[randX, randZ] == false) //if the AI has not shot there yet
                    {
                        boardArray[randX, randZ] = true; //position is now hit
                        firePointer.transform.position = new Vector3(firePointer.transform.position.x + (randX * -spaceSize), firePointer.transform.position.y, firePointer.transform.position.z + (randZ * spaceSize)); //place the pin in the spot
                        Instantiate(firePointer, firePointer.transform.position, firePointer.transform.rotation); //create the pin
                        GameControllerScript.oppenTurn = false; //AI's turn is over
                    } //i have more code by Sargis wanted to go a different direction so I ended up deleteing way more than half of it
            }
        }
    }
}
