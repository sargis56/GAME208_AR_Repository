using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollsionDetect : MonoBehaviour
{
    public GameController GameControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyPin")
        {
            Debug.Log("Colided");
            GameControllerScript.lose = true;
        }
    }
}
