using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GoalScript : MonoBehaviour
{
    public GameObject canvas;
    private PlayerScript player;
    CharacterEvent characterEvent;
    public Stage stage = new Stage();
    private bool isMove;
    public bool canInteract;
    private AudioSource audioSource;
    [SerializeField] AudioClip winSoundClip;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
        characterEvent = GetComponent<CharacterEvent>();
        if(player == null)
        {
            Debug.LogError("Cant find the 'Player' object");
        }
        audioSource = GameObject.Find("AudioManager").GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("Couldnt detect and audio source");
        }

        canInteract = false;
    }

    // Update is called once per frame
    void Update()
    {
        isMove = player.CanInteract();
        if (!characterEvent.eventIsRunning) {
            this.GetComponent<BoxCollider>().enabled = true;
        }
        else {
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
    
    private void OnMouseDown() {
        if (!isMove)
        {
            if (Input.GetMouseButton(0))
            {
                // // Put unique event functions here (EX: Character climbign ladder)
                switch (stage) {
                    case (Stage.Stage1):
                        if (canInteract) {
                            characterEvent.PlayEvent(EventType.Reach, true);
                            EnableWinScreen();
                        }
                        else {
                            characterEvent.PlayEvent(EventType.Reach, false);
                        }
                        break;
                }
            }
        }
    }

    // Show win screen after completing stage
    void EnableWinScreen() {
        GameObject background = canvas.transform.GetChild(0).gameObject;
        GameObject winText = canvas.transform.GetChild(1).gameObject;

        background.SetActive(true);
        winText.SetActive(true);

        winText.GetComponent<RectTransform>().DOScale(new Vector3(1,1,0), 1.5f);
        audioSource.clip = winSoundClip;
        audioSource.Play();
        audioSource.volume = 0.05f;
    }

    // Check if the player is able to touch the goal
    void CheckInteraction() {
        if (canInteract) {
            this.GetComponent<BoxCollider>().enabled = true;
        }
        else {
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }

    IEnumerator Delay (float time) {
        yield return new WaitForSeconds(time);
        EnableWinScreen();
    }
}

public enum Stage {
    Stage1
}
