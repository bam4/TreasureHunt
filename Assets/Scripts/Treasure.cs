using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class Treasure : MonoBehaviour {
	//Attach this class to the goal, and add waypoints in the Inspector

	//TODO: code compass, recolor door, design level

	public Text message;
	public Transform player;
	public Transform guide;
	public Transform door;
	public Transform key;
	public Transform compass;
	public static float activeDistance = .5f;

	private bool didPlayerWin = false;
	private bool foundKey = false;

	// Update is called once per frame
	void Update () {

		if ( isNear(Player.startPos) ){
			message.text = "Find the treasure!";
		}

		else if ( isNear(guide.position)) { //near Megaman
			message.text = "\"Find the compass, then the key, and the treasure will be yours\"";
		}

		else if ( !foundKey && isNear(door.position)) { //near locked door door
			message.text = "Door locked!";
		}

		else if ( isNear(key.position)) { //by key
			message.text = "Found key!";
			if (!foundKey) {//if this is the first frame the player is in contact with the key
				door.gameObject.SetActive(false);
			}
			foundKey = true;
		}

		else if ( isNear(transform.position) ) { //near treasure
			message.text = "Press [SPACE] to get treasure and win!";
			if (Input.GetKeyDown(KeyCode.Space))
				didPlayerWin = true;
			else if (didPlayerWin)
				message.text = "You got the treasure!  You win!!!!";
		}

		else {
			message.text = "";
		}
	}
		
	private bool isNear(Vector3 other) {
		return ( (player.position - other).magnitude < activeDistance );
	}
}
