using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public GameController GameControlleScript;
    private bool previousHits = false;
    public GameObject firePointer;
    bool[] boardArrayX = new bool[10];
    bool[] boardArrayY = new bool[10];
        void Awake()
        {
            for (int x = 0; x < 10; x++)
           {
               for (int y = 0; y < 10; y++)
               {
                    boardArrayX[x] = false;
                    boardArrayX[y] = false;
                }
            }
       }
    // Start is called before the first frame update
    void Start()
    {
        // GameControllerRef = GameObject.Find("GameController");
        //GameControlleScript = GameControllerRef.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameControlleScript.oppenTurn == true)
        {
            firePointer.transform.position = new Vector3(22, firePointer.transform.position.y, -22);
            if (previousHits == false)
            {
                bool previousPos = true;
                int randX = Random.Range(0, 9);
                int randY = Random.Range(0, 9);
                while (previousPos == true)
                {
                    Debug.Log("Hello: " + randX);
                    if (boardArrayX[randX] == false && boardArrayY[randY] == false)
                    {
                        boardArrayX[randX] = true;
                        boardArrayY[randY] = true;
                        previousPos = false;
                        firePointer.transform.position = new Vector3(firePointer.transform.position.x + (randX * -5.5f), firePointer.transform.position.y, firePointer.transform.position.z + (randY * 5.5f));
                        Instantiate(firePointer, firePointer.transform.position, firePointer.transform.rotation);
                        GameControlleScript.oppenTurn = false;
                   }
                }
            }
        }
    }
}
