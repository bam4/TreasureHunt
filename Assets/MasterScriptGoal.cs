using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Allows access to UI elements in code
using UnityEngine.SceneManagement;

public class MasterScriptGoal : MonoBehaviour {
	//Attach this class to the goal, and add waypoints in the Inspector

	public Text message; // This is the "Text Box" which contains the string that is outputted to the player. This is the Text UI object
	public Transform player; // This is the position of the player, which can be accessed in the inspector.

	// This is the position of Toad, Gandalf, and Roman.
	public Transform toad; 
	public Transform gandalf;
	public Transform roman;

	public Transform toadTimer;


	public Image panel;

	public Transform greyDoorOne; // This is the position of the door that blocks the entrance to the Zelda section.
	public Transform greyDoorTwo;
	public Transform greyDoorThree;
	public Transform greyDoorFour;
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
	public Transform GTAObjectOne;
	public Transform GTAObjectTwo;
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
	private bool questForMeaning = false;

	private int spokeToToadCounter = 0;
	private int spokeToGandalfCounter = 0;
	private int spokeToRomanCounter = 0;
	private int camusCounter = 0;
	private int completedQuestCounterOne = 0;
	private int completedQuestCounterTwo = 0;
	private int completedQuestCounterThree = 0;

	private bool goalTeleporter = false;
	private bool goalAI = false;
	private bool goalShoes = false;
	private bool helpGandalf = false;
	private bool helpToad = false;
	private bool helpRoman = false;
	private bool endScreen = false;



	private bool didPlayerWin = false; // This would allow the player to win the game.
	private bool foundKey = false; // This would allow the player to open the door.
	private bool hasMoved = false; // This notices player movement


	void Start () {
		

	}
	

