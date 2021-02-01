using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class PlayerScript : MonoBehaviour
{
    // Flag to check if player can move
    public bool canMove;
    //Flag to make item draggable
    private bool changeDraggable;
    // Current position in scene (starts at 1)
    private float currentPosition;
    // Number of screens in scene (MUST BE SET IN INSPECTOR)
    public int numScreens;
    // Current screen number (default 1)
    public int currentScreen = 1;
    // The distance the camera will travel when moving
    private float cameraTravelSize;
    public Vector2 inventoryPos;
    // Use both to time out the interactions while the camera moves
    private bool isMoving = false;
    private float timer = 0;

    // Object references
    public GameObject rightButton;
    public GameObject leftButton;
    public GameObject inventorySpace;
    public List<GameObject> itemList = new List<GameObject>();
    void Start()
    {
        cameraTravelSize = Camera.main.orthographicSize * 3;
        canMove = true;
        currentPosition = SetCameraX();
        Camera.main.transform.position = new Vector3(currentPosition, Camera.main.transform.position.y, Camera.main.transform.position.z);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isMoving)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                isMoving = false;
            }
        }
        if (numScreens != 1) {
            CheckCameraButtons();
            if (DOTween.IsTweening(Camera.main.transform)) {
                canMove = false;
            }
            else {
                canMove = true;
            }
        }
        else {
            rightButton.SetActive(false);
            leftButton.SetActive(false);
        }
        if (!isMoving)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 10.0f))
                {
                    if (hit.transform != null)
                    {
                        Debug.DrawLine(Camera.main.transform.position, hit.transform.position, Color.red, 2, false);
                        print(hit.transform.gameObject.name);
                        if (hit.transform.gameObject.tag == "Object")
                        {
                            hit.transform.gameObject.SendMessage("Interaction");
                        }
                        else if (hit.transform.gameObject.tag == "Item")
                        {
                            itemList.Add(hit.transform.gameObject);
                            itemList = itemList.Distinct().ToList();
                            MoveToInventorySpace();
                            print("Item added: " + hit.transform.gameObject.name);
                            StartCoroutine("ChangeTag", hit.transform.gameObject);
                        }
                    }
                }
            }
        }
    }

    // Check if buttons are active or not
    void CheckCameraButtons () {
        if (numScreens > 1) {
            if (currentScreen < numScreens){
                rightButton.SetActive(true);
            }
            else {
                rightButton.SetActive(false);
            }
            if (currentScreen > 1) {
                leftButton.SetActive(true);
            }
            else{
                leftButton.SetActive(false);
            }
        }
    }

    // Move Camera towards INT direction (- for left; + for right)
    public void MoveCamera (int direction) {
        if (canMove && !DOTween.IsTweening(Camera.main.transform)) {
            currentPosition = currentPosition + (cameraTravelSize * direction);
            print(currentPosition);
            Camera.main.transform.DOMove(new Vector3(currentPosition, 0,-10), 1, false);
            currentScreen += direction;
            canMove = false;
            isMoving = true;
            timer = 0;
        }
    }

    // Set X position of camera
    float SetCameraX () {
        float initPos = (currentScreen - 1) * cameraTravelSize;
        return initPos;
    }

    // Moves item to inventory space according to its position in the list
    void MoveToInventorySpace () {
        if (itemList.Count <= 5) {
            foreach(GameObject item in itemList) {
                int itemIndex = itemList.IndexOf(item);
                item.transform.parent = inventorySpace.transform.GetChild(itemIndex);
                
                item.transform.position = item.transform.parent.position;
                item.GetComponent<SpriteRenderer>().sortingOrder = 32767;
            }
        }
    }

    // Coroutine to change tag
    // Needed to allow item to move to the inventory before being draggable
    IEnumerator ChangeTag(GameObject item) {
        yield return new WaitForSeconds(0.5f);
        item.gameObject.tag = "Draggable";
        item.transform.gameObject.GetComponent<DraggableItem>().SendMessage("GetParentTransform");
    }

    //Check if interaction is allowed during the transition
    public bool CanInteract()
    {
        return isMoving;
    }
}
