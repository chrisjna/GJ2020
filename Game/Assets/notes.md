## Clickable objects must have the tag "Object" or "Item"

* ITEMS = objects that are sent to the inventory 
* OBJECT = objects that are interactable (like the closet)
* Right now all objects need to have a function called Interaction() which is called when clicked

## Each stage needs to set "numScreens" for each new scene
* setting currScreen currently does not work

## Sorting Order and Box Collider 
* If an object is inside an another object (like the step ladder in the closet), the <SpriteRenderer>().sortingOrder and <BoxCollider>().size.z must be changed.
* The objects in back must have a LOWER <SpriteRenderer>().sortingOrder and <BoxCollider>().size.z number than the ones in the front
### Values
* Items: <SpriteRenderer>().sortingOrder = 10, <BoxCollider>().size.z = 5
* Objects (In Back): <SpriteRenderer>().sortingOrder = 0, <BoxCollider>().size.z = 1
* Objects (In Front): <SpriteRenderer>().sortingOrder = 100, <BoxCollider>().size.z = 10

# TODO
* Fix SetCurrentPosition() in PlayerScript.cs
	SetCurrentPosition() should set the starting camera position when the variable "currentScreen" is set to another number.
* When the screen is moving, the player should not be able to click things
* When the Win Screen appears, the player can still move to different screens

