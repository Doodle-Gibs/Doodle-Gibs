using UnityEngine;
using System.Collections;

public class MoveMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		Vector2 screenPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		Vector2 convertedGUIPos = GUIUtility.ScreenToGUIPoint(screenPos);
		const int buttonWidth = 48;
		const int buttonHeight = 27;
		
		// Determine the button's place on screen
		// Center in X, 2/3 of the height in Y
		//Rect buttonRect = new Rect(Screen.width / 2 - (buttonWidth / 2),(2 * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight);
		Rect moveRect = new Rect (convertedGUIPos.x + (buttonWidth / 2), (convertedGUIPos.y * -1) + Screen.height, buttonWidth, buttonHeight);
		
		// Draw a button to start the game
		//if(GUI.Button(buttonRect,"Test"))
		//	print ("this works right????");

		if (GUI.Button (moveRect, "Move!!"))

			print ("moving this thing");
	}
}

