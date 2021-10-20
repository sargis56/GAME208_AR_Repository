using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public bool win;
    public bool lose;

    public GameObject winText;
    public GameObject loseText;

    public GameObject winSailor1;
    public GameObject winSailor2;
    public GameObject winSailor3;
    public GameObject loseSailor1;
    public GameObject loseSailor2;
    public GameObject loseSailor3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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

    }
}
