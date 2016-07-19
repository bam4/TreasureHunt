using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Allows access to UI elements in code

public class MasterScriptGoal : MonoBehaviour {
	//Attach this class to the goal, and add waypoints in the Inspector

	public Text message; // This is the "Text Box" which contains the string that is outputted to the player. This is the Text UI object
	public Transform player; // This is the position of the player, which can be accessed in the inspector.

	// This is the position of Toad, Gandalf, and Roman.
	public Transform Toad; 
	public Transform Gandalf;
	public Transform Roman;


	public Transform greyDoorOneClosed; // This is the position of the door that blocks the entrance to the Zelda section.
	public Transform greyDoorOneOpen; // This is the open version of the greyDoor.

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

	public Transform workBench;
	public Transform MarioObject;
	public Transform LOTRObject;
	public Transform GTAObject;

	public static float activeDistance = .5f; // This sets a single distance for object activation.


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

		// If the player has not moved and they are close to the start position of the game, show the below text.

		if ( !hasMoved && isNear(Player.startPos) ){
			message.text = "Find the treasure!";
		}

		// If they are near the guide, play the text below.

		else if ( isNear(Toad.position) ) { //near Megaman
			message.text = "\"Find the key and regain your weapon\"";
		}

		// If they have not found the key and the door game object is active and the player is near the door, show the text below.

		else if ( !foundKey && GrayDoor.gameObject.activeInHierarchy && isNear(GrayDoor.position)) { //near locked door
			message.text = "Door locked!";
		}

		// If they player is near the key, show the text, turn off the closed door, turn on the open door, turn off the key.

		else if ( isNear(blueKey.position) ) { //by key
			message.text = "Found key!";
			if (!foundKey) {//if this is the first frame the player is in contact with the key
				door.gameObject.SetActive(false);
				key.gameObject.SetActive(false);
				openDoor.gameObject.SetActive(true);
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
		}
	}

	private bool isNear(Vector3 other) {
		return ( (player.position - other).magnitude < activeDistance );
	}
}
