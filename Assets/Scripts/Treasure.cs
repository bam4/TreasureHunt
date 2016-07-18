using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class Treasure : MonoBehaviour {
	//Attach this class to the goal, and add waypoints in the Inspector

	public Text message;
	public Transform player;
	public Transform guide;
	public Transform door;
	public Transform openDoor;
	public Transform key;
	public Transform compass;
	public static float activeDistance = .5f;

	private bool didPlayerWin = false;
	private bool foundKey = false;
	private bool hasMoved = false;

	// Update is called once per frame
	void Update () {

		if ( !hasMoved && isNear(Player.startPos) ){
			message.text = "Find the treasure!";
		}

		else if ( isNear(guide.position) ) { //near Megaman
			message.text = "\"Find the key and regain your weapon\"";
		}

		else if ( !foundKey && door.gameObject.activeInHierarchy && isNear(door.position)) { //near locked door
			message.text = "Door locked!";
		}

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
