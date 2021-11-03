using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public GameController GameControllerScript;
    private bool previousHit = false;
    public GameObject firePointer;
    public bool[,] boardArray;
    int lastHitX, lastHitZ, originalHitX, originalHitZ;
        void Awake()
        {
        boardArray = new bool[11, 11]; //create boardArrays used for checking if a position is full
            for (int x = 0; x < 11; x++)
           {
               for (int y = 0; y < 11; y++)
               {
                    boardArray[x,y] = false;
                }
            }
       }
    // Start is called before the first frame update
    void Start()
    {
        // GameControllerRef = GameObject.Find("GameController");
        //GameControlleScript = GameControllerRef.GetComponent<GameController>();
    }

    public void ResetPreviousHit()
    {
        previousHit = false; //reset previousHit
    }

    // Update is called once per frame
    void Update()
    {
        if (GameControllerScript.oppenTurn == true) //if the players move is over
        {
            firePointer.transform.position = new Vector3(22, firePointer.transform.position.y, -22); //reset firePointer position
            if (previousHit == false) //if the AI didnt hit a ship previously
            {
                int randX = Random.Range(0, 10); //generate random pos on the board
                int randZ = Random.Range(0, 10);
                if (boardArray[randX, randZ] == false) //if the AI has not shot there yet
                {
                    boardArray[randX, randZ] = true; //position is now hit
                    firePointer.transform.position = new Vector3(firePointer.transform.position.x + (randX * -5.5f), firePointer.transform.position.y, firePointer.transform.position.z + (randZ * 5.5f)); //place the pin in the spot
                    Instantiate(firePointer, firePointer.transform.position, firePointer.transform.rotation); //create the pin
                    GameControllerScript.oppenTurn = false; //AI's turn is over
                    if (GameControllerScript.CheckHitEnemy(randX, randZ) == true) //check if the AI hit a ship
                    {
                        Debug.Log("SPOT HIT " + randX + " " + randZ);
                        lastHitX = randX; //set lastHit to location hit
                        lastHitZ = randZ;
                        originalHitX = randX; //set original pos just in case the AI takes a weird path down the ship like if it hits the middle and it follows down and gets stuck at the end because of the + (line 64)
                        originalHitZ = randZ;
                        previousHit = true; //set that the AI hit a ship
                    }
                }
            }
            else
            {                                                                                                              //        | +2z
                int spotX = Random.Range((lastHitX - 1), (lastHitX + 2)); //generate a location close to the hit in a + shape  -1x --|-- +2x
                int spotZ = Random.Range((lastHitZ - 1), (lastHitZ + 2));                                                  //        | -1z
                if (boardArray[spotX, spotZ] == false) //if the spot is empty
                {
                    boardArray[spotX, spotZ] = true; //make it full
                    firePointer.transform.position = new Vector3(firePointer.transform.position.x + (spotX * -5.5f), firePointer.transform.position.y, firePointer.transform.position.z + (spotZ * 5.5f)); //place the pin in the spot
                    Instantiate(firePointer, firePointer.transform.position, firePointer.transform.rotation);
                    GameControllerScript.oppenTurn = false; //AI's turn is over
                    if (GameControllerScript.CheckHitEnemy(spotX, spotZ) == true) //check if the AI hit a ship
                    {
                        Debug.Log("SPOT HIT " + spotX + " " + spotZ);
                        lastHitX = spotX; //set lastHit to location hit
                        lastHitZ = spotZ;
                    }
                }
                else if (boardArray[lastHitX - 1, lastHitZ - 1] == true && boardArray[lastHitX + 1, lastHitZ - 1] == true && boardArray[lastHitX - 1, lastHitZ + 1] == true && boardArray[lastHitX + 1, lastHitZ + 1] == true) //if all positions around the last hit are full
                {
                    Debug.Log("RIPPPPP");
                    lastHitX = originalHitX;
                    lastHitZ = originalHitZ;
                    if (boardArray[originalHitX - 1, originalHitZ - 1] == true && boardArray[originalHitX + 1, originalHitZ - 1] == true && boardArray[originalHitX - 1, originalHitZ + 1] == true && boardArray[originalHitX + 1, originalHitZ + 1] == true)
                    { //last fail safe to reset the AI
                        previousHit = false;
                    }
                }
            }
        }
    }
}
