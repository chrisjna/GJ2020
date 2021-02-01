using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableItem : MonoBehaviour
{
    // List of item types
    public ItemType itemType = new ItemType();

    // Check if item is being held by the mouse
    bool isHeld = false;
    // Check if the item is hovering over the item panel
    public bool isHovering = false;
    // Check if the item has been placed down on the item panel
    public bool isPlaced = false;
    // Check if this item is the final item needed to complete the stage
    public bool isFinalItem = false;
    GameObject goal;
    // The previous parent in the inventory 
    public Transform prevParent;

    // Reference to the Player object
    GameObject player;
    // Reference to the item panel object
    Transform itemPanel;


    void Start()
    {
        // Find the player object
        player = GameObject.Find("Player");
        goal = GameObject.Find("Goal");
    }

    // Update is called once per frame
    void Update()
    {
        // Run this only if the item has not been placed in the correct spot
        if (this.gameObject.tag == "Draggable" && !isPlaced) {  
            if (isHeld) {
                Vector2 mousePos;
                this.gameObject.transform.parent = null;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                this.gameObject.transform.localPosition = new Vector2(mousePos.x, mousePos.y);
            }
            else {
                this.transform.parent = prevParent;
                this.transform.position = prevParent.position;
            }
        }
    }

    private void OnMouseDown() {
        if (!isPlaced) {
            if (Input.GetMouseButtonDown(0) && this.gameObject.tag == "Draggable") {
                print(this.transform.parent.name);
                isHeld = true;
            }
        }
    }

    private void OnMouseUp() {
        // Check if item being held is over the item panel
        if (isHovering) {
            // Both the item and the item panel must be the same item type
            if (this.itemType == itemPanel.gameObject.GetComponent<ItemPanelScript>().itemType) {
                this.transform.position = itemPanel.position;
                player.GetComponent<PlayerScript>().itemList.Remove(this.gameObject);
                isPlaced = true;
                if (isFinalItem) {
                    goal.GetComponent<GoalScript>().canInteract = true;
                }
            }
        }
        isHeld = false;
    }

    // Saves the previous parent and position
    void GetParentTransform () {
        print("asdasd");
        prevParent = this.transform.parent;
    }

    // Detect whether the itempanel and inventory item overlap
    private void OnTriggerEnter(Collider other) {
        // this.GetComponent<BoxCollider>().bounds.Intersects(other.gameObject.GetComponent<BoxCollider>().bounds)
        if (other.gameObject.tag == "Panel") {
            isHovering = true;
            itemPanel = other.transform;
        }
    }
}
