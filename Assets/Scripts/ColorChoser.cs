using UnityEngine;
using System.Collections;

public class ColorChoser : MonoBehaviour {
	
	public string P1ColorName;
	public Color P1Color;
	public string P2ColorName;
	public Color P2Color;

	public int P1Ready = 0;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	}

	public void SetP1Color(string color){
		P1ColorName = color;
		if (color == "Blue"){
			P1Color = new Color32(0,167,218,255);
		}
		if (color == "Coral"){
			P1Color = new Color32(254,156,167,255);
		}
		if (color == "Green"){
			P1Color = new Color32(135,231,116,255);
		}
		if (color == "Magenta"){
			P1Color = new Color32(254,124,212,255);
		}
		if (color == "Orange"){
			P1Color = new Color32(254,204,139,255);
		}
		if (color == "Yellow"){
			P1Color = new Color32(254,243,111,255);
		}
	}


	public void SetP2Color(string color){
		P2ColorName = color;
		if (color == "Blue"){
			P2Color = new Color32(0,167,218,255);
		}
		if (color == "Coral"){
			P2Color = new Color32(254,156,167,255);
		}
		if (color == "Green"){
			P2Color = new Color32(135,231,116,255);
		}
		if (color == "Magenta"){
			P2Color = new Color32(254,124,212,255);
		}
		if (color == "Orange"){
			P2Color = new Color32(254,204,139,255);
		}
		if (color == "Yellow"){
			P2Color = new Color32(254,243,111,255);
		}
	}

	public void SetP1Ready(int ready){
		P1Ready = ready;
	}



	
	// Update is called once per frame
	void Update () {
		/*
		print (P1ColorName);
		print (P1Color);
		print (P2ColorName);
		print (P2Color);
		*/
		if (P1Ready == 1){
			Application.LoadLevel("GameScene");
		}
	}
}
