using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public bool AIToggle = true;
    public GameController GameControllerScript;
    public GameObject firePointer;

    public GameObject boatCollision1;
    public GameObject boatCollision2;
    public GameObject boatCollision3;
    public GameObject boatCollision4;
    public GameObject boatCollision5;

    public float spaceSizeFireBoard;
    public float spaceSizePlaceBoard;
    public bool[,] boardArray;
    public bool[,] AIPlacementArray;

    Vector3 firePointerOriginalPos;
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
        firePointerOriginalPos = firePointer.transform.position;
        //GameControllerRef = GameObject.Find("GameController");
        //GameControlleScript = GameControllerRef.GetComponent<GameController>();
        int randX, randZ;
        //boat 1
        randX = Random.Range(0, 9); //generate random pos for boat 1
        randZ = Random.Range(1, 9);
        //Debug.Log("X " + randX + " Z " + randZ);
        if (AIPlacementArray[randX, randZ] == false || AIPlacementArray[randX, randZ - 1] == false)
        {
            boatCollision1.transform.position = new Vector3(boatCollision1.transform.position.x + (randX * spaceSizeFireBoard), boatCollision1.transform.position.y - (randZ * spaceSizeFireBoard), boatCollision1.transform.position.z);
            AIPlacementArray[randX, randZ] = true;
            AIPlacementArray[randX, randZ - 1] = true;
        }
        //boat 2
        randX = Random.Range(2, 7); //generate random pos for boat 2
        randZ = Random.Range(0, 9);
        //Debug.Log("X " + randX + " Z " + randZ);
        if (AIPlacementArray[randX, randZ] == false || AIPlacementArray[randX - 1, randZ] == false || AIPlacementArray[randX - 2, randZ] == false)
        {
            boatCollision2.transform.position = new Vector3(boatCollision2.transform.position.x + (randX * spaceSizeFireBoard), boatCollision2.transform.position.y - (randZ * spaceSizeFireBoard), boatCollision2.transform.position.z);
            AIPlacementArray[randX, randZ] = true;
            AIPlacementArray[randX - 1, randZ] = true;
            AIPlacementArray[randX - 2, randZ] = true;
        }
        else
        { //attempt 2 for boat 2
            randX = Random.Range(2, 7); //generate random pos for boat 2
            randZ = Random.Range(0, 9);
            //Debug.Log("X " + randX + " Z " + randZ);
            if (AIPlacementArray[randX, randZ] == false || AIPlacementArray[randX - 1, randZ] == false || AIPlacementArray[randX - 2, randZ] == false)
            {
                boatCollision2.transform.position = new Vector3(boatCollision2.transform.position.x + (randX * spaceSizeFireBoard), boatCollision2.transform.position.y - (randZ * spaceSizeFireBoard), boatCollision2.transform.position.z);
                AIPlacementArray[randX, randZ] = true;
                AIPlacementArray[randX - 1, randZ] = true;
                AIPlacementArray[randX - 2, randZ] = true;
            }
        }
        //boat 3
        randX = Random.Range(0, 9); //generate random pos for boat 3
        randZ = Random.Range(2, 7);
        //Debug.Log("X " + randX + " Z " + randZ);
        if (AIPlacementArray[randX, randZ] == false || AIPlacementArray[randX, randZ - 1] == false || AIPlacementArray[randX, randZ - 2] == false)
        {
            boatCollision3.transform.position = new Vector3(boatCollision3.transform.position.x + (randX * spaceSizeFireBoard), boatCollision3.transform.position.y - (randZ * spaceSizeFireBoard), boatCollision3.transform.position.z);
            AIPlacementArray[randX, randZ] = true;
            AIPlacementArray[randX, randZ - 1] = true;
            AIPlacementArray[randX, randZ - 2] = true;
        }
        else
        { //attempt 2 for boat 3
            randX = Random.Range(0, 9); //generate random pos for boat 3
            randZ = Random.Range(2, 6);
            //Debug.Log("X " + randX + " Z " + randZ);
            if (AIPlacementArray[randX, randZ] == false || AIPlacementArray[randX, randZ - 1] == false || AIPlacementArray[randX, randZ - 2] == false)
            {
                boatCollision3.transform.position = new Vector3(boatCollision3.transform.position.x + (randX * spaceSizeFireBoard), boatCollision3.transform.position.y - (randZ * spaceSizeFireBoard), boatCollision3.transform.position.z);
                AIPlacementArray[randX, randZ] = true;
                AIPlacementArray[randX, randZ - 1] = true;
                AIPlacementArray[randX, randZ - 2] = true;
            }
        }
        //boat 4
        randX = Random.Range(3, 7); //generate random pos for boat 4
        randZ = Random.Range(0, 10);
        //Debug.Log("X " + randX + " Z " + randZ);
        if (AIPlacementArray[randX, randZ] == false || AIPlacementArray[randX - 1, randZ] == false || AIPlacementArray[randX - 2, randZ] == false || AIPlacementArray[randX - 3, randZ] == false)
        {
            boatCollision4.transform.position = new Vector3(boatCollision4.transform.position.x + (randX * spaceSizeFireBoard), boatCollision4.transform.position.y - (randZ * spaceSizeFireBoard), boatCollision4.transform.position.z);
            AIPlacementArray[randX, randZ] = true;
            AIPlacementArray[randX - 1, randZ] = true;
            AIPlacementArray[randX - 2, randZ] = true;
            AIPlacementArray[randX - 3, randZ] = true;
        }
        else
        {//attempt 2 for boat 4
            randX = Random.Range(3, 7); //generate random pos for boat 4
            randZ = Random.Range(0, 9);
            //Debug.Log("X " + randX + " Z " + randZ);
            if (AIPlacementArray[randX, randZ] == false || AIPlacementArray[randX - 1, randZ] == false || AIPlacementArray[randX - 2, randZ] == false || AIPlacementArray[randX - 3, randZ] == false)
            {
                boatCollision4.transform.position = new Vector3(boatCollision4.transform.position.x + (randX * spaceSizeFireBoard), boatCollision4.transform.position.y - (randZ * spaceSizeFireBoard), boatCollision4.transform.position.z);
                AIPlacementArray[randX, randZ] = true;
                AIPlacementArray[randX - 1, randZ] = true;
                AIPlacementArray[randX - 2, randZ] = true;
                AIPlacementArray[randX - 3, randZ] = true;
            }
        }
        //boat 5
        randX = Random.Range(0, 9); //generate random pos for boat 5
        randZ = Random.Range(4, 7);
        //Debug.Log("X " + randX + " Z " + randZ);
        if (AIPlacementArray[randX, randZ] == false || AIPlacementArray[randX, randZ - 1] == false || AIPlacementArray[randX, randZ - 2] == false || AIPlacementArray[randX, randZ - 3] == false || AIPlacementArray[randX, randZ - 4] == false)
        {
            boatCollision5.transform.position = new Vector3(boatCollision5.transform.position.x + (randX * spaceSizeFireBoard), boatCollision5.transform.position.y - (randZ * spaceSizeFireBoard), boatCollision5.transform.position.z);
            AIPlacementArray[randX, randZ] = true;
            AIPlacementArray[randX, randZ - 1] = true;
            AIPlacementArray[randX, randZ - 2] = true;
            AIPlacementArray[randX, randZ - 3] = true;
            AIPlacementArray[randX, randZ - 4] = true;
        }
        else
        { //attempt 2 for boat 5
            randX = Random.Range(0, 9); //generate random pos for boat 5
            randZ = Random.Range(4, 7);
            //Debug.Log("X " + randX + " Z " + randZ);
            if (AIPlacementArray[randX, randZ] == false || AIPlacementArray[randX, randZ - 1] == false || AIPlacementArray[randX, randZ - 2] == false || AIPlacementArray[randX, randZ - 3] == false || AIPlacementArray[randX, randZ - 4] == false)
            {
                boatCollision5.transform.position = new Vector3(boatCollision5.transform.position.x + (randX * spaceSizeFireBoard), boatCollision5.transform.position.y - (randZ * spaceSizeFireBoard), boatCollision5.transform.position.z);
                AIPlacementArray[randX, randZ] = true;
                AIPlacementArray[randX, randZ - 1] = true;
                AIPlacementArray[randX, randZ - 2] = true;
                AIPlacementArray[randX, randZ - 3] = true;
                AIPlacementArray[randX, randZ - 4] = true;
            }
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
                firePointer.transform.position = firePointerOriginalPos; //reset firePointer position
                    int randX = Random.Range(0, 10); //generate random pos on the board
                    int randZ = Random.Range(0, 10);
                    if (boardArray[randX, randZ] == false) //if the AI has not shot there yet
                    {
                        boardArray[randX, randZ] = true; //position is now hit
                        firePointer.transform.position = new Vector3(firePointer.transform.position.x + (randX * spaceSizePlaceBoard), firePointer.transform.position.y, firePointer.transform.position.z + (randZ * -spaceSizePlaceBoard)); //place the pin in the spot
                        Instantiate(firePointer, firePointer.transform.position, firePointer.transform.rotation); //create the pin
                        GameControllerScript.oppenTurn = false; //AI's turn is over
                    } //i have more code by Sargis wanted to go a different direction so I ended up deleteing way more than half of it
            }
        }
    }
    public void DamageCheckAIController(string shipName)
    {
        if (boatCollision1.name == shipName) //check which boat got collided with collision 
        {
            GameControllerScript.ApplyDamage(6);
        }
        else if (boatCollision2.name == shipName)
        {
            GameControllerScript.ApplyDamage(7);
        }
        else if (boatCollision3.name == shipName)
        {
            GameControllerScript.ApplyDamage(8);
        }
        else if (boatCollision4.name == shipName)
        {
            GameControllerScript.ApplyDamage(9);
        }
        else if (boatCollision5.name == shipName)
        {
            GameControllerScript.ApplyDamage(10);
        }
    }
}
