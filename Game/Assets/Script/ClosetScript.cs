using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetScript : MonoBehaviour
{
    BoxCollider boxCollider;
    GameObject stepLadder;

    // Sprites for open and close
    public Sprite closetOpen, closetClosed;
    // Flag to check closet state
    public bool isOpen;
    private AudioSource audioSource;
    [SerializeField] AudioClip closetSoundClip;

    void Start()
    {
        audioSource = GameObject.Find("AudioManager").GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("Couldnt detect and audio source");
        }
        boxCollider = this.GetComponent<BoxCollider>();
        // Set Default state
        isOpen = false;
    }

    void Update() {}

    // Changes sprite and sorting order depending on state
    void Interaction () {
        if (isOpen) {
            this.GetComponent<SpriteRenderer>().sprite = closetClosed;
            this.GetComponent<BoxCollider>().size = new Vector3(boxCollider.size.x, boxCollider.size.y, 10);
            this.GetComponent<SpriteRenderer>().sortingOrder = 100;
            isOpen = false;
            audioSource.clip = closetSoundClip;
            audioSource.Play();
        }
        else {
            this.GetComponent<SpriteRenderer>().sprite = closetOpen;
            this.GetComponent<BoxCollider>().size = new Vector3(boxCollider.size.x, boxCollider.size.y, 1);
            this.GetComponent<SpriteRenderer>().sortingOrder = 0;
            isOpen = true;
            audioSource.clip = closetSoundClip;
            audioSource.Play();
        }
    }
}
