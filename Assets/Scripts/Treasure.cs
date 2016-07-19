using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Allows access to UI elements in code

public class Treasure : MonoBehaviour {
	//Attach this class to the goal, and add waypoints in the Inspector

	public Text message; // This is the "Text Box" which contains the string that is outputted to the player. This is the Text UI object
	public Transform player; // This is the position of the player, which can be accessed in the inspector.
	public Transform guide; // This is the character that provides advice to the player.
	public Transform door; // This is the position of the door that blocks the key.
	public Transform openDoor; // This is the position of the openDoor that blocks the key.
	public Transform key; // This is the position of one of the keys.
	public Transform compass; // This is the position of the compass.
	public static float activeDistance = .5f; // 

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

		else if ( isNear(guide.position) ) { //near Megaman
			message.text = "\"Find the key and regain your weapon\"";
		}

		// If they have not found the key and the door game object is active and the player is near the door, show the text below.

		else if ( !foundKey && door.gameObject.activeInHierarchy && isNear(door.position)) { //near locked door
			message.text = "Door locked!";
		}

		// If they player is near the key, show the text, turn off the closed door, turn on the open door, turn off the key.

		else if ( isNear(key.position) ) { //by key
			message.text = "Found key!";
			if (!foundKey) {//if this is the first frame the player is in contact with the key
				door.gameObject.SetActive(false);
				key.gameObject.SetActive(false);
				openDoor.gameObject.SetActive(true);
			}
			foundKey = true;
		}



		else if ( isNear(compass.position) ) { //by compass
			message.text = "The key is to the west";
		}

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
