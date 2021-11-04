using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public bool AIToggle = true;
    public GameController GameControllerScript;
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
        firePointer.SetActive(false);
        // GameControllerRef = GameObject.Find("GameController");
        //GameControlleScript = GameControllerRef.GetComponent<GameController>();
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
                        firePointer.transform.position = new Vector3(firePointer.transform.position.x + (randX * -5.5f), firePointer.transform.position.y, firePointer.transform.position.z + (randZ * 5.5f)); //place the pin in the spot
                        Instantiate(firePointer, firePointer.transform.position, firePointer.transform.rotation); //create the pin
                        GameControllerScript.oppenTurn = false; //AI's turn is over
                    } //i have more code by Sargis wanted to go a different direction so I ended up deleteing way more than half of it
            }
        }
    }
}
