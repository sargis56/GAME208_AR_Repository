using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public AIController AIControllerScript;

    public bool win;
    public bool lose;
    public bool oppenTurn;
    public bool oppenAngry;

    public bool placing;
    public bool firing;

    public GameObject shipPointer;
    public GameObject firePointer;

    public GameObject winText;
    public GameObject loseText;

    public GameObject winSailor1;
    public GameObject winSailor2;
    public GameObject winSailor3;
    public GameObject loseSailor1;
    public GameObject loseSailor2;
    public GameObject loseSailor3;
    public GameObject enemySailor;

    public GameObject smallShip;
    public GameObject mediumShip;
    public GameObject mediumShip2;
    public GameObject battleshipShip;
    public GameObject destroyerShip;

    private Rigidbody rb;

    public int numShips = 5;
    //player boat variables
    int playerBoat1Health = 4;
    int playerBoat2Health = 6;
    int playerBoat3Health = 6;
    int playerBoat4Health = 8;
    int playerBoat5Health = 10;
    //enemy boat variables
    int enemyBoat1Health = 4;
    int enemyBoat2Health = 6;
    int enemyBoat3Health = 6;
    int enemyBoat4Health = 8;
    int enemyBoat5Health = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void Awake()
    {
        
    }
    public void DamageCheckGameController(string shipName)
    {
        if (smallShip.name == shipName) //check which boat got collided with collision 
        {
            ApplyDamage(1);
        }
        else if (mediumShip.name == shipName)
        {
            ApplyDamage(2);
        }
        else if (mediumShip2.name == shipName)
        {
            ApplyDamage(3);
        }
        else if (battleshipShip.name == shipName)
        {
            ApplyDamage(4);
        }
        else if (destroyerShip.name == shipName)
        {
            ApplyDamage(5);
        }
    }
    public void ApplyDamage(int boatNumber) //players boats are 1-5 and the enemies boats are 6-10
    {
        if (boatNumber == 1)
        {
            playerBoat1Health--;
            Debug.Log("Collided " + playerBoat1Health);
        }
        if (boatNumber == 2)
        {
            playerBoat2Health--;
            Debug.Log("Collided " + playerBoat2Health);
        }
        if (boatNumber == 3)
        {
            playerBoat3Health--;
            Debug.Log("Collided " + playerBoat3Health);
        }
        if (boatNumber == 4)
        {
            playerBoat4Health--;
            Debug.Log("Collided " + playerBoat4Health);
        }
        if (boatNumber == 5)
        {
            playerBoat5Health--;
        }
        if (boatNumber == 6)
        {
            enemyBoat1Health--;
            Debug.Log("Collided " + enemyBoat1Health);
        }
        if (boatNumber == 7)
        {
            enemyBoat2Health--;
            Debug.Log("Collided " + enemyBoat2Health);
        }
        if (boatNumber == 8)
        {
            enemyBoat3Health--;
            Debug.Log("Collided " + enemyBoat3Health);
        }
        if (boatNumber == 9)
        {
            enemyBoat4Health--;
            Debug.Log("Collided " + enemyBoat4Health);
        }
        if (boatNumber == 10)
        {
            enemyBoat5Health--;
            Debug.Log("Collided " + enemyBoat5Health);
        }
    }
    void CheckWin()
    {
        if (enemyBoat1Health == 0 && enemyBoat2Health == 0 && enemyBoat3Health == 0 && enemyBoat4Health == 0 && enemyBoat5Health == 0)
        {
            win = true;
        }
        else if (playerBoat1Health == 0 && playerBoat2Health == 0 && playerBoat3Health == 0 && playerBoat4Health == 0 && playerBoat5Health == 0)
        {
            lose = true;
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        CheckWin();
        if (win == true)
        {
            winText.SetActive(true);
            winSailor1.SetActive(true);
            winSailor2.SetActive(true);
            winSailor3.SetActive(true);
        }
        else
        {
            winText.SetActive(false);
            winSailor1.SetActive(false);
            winSailor2.SetActive(false);
            winSailor3.SetActive(false);
        }

        if (lose == true)
        {
            loseText.SetActive(true);
            loseSailor1.SetActive(true);
            loseSailor2.SetActive(true);
            loseSailor3.SetActive(true);
        }
        else
        {
            loseText.SetActive(false);
            loseSailor1.SetActive(false);
            loseSailor2.SetActive(false);
            loseSailor3.SetActive(false);
        }

        if (oppenAngry == true)
        {
            enemySailor.SetActive(true);
        }
        else
        {
            enemySailor.SetActive(false);
        }

        if (numShips <= 0)
        {
            placing = false;
            firing = true;
        }

    }


    void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //rb.AddForce(movement);
    }



}

