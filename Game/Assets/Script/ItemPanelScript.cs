using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPanelScript : MonoBehaviour
{
    // List of item types
    public ItemType itemType = new ItemType();
    void Start() {
    }

    void Update() { 
    }
}

// Enum for item types
// Can be used for custom item events
public enum ItemType {
    Default,
    StepLadder
}