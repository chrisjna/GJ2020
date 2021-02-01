using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterEvent : MonoBehaviour
{
    public EventType eventType = new EventType();
    public GameObject character;

    public Sprite spriteReach;
    public bool eventIsRunning = false;
    GameObject eventChar;
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    public void PlayEvent (EventType eventType, bool success) {
        switch (eventType) {
            case (EventType.Reach):
                if (eventIsRunning) {
                    StopAllCoroutines();
                    foreach (Transform child in this.transform) {
                        GameObject.Destroy(child.gameObject);
                    }
                }
                else {
                    StartCoroutine("PlayReachEvent", success);
                }
                break;
            default:
                break;
        }
    }

    IEnumerator PlayReachEvent (bool success) {
        eventIsRunning = true;
        eventChar = Instantiate(character, this.transform);
        eventChar.GetComponent<SpriteRenderer>().sprite = spriteReach;
        eventChar.transform.localScale = new Vector3(1.1f, 1.1f, 0);
        if (success) {
            eventChar.transform.position = new Vector2 (this.transform.position.x,this.transform.position.y - eventChar.GetComponent<SpriteRenderer>().bounds.size.y/1.5f);
            float destination = (this.transform.position.y - eventChar.GetComponent<SpriteRenderer>().bounds.size.y/2);
            Tween reachTween = eventChar.transform.DOMoveY(destination, 1f, false);
            yield return reachTween.WaitForCompletion();
            Destroy(eventChar);
            eventIsRunning = false;
        }
        else {
            eventChar.transform.position = new Vector2 (this.transform.position.x, this.transform.position.y - 5);
            Vector3 destination = new Vector3(this.transform.position.x, this.transform.position.y - 5, 0);
            Tween reachTween = eventChar.transform.DOJump(destination, 1, 1, 1, false);
            yield return reachTween.WaitForCompletion();
            Destroy(eventChar);
            eventIsRunning = false;
        }
    }
}

public enum EventType {
    Reach
}