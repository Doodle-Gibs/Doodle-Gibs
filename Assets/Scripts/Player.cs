using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public List<string> army;
	public List<GameObject> armyObjects;
	public int ink;
	public int team;//either -1 or 1
	public bool positive;
	public Texture2D image;
	public Texture2D backImage;
	public Text inkUI;
	//public Text winnerUI;
	public bool display= false;
	public Transform unit;
	public Player opponent;
	public Unit gogo;
	public string target;
	public Color color;
	public string colorName;


	public GameOver gameOver;
	public bool over = false;


	public int frames;

	// Use this for initialization
	void Start () {
		int hei = Screen.height / 10;
		ink = 5000;
		army = new List<string> ();
		army.Add("Castle");
		target = "";
		inkUI.color = color;
		over = false;
		inkUI.transform.position = new Vector3 (inkUI.transform.position.x, hei, 0);
		inkUI.transform.localScale = new Vector3 (Screen.width/Screen.width, Screen.height/Screen.height, 0);



	}
	
	// Update is called once per frame
	void Update () {


		if (over ==true || opponent.over==true){
			inkUI.text = "";
		}
		else
			inkUI.text = "Ink: " + ink.ToString ();
		if (target != ""){

			GameObject getHim = opponent.armyObjects[0]; 
			foreach (GameObject rawr in opponent.armyObjects){

				if (rawr.name.Contains(target)){
					getHim = rawr;
				}
			}
			//print (getHim.name);
			foreach (GameObject fighter in armyObjects){
				if (fighter.transform == unit){

					gogo = fighter.GetComponent<Unit>();
					gogo.setMoving(getHim.transform);
					target = "";
				}
			}
		}
	}

	public void OnGUI(){
		if (display == true){
			float y = 0f;
			Vector2 screenPos = Camera.main.WorldToScreenPoint(unit.position);
			Vector2 convertedGUIPos = GUIUtility.ScreenToGUIPoint(screenPos);
			const int buttonWidth = 50;
			const int buttonHeight = 50;
			foreach(string item in opponent.army){
				Rect moveRect = new Rect (convertedGUIPos.x + (buttonWidth / 2), convertedGUIPos.y *-1 +Screen.height+y+25, buttonWidth, buttonHeight);
				image = Resources.Load(item, typeof(Texture2D)) as Texture2D;
				//GUI.skin.color = opponent.color;
				GUI.skin.button.normal.background = backImage;
				GUI.skin.button.hover.background = backImage;
				GUI.skin.button.active.background = backImage;
				if (GUI.Button (moveRect, image)){
					//print (item);
					target = item;
					display = false;
				}
				y =y+45f;
			}
		}
		if (over ==true || opponent.over==true){
			inkUI.text = "";
		}

	}
	public void addObject(GameObject unit){
		armyObjects.Add (unit);
	}

	public void remObject(GameObject unit){
		armyObjects.Remove (unit);
	}


	public void insArmy(string insItem){
		bool noAdd = false;
		foreach(string item in army){
			if(item.Contains(insItem))
				noAdd = true;
		}
		if (noAdd ==false)
			army.Add (insItem);
	}
	
	public void remArmy(string remItem){
		army.Remove (remItem);
	}

	public void setInk(int used){
		ink -= used;
	}

	public void displayArmy(Transform offense){
		unit = offense;
		display = true;
	}

	public void victor(int winTeam){
		over = true;
		if (winTeam == -1) {
			winTeam = 2;
		} else {
			winTeam = 1;
		}
		print ("Player");
		print (winTeam.GetType());
		print (opponent.color.GetType());
		//winnerUI.text = "Player " + winTeam.ToString()+" wins!!!";
		gameOver.victory (winTeam, opponent.color);
	}

}
