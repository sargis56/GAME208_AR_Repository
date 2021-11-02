using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceObject : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Text txt;
    GameObject spawnedObject;
    ARRaycastManager arRaycastManager;
    Vector2 touchPosition;
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
        //Debug.Log("update");
        // Check to see if there was no Touch event on Screen

        if (!GetTouchPosition(out Vector2 touchPosition))
           // txt.text = "blah blah text";
            return;
        // Touch event occured
        if (arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            txt.text = "blah blah text";
            //Debug.Log("touched");
            Pose hitPose = hits[0].pose;
            if (spawnedObject == null)
                spawnedObject = Instantiate(objectToSpawn, hitPose.position,
                hitPose.rotation);
            else
                spawnedObject.transform.position = hitPose.position;
        }
    }
}
