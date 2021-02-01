using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WinScreenScript : MonoBehaviour
{
    private GameObject background;
    private GameObject winText;
    void Start()
    {
        background = this.transform.GetChild(0).gameObject;
        winText = this.transform.GetChild(1).gameObject;

        //Debug.Log(background);

        background.SetActive(false);
        winText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
