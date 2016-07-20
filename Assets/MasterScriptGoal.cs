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


	public Image panel;

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
	public Transform theStranger;

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


	void Start () {
		
	}
	

	// Update is called once per frame
	void Update () {



		panel.GetComponent<Image>().enabled = true;
		message.text = "";
	

		if (isNear (toad.position)) {
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

		else if (isNear (theStranger.position) && theStranger.gameObject.active) {
			message.text = "Press [Space] to pick up this strange book.";
			if (Input.GetKeyDown (KeyCode.Space)) {
				theStranger.gameObject.SetActive (false);
			}
		}


		else if (isNear(blueKey.position) && !hasBlueKey) {
			message.text = "Press [Space] to pick up this key!";
			if (Input.GetKeyDown(KeyCode.Space)){
				hasBlueKey = true;
				blueKey.gameObject.SetActive(false);
			}
		}

		else if (isNear(blueDoor.position) && hasBlueKey && blueDoor.gameObject.activeInHierarchy) {
		message.text = "Press [Space] to open this door with your key!";
		if (Input.GetKeyDown(KeyCode.Space)){
			blueDoor.gameObject.SetActive(false);
			}
		}

		else if (isNear(orangeKey.position) && !hasOrangeKey) {
		message.text = "Press [Space] to pick up this key!";
		if (Input.GetKeyDown(KeyCode.Space)){
			hasOrangeKey = true;
			orangeKey.gameObject.SetActive(false);
			}
		}

		else if (isNear(orangeDoor.position) && hasOrangeKey && orangeDoor.gameObject.activeInHierarchy) {
		message.text = "Press [Space] to open this door with your key!";
		if (Input.GetKeyDown(KeyCode.Space)){
				orangeDoor.gameObject.SetActive(false);
			}
		}

		else if (isNear(purpleKey.position) && !hasPurpleKey) {
		message.text = "Press [Space] to pick up this key!";
			if (Input.GetKeyDown(KeyCode.Space)){
				hasPurpleKey = true;
				purpleKey.gameObject.SetActive(false);
			}
		}

		else if (isNear (purpleDoor.position) && hasPurpleKey && purpleDoor.gameObject.activeInHierarchy) {
		message.text = "Press [Space] to open this door with your key!";
			if (Input.GetKeyDown(KeyCode.Space)){
				purpleDoor.gameObject.SetActive(false);
			}
		}

		else if (isNear(greenKey.position) && !hasGreenKey) {
			message.text = "Press [Space] to pick up this key!";
			if (Input.GetKeyDown(KeyCode.Space)){
				hasGreenKey = true;
				greenKey.gameObject.SetActive(false);
			}
		}

		else if (isNear (greenDoor.position) && hasGreenKey && greenDoor.gameObject.activeInHierarchy) {
			message.text = "Press [Space] to open this door with your key!";
			if (Input.GetKeyDown(KeyCode.Space)){
				greenDoor.gameObject.SetActive(false);
			}
		}

		else if (isNear(redKey.position) && !hasRedKey) {
			message.text = "Press [Space] to pick up this key!";
			if (Input.GetKeyDown(KeyCode.Space)){
				hasRedKey = true;
				redKey.gameObject.SetActive(false);
			}
		}

		else if (isNear(redDoor.position) && hasRedKey && redDoor.gameObject.activeInHierarchy) {
			message.text = "Press [Space] to open this door with your key!";
			if (Input.GetKeyDown(KeyCode.Space)){
				redDoor.gameObject.SetActive(false);
			}
		}


		// If they are near the guide, play the text below.

		else if (isNear(toad.position) ) { //near Megaman
			message.text = "\"Find the key and regain your weapon\"";
		}

		// If they have not found the key and the door game object is active and the player is near the door, show the text below.

		// If the player is near the treasure, play the text prompting them for a "Space" input. They will win!

//		else if ( isNear(transform.position) ) { //near treasure
//			message.text = "Press [SPACE] to get Disc and win!";
//			if (Input.GetKeyDown(KeyCode.Space)){
//				didPlayerWin = true;
//			}
//			else if (didPlayerWin)
//				message.text = "Congratulations, you win!!!!";
//		}

		else { //not near anything
			// hasMoved = true;
			panel.GetComponent<Image>().enabled = false;
		}

		if (Time.time < 5) {
			panel.GetComponent<Image>().enabled = true;
			message.text = "Find the treasure!";
		}
	}

	private bool isNear(Vector3 other) {
		return ( (player.position - other).magnitude < activeDistance );
	}
}
