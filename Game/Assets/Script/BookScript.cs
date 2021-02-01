using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookScript : MonoBehaviour
{
    public Sprite booksGround;
    bool hasClicked = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Interaction () {
        if (!hasClicked) {
            this.GetComponent<SpriteRenderer>().sprite = booksGround;
            this.GetComponent<BoxCollider>().enabled = false;
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 4f);
            hasClicked = true;
        }
    }
}
