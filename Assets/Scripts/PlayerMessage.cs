using UnityEngine;
using System.Collections;

public class PlayerMessage : MonoBehaviour {

	string winMessage = "You Win";
	//public Player2 player2;
	public bool victory = false;
	//private int frames = 0;

	// Use this for initialization
	void Start () {

		//player2 = gameObject.AddComponent ("Player2") as Player2;
	}
	
	// Update is called once per frame
	void Update () {
		/*
		frames += 1;
		if (frames >5)
			print ("In playerMessage: " + player2.army.Count);
		if ( frames > 5 && player2.army.Count == 0)
			victory = true;
		*/
	}


	public void setVictory(){
		victory = true;
	}


	void OnGUI(){
		//print ("Victory in PlayerMessage: " + victory);
		if (victory) {
			GUIStyle winStyle = new GUIStyle ();
			winStyle.fontSize = 100;
			winStyle.normal.textColor = Color.magenta;
			GUI.Label (new Rect(Screen.width / 2.5f, Screen.height / 100, 100f, 100f), winMessage, winStyle);
			Time.timeScale = 0;
		}
	}
}
/* Java Script for displaying a message to the user
var playerObject : GameObject;
var message : String = "I am an NPC.";
var displayTime : float = 3;
var displayMessage : boolean = false;

function Update() {
	displayTime -= Time.deltaTime;
	if (displayTime <= 0.0) {
		displayMessage = false;
	}
} 

function OnTriggerStay(other : Collider) {
	if(other.collider.gameObject == playerObject && Input.GetKeyDown(KeyCode.E)) {
		displayMessage = true;    
		displayTime = 3.0;   
	}  
}

function OnGUI () {
	if (displayMessage) {
		GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), message);
	}
}
*/