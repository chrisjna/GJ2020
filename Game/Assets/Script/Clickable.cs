using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    [SerializeField]
    public Sprite nextFrame;
    
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() {
        if (Input.GetMouseButton(0)) {
            Debug.Log(this.gameObject.name);
        }
    }
}

