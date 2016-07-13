using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class Treasure : MonoBehaviour {

	public Text message;
	public Transform player;
	public float activeDistance = 1f;

	private bool didPlayerWin = false;

	// Update is called once per frame
	void Update () {
		if ( (player.position - transform.position).magnitude >= activeDistance)
			message.text = "";
		if ( (player.position - transform.position).magnitude < activeDistance) {
			message.text = "Press [SPACE] to get treasure and win!";
			if (Input.GetKeyDown(KeyCode.Space))
				didPlayerWin = true;
			else if (didPlayerWin)
				message.text = "You got the treasure!  You win!!!!";
		}
	}
}
