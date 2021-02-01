using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject endingPanel;
    [SerializeField] GameObject leftButton;
    [SerializeField] GameObject rightButton;
    private bool loseGame = false;
    private GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
        if(player == null)
        {
            Debug.LogError("attach a player btw");
        }

        if(endingPanel == null)
        {
            Debug.LogError("Attach the ending panel to the canvas field");
        }
        if (leftButton == null || rightButton == null)
        {
            Debug.LogError("No buttons found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (loseGame)
        {
            endingPanel.SetActive(true);
            player.SetActive(false);
            leftButton.SetActive(false);
            rightButton.SetActive(false);
        }
    }

    public void SetLoseStatus()
    {
        loseGame = true;
    }
}
