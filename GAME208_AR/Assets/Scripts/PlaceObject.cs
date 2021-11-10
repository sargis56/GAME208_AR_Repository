using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceObject : MonoBehaviour
{
    //public GameObject objectToSpawn;
    private GameObject objectToSpawn;
    private int numShips = 5;

    public GameObject smallShip;
    public GameObject mediumShip;
    public GameObject mediumShip2;
    public GameObject battleshipShip;
    public GameObject destroyerShip;
    public GameObject pin;

    private GameObject spawnedObject;
    private ARRaycastManager arRaycastManager;
    private Vector2 touchPosition;

    public GameController GameControllerScript;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }
    bool GetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            //txt.text = "null";
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
       // txt.text = "zero";
        touchPosition = Vector2.zero;
        return false;
    }
   // void Start()
   // {
        
   // }
    // Update is called once per frame
    void Update()
    {
        if (numShips == 5)
        {
            objectToSpawn = smallShip;
        }

        if (numShips == 4)
        {
            objectToSpawn = mediumShip;
        }

        if (numShips == 3)
        {
            objectToSpawn = mediumShip2;
        }

        if (numShips == 2)
        {
            objectToSpawn = battleshipShip;
        }

        if (numShips == 1)
        {
            objectToSpawn = destroyerShip;
        }

        if (numShips <= 0)
        {
            GameControllerScript.placing = true;
            objectToSpawn = pin;
        }

        //Debug.Log("update");
        // Check to see if there was no Touch event on Screen

        if (!GetTouchPosition(out Vector2 touchPosition))
           // txt.text = "blah blah text";
            return;
        // Touch event occured
        if (arRaycastManager.Raycast(touchPosition, hits, TrackableType.All))
        {

            Pose hitPose = hits[0].pose;
            if (spawnedObject == null)
            {
                //spawnedObject = Instantiate(objectToSpawn, hitPose.position, hitPose.rotation);
                Instantiate(objectToSpawn, hitPose.position, hitPose.rotation);
                numShips -= 1;

                if ((GameControllerScript.oppenTurn == false) && (GameControllerScript.placing == true)) 
                {
                    GameControllerScript.oppenTurn = true;
                }
            }
            else
            {
                spawnedObject.transform.position = hitPose.position;
                //Instantiate(objectToSpawn, hitPose.position, hitPose.rotation);
            }
            
        }
    }
}