	// Update is called once per frame
	void Update ()
	{

		if (endScreen) {
			if (Input.GetKeyDown (KeyCode.X))
				SceneManager.LoadScene (2);
		}


		panel.GetComponent<Image> ().enabled = true;
		message.text = "";
	


		if (isNear (toad.position) && spokeToToadCounter == 0) {
			message.text = "Tron, terrible news! Bowser has kidnapped Princess [SPACE]";
			if (Input.GetKeyDown (KeyCode.Space))
				spokeToToadCounter++;
		} else if (isNear (toad.position) && spokeToToadCounter == 1) {
			message.text = "Peach's SMARTPHONE! You must go on an epic quest to find [SPACE]";
			if (Input.GetKeyDown (KeyCode.Space))
				spokeToToadCounter++;
		} else if (isNear (toad.position) && spokeToToadCounter == 2) {
			message.text = "her a replacement or she might lose her Twitter followers [SPACE]";
			if (Input.GetKeyDown (KeyCode.Space))
				spokeToToadCounter++;
		} else if (isNear (toad.position) && spokeToToadCounter == 3) {
			message.text = "I'll open this door so that you can begin the quest! [SPACE]";
			if (Input.GetKeyDown (KeyCode.Space)) {
				greyDoorOne.gameObject.SetActive (false);
				spokeToToadCounter++;
			}
		} else if (isNear (gandalf.position) && spokeToGandalfCounter == 0) {
			message.text = "Ah, Tron, good morning! [SPACE]";
			if (Input.GetKeyDown (KeyCode.Space))
				spokeToGandalfCounter++;
		} else if (isNear (gandalf.position) && spokeToGandalfCounter == 1) {
			message.text = "I'm looking for a hero to go on an adventure! [SPACE]";
			if (Input.GetKeyDown (KeyCode.Space))
				spokeToGandalfCounter++;
		} else if (isNear (gandalf.position) && spokeToGandalfCounter == 2) {
			message.text = "The dragon Smaug has stolen the Dwarve's gold! [SPACE]";
			if (Input.GetKeyDown (KeyCode.Space))
				spokeToGandalfCounter++;
		} else if (isNear (gandalf.position) && spokeToGandalfCounter == 3) {
			message.text = "More significantly, he has stolen my FIREWORKS! [SPACE]";
			if (Input.GetKeyDown (KeyCode.Space))
				spokeToGandalfCounter++;
		} else if (isNear (gandalf.position) && spokeToGandalfCounter == 4) {
			message.text = "You must go on an EPIC ADVENTURE to find me some new ROCKETS! [SPACE]";
			if (Input.GetKeyDown (KeyCode.Space))
				spokeToGandalfCounter++;
		} else if (isNear (gandalf.position) && spokeToGandalfCounter == 5) {
			message.text = "I'll open this door so that you can begin your adventure! [SPACE]";
			if (Input.GetKeyDown (KeyCode.Space)) {
				greyDoorTwo.gameObject.SetActive (false);
				spokeToGandalfCounter++;
			}


		} else if (isNear (roman.position) && spokeToRomanCounter == 0) {
			message.text = "Tron! It's your cousin Roman from Liberty City! [SPACE]";
			if (Input.GetKeyDown (KeyCode.Space))
				spokeToRomanCounter++;
		} else if (isNear (roman.position) && spokeToRomanCounter == 1) {
			message.text = "Now that you are in America, we can begin our MISSION together! [SPACE]";
			if (Input.GetKeyDown (KeyCode.Space))
				spokeToRomanCounter++;
		} else if (isNear (roman.position) && spokeToRomanCounter == 2) {
			message.text = "We are going to rule this city! [SPACE]";
			if (Input.GetKeyDown (KeyCode.Space))
				spokeToRomanCounter++;
		} else if (isNear (roman.position) && spokeToRomanCounter == 3) {
			message.text = "Before we can do anything, we need to get some stylish transportation! [SPACE]";
			if (Input.GetKeyDown (KeyCode.Space))
				spokeToRomanCounter++;
		} else if (isNear (roman.position) && spokeToRomanCounter == 4) {
			message.text = "Go through this door to find me some ROLLERSKATES! [SPACE]";
			if (Input.GetKeyDown (KeyCode.Space)) {
				greyDoorThree.gameObject.SetActive (false);
				spokeToRomanCounter++;
			}
		} else if (isNear (theStranger.position) && camusCounter == 0) {
			message.text = "Press [SPACE] to read the strange book.";
			if (Input.GetKeyDown (KeyCode.Space))
				camusCounter++;
		} else if (isNear (theStranger.position) && camusCounter == 1) {
			message.text = "Tron picks up Albert Camus's The Stranger and begins to read. [SPACE]";
			if (Input.GetKeyDown (KeyCode.Space))
				camusCounter++;
		} else if (isNear (theStranger.position) && camusCounter == 2) {
			message.text = "As he reads about Mersault's futile quest for meaning, Tron has an existential awakening. [SPACE]";
			if (Input.GetKeyDown (KeyCode.Space))
				camusCounter++;
		} else if (isNear (theStranger.position) && camusCounter == 3) {
			message.text = "His life's purpose is not determined by Gandalf, Toad, or his cousin Roman! [SPACE]";
			if (Input.GetKeyDown (KeyCode.Space))
				camusCounter++;
		} else if (isNear (theStranger.position) && camusCounter == 4) {
			message.text = "He is the sole determinant of his life's meaning! What will be the purpose of Tron's life? [SPACE]";
			// questForMeaning = true;
			if (Input.GetKeyDown (KeyCode.Space))
				camusCounter++;
		} else if (isNear (theStranger.position) && camusCounter == 5) {
			message.text = "To aim to create the world's fastest shoes, press [F]. To aim to create Artificial Intelligence, press [I]. To aim to create a teleporter, press [T].";
			if (goalAI) {
				message.text = "You chose to build Artifical Intelligence! Find the two items that create this project and bring them to the workbench in Tron's house.[SPACE]";
				if (Input.GetKeyDown (KeyCode.Space))
					camusCounter++;
			}
			if (goalShoes) {
				message.text = "You chose to build the world's fastest shoes! Find the two items that create this project and bring them to the workbench in Tron's house.[SPACE]";
				if (Input.GetKeyDown (KeyCode.Space))
					camusCounter++;
			}
			if (goalTeleporter) {
				message.text = "You chose to create a teleporter!  Find the two items that create this project and bring them to the workbench in Tron's house. [SPACE]";
				if (Input.GetKeyDown (KeyCode.Space)) {
					camusCounter++;
				}

			}

			//"\n To help Gandalf, press [G]. To help Toad, press [O]. To help Roman, press [R]";
			if (Input.GetKeyDown (KeyCode.F)) {
				goalShoes = true;
				//camusCounter++;

				
			}
			if (Input.GetKeyDown (KeyCode.I)) {
				goalAI = true;
				//camusCounter++;

				
			}
			if (Input.GetKeyDown (KeyCode.T)) {
				goalTeleporter = true;
				//camusCounter++;
			}
			if (camusCounter == 6)
				greyDoorFour.gameObject.SetActive (false);
			
//			} else if (Input.GetKeyDown (KeyCode.R)) {
//				helpRoman = true;
//				camusCounter++;
//				message.text = "You chose to help Roman!";
//			} else if (Input.GetKeyDown (KeyCode.O)) {
//				helpToad = true;
//				camusCounter++;
//				message.text = "You chose to help Toad!";
//			} else if (Input.GetKeyDown (KeyCode.G)) {
//				helpGandalf = true;
//				camusCounter++;
//				message.text = "You chose to help Gandalf!";

		} else if (isNear (MarioObject.position) && !hasMarioObject) {
			message.text = "Press [SPACE] to pick up the SMARTPHONE!";
			if (Input.GetKeyDown (KeyCode.Space)) {
				MarioObject.gameObject.SetActive (false);
				hasMarioObject = true;
			}
		} else if (isNear (LOTRObject.position) && !hasLOTRObject) {
			message.text = "Press [SPACE] to pick up the ROCKETS!";
			if (Input.GetKeyDown (KeyCode.Space)) {
				LOTRObject.gameObject.SetActive (false);
				hasLOTRObject = true;
			}
		} else if (isNear (GTAObjectOne.position) && !hasGTAObject) {
			message.text = "Press [SPACE] to pick up the ROLLERSKATES!";
			if (Input.GetKeyDown (KeyCode.Space)) {
				GTAObjectOne.gameObject.SetActive (false);
				GTAObjectTwo.gameObject.SetActive (false);
				hasGTAObject = true;
			}
		} else if (isNear (blueKey.position) && !hasBlueKey) {
			message.text = "Press [Space] to pick up this key!";
			if (Input.GetKeyDown (KeyCode.Space)) {
				hasBlueKey = true;
				blueKey.gameObject.SetActive (false);
			}
		} else if (isNear (blueDoor.position) && hasBlueKey && blueDoor.gameObject.activeInHierarchy) {
			message.text = "Press [Space] to open this door with your key!";
			if (Input.GetKeyDown (KeyCode.Space)) {
				blueDoor.gameObject.SetActive (false);
			}
		} else if (isNear (orangeKey.position) && !hasOrangeKey) {
			message.text = "Press [Space] to pick up this key!";
			if (Input.GetKeyDown (KeyCode.Space)) {
				hasOrangeKey = true;
				orangeKey.gameObject.SetActive (false);
			}
		} else if (isNear (orangeDoor.position) && hasOrangeKey && orangeDoor.gameObject.activeInHierarchy) {
			message.text = "Press [Space] to open this door with your key!";
			if (Input.GetKeyDown (KeyCode.Space)) {
				orangeDoor.gameObject.SetActive (false);
			}
		} else if (isNear (purpleKey.position) && !hasPurpleKey) {
			message.text = "Press [Space] to pick up this key!";
			if (Input.GetKeyDown (KeyCode.Space)) {
				hasPurpleKey = true;
				purpleKey.gameObject.SetActive (false);
			}
		} else if (isNear (purpleDoor.position) && hasPurpleKey && purpleDoor.gameObject.activeInHierarchy) {
			message.text = "Press [Space] to open this door with your key!";
			if (Input.GetKeyDown (KeyCode.Space)) {
				purpleDoor.gameObject.SetActive (false);
			}
		} else if (isNear (greenKey.position) && !hasGreenKey) {
			message.text = "Press [Space] to pick up this key!";
			if (Input.GetKeyDown (KeyCode.Space)) {
				hasGreenKey = true;
				greenKey.gameObject.SetActive (false);
			}
		} else if (isNear (greenDoor.position) && hasGreenKey && greenDoor.gameObject.activeInHierarchy) {
			message.text = "Press [Space] to open this door with your key!";
			if (Input.GetKeyDown (KeyCode.Space)) {
				greenDoor.gameObject.SetActive (false);
			}
		} else if (isNear (redKey.position) && !hasRedKey) {
			message.text = "Press [Space] to pick up this key!";
			if (Input.GetKeyDown (KeyCode.Space)) {
				hasRedKey = true;
				redKey.gameObject.SetActive (false);
			}
		} else if (isNear (redDoor.position) && hasRedKey && redDoor.gameObject.activeInHierarchy) {
			message.text = "Press [Space] to open this door with your key!";
			if (Input.GetKeyDown (KeyCode.Space)) {
				redDoor.gameObject.SetActive (false);
			}



		} else if (isNear (workBench.position) && goalAI && (completedQuestCounterOne < 3)) {
			if (hasGTAObject && hasMarioObject) {

				if (Input.GetKeyDown(KeyCode.Space)) 
					completedQuestCounterOne++;

				if ((completedQuestCounterOne == 0)) {
					message.text = "By combining Peach's smartphone and Roman's rollerskates, you created the first Artificial Intelligence and achieved your OWN goal! Congratulations, you win! [SPACE]";
				}

				if ( (completedQuestCounterOne == 1) ) {
					message.text = "Press [X] at any point to exit the game!";
					// if (Input.GetKeyDown(KeyCode.Space)) 
					//	completedQuestCounterThree++;
				} 

				if ( /*(Input.GetKeyDown (KeyCode.Space)) &&*/ (completedQuestCounterOne == 2)) {
					endScreen = true;
					goalAI = false;
					//completedQuestCounterThree++;
				}
				

			} else if (!hasGTAObject && !hasMarioObject) {
				message.text = "You do not have the proper objects to build Artificial Intelligence.";
			}


		} else if (isNear (workBench.position) && goalShoes && (completedQuestCounterTwo < 3)) {
			if (hasLOTRObject && hasGTAObject) {

				if (Input.GetKeyDown(KeyCode.Space)) 
					completedQuestCounterTwo++;

				if ((completedQuestCounterTwo == 0)) {
					message.text = "By combining Gandalf's rockets and Roman's rollerskates, you created the first Rocket Shoes and achieved your OWN goal! Congratulations, you win! [SPACE]";
				}

				if ( (completedQuestCounterTwo == 1) ) {
					message.text = "Press [X] at any point to exit the game!";
					// if (Input.GetKeyDown(KeyCode.Space)) 
					//	completedQuestCounterThree++;
				} 

				if ( /*(Input.GetKeyDown (KeyCode.Space)) &&*/ (completedQuestCounterTwo == 2)) {
					endScreen = true;
					goalShoes = false;
					//completedQuestCounterThree++;
				}


				} else if (!hasGTAObject && !hasLOTRObject) {
					message.text = "You do not have the proper objects to build Rocket Shoes.";
				}
				
		} else if (isNear (workBench.position) && goalTeleporter && (completedQuestCounterThree < 3)) {
			if (hasMarioObject && hasLOTRObject) {
				
				if (Input.GetKeyDown(KeyCode.Space)) 
					completedQuestCounterThree++;

				if ((completedQuestCounterThree == 0)) {
					message.text = "By combining Peach's smartphone and Gandalf's rockets, you created the first Teleporter and achieved your OWN goal! Congratulations, you win!";
				}
				
				if ( (completedQuestCounterThree == 1) ) {
					message.text = "Press [X] at any point to exit the game!";
					// if (Input.GetKeyDown(KeyCode.Space)) 
					//	completedQuestCounterThree++;
				} 

				if ( /*(Input.GetKeyDown (KeyCode.Space)) &&*/ (completedQuestCounterThree == 2)) {
					endScreen = true;
					goalTeleporter = false;
					//completedQuestCounterThree++;
					}
			} else if (!hasMarioObject && !hasLOTRObject) {
					message.text = "You do not have the proper objects to build Teleporter.";
				}
				
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

		if (Time.timeSinceLevelLoad < 3) {
			panel.GetComponent<Image>().enabled = true;
			message.text = "Find your purpose!";

		}
	}

	private bool isNear(Vector3 other) {
		return ( (player.position - other).magnitude < activeDistance );
	}
}
