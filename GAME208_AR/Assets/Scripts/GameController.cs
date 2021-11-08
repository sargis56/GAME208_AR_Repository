using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public AIController AIControllerScript;

    public bool win;
    public bool lose;
    public bool oppenTurn;

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

    private Rigidbody rb;
    private bool rotateShip;
    private bool selectSmallShip;
    private bool selectMediumShip;
    private GameObject selectedShip;

    private int numShips = 5;
    //boat variables
    int enemyBoat1Health = 4;
    int enemyBoat2Health = 6;
    int enemyBoat3Health = 6;

    private void Awake()
    {
    
    }
    public void ApplyDamage(int boatNumber) //players boats are 1-5 and the enemies boats are 6-10
    {
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
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (enemyBoat1Health <= 0 && enemyBoat2Health <= 0 && enemyBoat3Health <= 0)
        {
            win = true;
        }
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

        if (oppenTurn == true)
        {
            enemySailor.SetActive(true);
        }
        else
        {
            enemySailor.SetActive(false);
        }

        if (placing == true)
        {
            shipPointer.SetActive(true);
        }
        else
        {
            shipPointer.SetActive(false);
        }

        if (firing == true)
        {
            firePointer.SetActive(true);
        }
        else
        {
            firePointer.SetActive(false);
        }

        if (Input.GetKeyDown("space"))
        {

            if (firing == true && oppenTurn == false)
            {
                firePointer.tag = "FirePin"; //make the firePointer active
                Instantiate(firePointer, firePointer.transform.position, firePointer.transform.rotation); //place the pointer
                firePointer.tag = "DudFirePin"; //make the pointer a dud for the next use - this is done so when choosing a place to put the pointer is not colliding with the boats
                oppenTurn = true;
            }

            if (placing == true)
            {
                if (rotateShip == true)
                {
                    Instantiate(selectedShip, shipPointer.transform.position = new Vector3(shipPointer.transform.position.x + 2.25f, shipPointer.transform.position.y, shipPointer.transform.position.z), selectedShip.transform.rotation = Quaternion.Euler(Vector3.up * 90));
                    shipPointer.transform.position = new Vector3(shipPointer.transform.position.x - 2.25f, shipPointer.transform.position.y, shipPointer.transform.position.z);
                }
                else
                {
                    Instantiate(selectedShip, shipPointer.transform.position, selectedShip.transform.rotation = new Quaternion(0, 0, 0, 0));
                }
                numShips -= 1;
            }
        }

        if (Input.GetKeyDown("q"))
        {
            if (rotateShip == true)
            {
                rotateShip = false;
            }
            else
            {
                rotateShip = true;
            }
        }

        if (rotateShip == true)
        {
            smallShip.transform.rotation = Quaternion.Euler(Vector3.up * 90);
            mediumShip.transform.rotation = Quaternion.Euler(Vector3.up * 90);
        }
        else
        {
            smallShip.transform.rotation = new Quaternion(0, 0, 0, 0);
            mediumShip.transform.rotation = new Quaternion(0, 0, 0, 0);
        }

        if (Input.GetKeyDown("1"))
        {
            if (selectSmallShip == true)
            {
                selectSmallShip = false;
            }
            else
            {
                selectSmallShip = true;
            }
            
        }

        if (selectSmallShip == true)
        {
            smallShip.SetActive(true);
            mediumShip.SetActive(false);
            selectMediumShip = false;
            selectedShip = smallShip;
        }
        else
        {
            smallShip.SetActive(false);
        }

        if (Input.GetKeyDown("2"))
        {
            if (selectMediumShip == true)
            {
                selectMediumShip = false;
            }
            else
            {
                selectMediumShip = true;
            }

        }

        if (selectMediumShip == true)
        {
            mediumShip.SetActive(true);
            smallShip.SetActive(false);
            selectSmallShip = false;
            selectedShip = mediumShip;
        }
        else
        {
            mediumShip.SetActive(false);
        }

        if (Input.GetKeyDown("w"))
        {
            if (placing == true)
            {
                shipPointer.transform.position = new Vector3(shipPointer.transform.position.x, shipPointer.transform.position.y, shipPointer.transform.position.z - 5.5f);
            }
            if (firing == true)
            {
                firePointer.transform.position = new Vector3(firePointer.transform.position.x, firePointer.transform.position.y + 5.5f, firePointer.transform.position.z);
            }
        }
        if (Input.GetKeyDown("s"))
        {
            if (placing == true)
            {
                shipPointer.transform.position = new Vector3(shipPointer.transform.position.x, shipPointer.transform.position.y, shipPointer.transform.position.z + 5.5f);
            }
            if (firing == true)
            {
                firePointer.transform.position = new Vector3(firePointer.transform.position.x, firePointer.transform.position.y - 5.5f, firePointer.transform.position.z);
            }
        }
        if (Input.GetKeyDown("a"))
        {
            if (placing == true)
            {
                shipPointer.transform.position = new Vector3(shipPointer.transform.position.x + 5.5f, shipPointer.transform.position.y, shipPointer.transform.position.z);
            }
            if (firing == true)
            {
                firePointer.transform.position = new Vector3(firePointer.transform.position.x + 5.5f, firePointer.transform.position.y, firePointer.transform.position.z);
            }
        }
        if (Input.GetKeyDown("d"))
        {
            if (placing == true)
            {
                shipPointer.transform.position = new Vector3(shipPointer.transform.position.x - 5.5f, shipPointer.transform.position.y, shipPointer.transform.position.z);
            }
            if (firing == true)
            {
                firePointer.transform.position = new Vector3(firePointer.transform.position.x - 5.5f, firePointer.transform.position.y, firePointer.transform.position.z);
            }
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

