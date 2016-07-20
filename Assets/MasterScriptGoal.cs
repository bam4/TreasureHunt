using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Allows access to UI elements in code

public class MasterScriptGoal : MonoBehaviour {
	//Attach this class to the goal, and add waypoints in the Inspector

	public Text message; // This is the "Text Box" which contains the string that is outputted to the player. This is the Text UI object
	public Transform player; // This is the position of the player, which can be accessed in the inspector.

	// This is the position of Toad, Gandalf, and Roman.
	public Transform toad; 
	public Transform gandalf;
	public Transform roman;



	public Transform greyDoorOne; // This is the position of the door that blocks the entrance to the Zelda section.
	public Transform greyDoorTwo;
	public Transform greyDoorThree;
	// This is the position of the keys.
	public Transform blueKey; 
	public Transform greenKey;
	public Transform orangeKey;
	public Transform redKey;
	public Transform purpleKey;

	// This is the position of the doors.
	public Transform blueDoor;
	public Transform greenDoor;
	public Transform orangeDoor;
	public Transform redDoor;
	public Transform purpleDoor;
	public Transform grayDoor;

	public Transform workBench;
	public Transform MarioObject;
	public Transform LOTRObject;
	public Transform GTAObject;

	public static float activeDistance = 1f; // This sets a single distance for object activation.


	// This keeps track of which keys the player has and which keys he does not have.
	private bool hasBlueKey = false;
	private bool hasGreenKey = false;
	private bool hasOrangeKey = false;
	private bool hasRedKey = false;
	private bool hasPurpleKey = false;

	// This block keeps track of the Treasure Objects.
	private bool hasMarioObject = false;
	private bool hasLOTRObject = false;
	private bool hasGTAObject = false;
	private bool hasCamusBook = false;

	private bool didPlayerWin = false; // This would allow the player to win the game.
	private bool foundKey = false; // This would allow the player to open the door.
	private bool hasMoved = false; // This notices player movement

	// Update is called once per frame
	void Update () {


		message.text = "";

		// If the player has not moved and they are close to the start position of the game, show the below text.
		if (!hasMoved && isNear (Player.startPos)) {
			message.text = "Find the treasure!";


		} else if (isNear (toad.position)) {
			message.text = "Press [Space] to talk to this key and open the gray door in front of you!";
			if (Input.GetKeyDown (KeyCode.Space)) {
				greyDoorOne.gameObject.SetActive (false);
			}
		}

		else if (isNear (gandalf.position)) {
		message.text = "Press [Space] to talk to this key and open the gray door in front of you!";
		if (Input.GetKeyDown (KeyCode.Space)) {
				greyDoorTwo.gameObject.SetActive (false);
			}
		}

		else if (isNear (roman.position)) {
			message.text = "Press [Space] to talk to this key and open the gray door in front of you!";
			if (Input.GetKeyDown (KeyCode.Space)) {
				greyDoorThree.gameObject.SetActive (false);
			}
		}


		else if (isNear(blueKey.position)) {
			message.text = "Press [Space] to pick up this key!";
			if (Input.GetKeyDown(KeyCode.Space)){
				hasBlueKey = true;
				blueKey.gameObject.SetActive(false);
			}
		}

		else if (isNear(blueDoor.position) && hasBlueKey) {
		message.text = "Press [Space] to open this door with your key!";
		if (Input.GetKeyDown(KeyCode.Space)){
			blueDoor.gameObject.SetActive(false);
			}
		}

		else if (isNear(orangeKey.position)) {
		message.text = "Press [Space] to pick up this key!";
		if (Input.GetKeyDown(KeyCode.Space)){
			hasOrangeKey = true;
			orangeKey.gameObject.SetActive(false);
			}
		}

		else if (isNear(orangeDoor.position) && hasOrangeKey) {
		message.text = "Press [Space] to open this door with your key!";
		if (Input.GetKeyDown(KeyCode.Space)){
				orangeDoor.gameObject.SetActive(false);
			}
		}

		else if (isNear(purpleKey.position)) {
		message.text = "Press [Space] to pick up this key!";
			if (Input.GetKeyDown(KeyCode.Space)){
				hasPurpleKey = true;
				purpleKey.gameObject.SetActive(false);
			}
		}

		else if (isNear (purpleDoor.position) && hasPurpleKey) {
		message.text = "Press [Space] to open this door with your key!";
			if (Input.GetKeyDown(KeyCode.Space)){
				purpleDoor.gameObject.SetActive(false);
			}
		}

		else if (isNear(greenKey.position)) {
			message.text = "Press [Space] to pick up this key!";
			if (Input.GetKeyDown(KeyCode.Space)){
				hasGreenKey = true;
				greenKey.gameObject.SetActive(false);
			}
		}

		else if (isNear (greenDoor.position) && hasGreenKey) {
			message.text = "Press [Space] to open this door with your key!";
			if (Input.GetKeyDown(KeyCode.Space)){
				greenDoor.gameObject.SetActive(false);
			}
		}

		else if (isNear(redKey.position)) {
			message.text = "Press [Space] to pick up this key!";
			if (Input.GetKeyDown(KeyCode.Space)){
				hasRedKey = true;
				redKey.gameObject.SetActive(false);
			}
		}

		else if (isNear(redDoor.position) && hasRedKey) {
			message.text = "Press [Space] to open this door with your key!";
			if (Input.GetKeyDown(KeyCode.Space)){
				redDoor.gameObject.SetActive(false);
			}
		}


		// If they are near the guide, play the text below.

		else if ( isNear(toad.position) ) { //near Megaman
			message.text = "\"Find the key and regain your weapon\"";
		}

		// If they have not found the key and the door game object is active and the player is near the door, show the text below.

		else if ( !foundKey && grayDoor.gameObject.activeInHierarchy && isNear(grayDoor.position)) { //near locked door
			message.text = "Door locked!";
		}

		// If they player is near the key, show the text, turn off the closed door, turn on the open door, turn off the key.

		else if ( isNear(blueKey.position) ) { //by key
			message.text = "Found key!";
			if (!foundKey) {//if this is the first frame the player is in contact with the key
				grayDoor.gameObject.SetActive(false);
				blueKey.gameObject.SetActive(false);
				grayDoor.gameObject.SetActive(true);
			}
			foundKey = true; // Give the player the "key."
		}

	

		// If the player is near the treasure, play the text prompting them for a "Space" input. They will win!

		else if ( isNear(transform.position) ) { //near treasure
			message.text = "Press [SPACE] to get Disc and win!";
			if (Input.GetKeyDown(KeyCode.Space)){
				didPlayerWin = true;
			}
			else if (didPlayerWin)
				message.text = "Congratulations, you win!!!!";
		}

		else { //not near anything
			hasMoved = true;
			message.text = "";
			// GetComponent<Panel>().SetActive(false);	
		}
	}

	private bool isNear(Vector3 other) {
		return ( (player.position - other).magnitude < activeDistance );
	}
}
