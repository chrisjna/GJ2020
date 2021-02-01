using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private PlayerScript player;
    public Sprite body;
    private bool isMove;
    private CanvasManager canvas;
    private AudioSource audioSource;
    [SerializeField] AudioClip enemySoundClip;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
        if (player == null)
        {
            Debug.LogError("Cant find the 'Player' object");
        }

        canvas = GameObject.Find("Canvas").GetComponent<CanvasManager>();
        if (player == null)
        {
            Debug.LogError("Cant find the 'Canvas' object");
        }

        audioSource = GameObject.Find("AudioManager").GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("Couldnt detect and audio source");
        }
    }

    // Update is called once per frame
    void Update()
    {
        isMove = player.CanInteract();
    }

    private void OnMouseDown() {
        if (!isMove)
        {
            if (Input.GetMouseButton(0))
            {
                this.GetComponent<SpriteRenderer>().sortingOrder = 1;
                this.GetComponent<SpriteRenderer>().sprite = body;
                this.transform.rotation = Quaternion.identity;
                canvas.SetLoseStatus();
                Debug.Log("Lose");
                audioSource.clip = enemySoundClip;
                audioSource.Play();
                this.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}