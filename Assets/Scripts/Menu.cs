using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public Text millCost;
	public Text pencilCost;
	public Text strawCost;
	public Text matchCost;
	public Player player;
	public int millInt;
	public int pencilInt;
	public int strawInt;
	public int matchInt;
	public Color grey;
	// Use this for initialization
	void Start () {
		int wid = Screen.width / 9;
		int hei = Screen.height / 60;
		millInt = 1000;
		pencilInt = 100;
		strawInt = 250;
		matchInt = 500;
		millCost.text = millInt.ToString ();
		pencilCost.text = pencilInt.ToString ();
		strawCost.text = strawInt.ToString ();
		matchCost.text = matchInt.ToString ();
		if (player.team == -1){
			millCost.gameObject.transform.position = new Vector3 (wid, hei, 0);
			pencilCost.gameObject.transform.position = new Vector3 (wid*1.75f, hei, 0);
			strawCost.gameObject.transform.position = new Vector3 (wid*2.5f, hei, 0);
			matchCost.gameObject.transform.position = new Vector3 (wid*3.25f, hei, 0);
		}
		else{
			millCost.gameObject.transform.position = new Vector3 (Screen.width-wid*.05f, hei, 0);
			pencilCost.gameObject.transform.position = new Vector3 (Screen.width-wid*.8f, hei, 0);
			strawCost.gameObject.transform.position = new Vector3 (Screen.width-wid*1.5f, hei, 0);
			matchCost.gameObject.transform.position = new Vector3 (Screen.width-wid*2.3f, hei, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
	public void OnGUI(){
		if (player.over == false && player.opponent.over==false){
			if (player.ink >= millInt){
				millCost.color = player.color;
			}else{
				millCost.color = grey;
			}
			if (player.ink >= pencilInt){
				pencilCost.color = player.color;
			}else{
				pencilCost.color = grey;
			}
			if (player.ink >= strawInt){
				strawCost.color = player.color;
			}else{
				strawCost.color = grey;
			}
			if (player.ink >= matchInt){
				matchCost.color = player.color;
			}else{
				matchCost.color=grey;
			}
		}
		else{
			millCost.text = "";
			pencilCost.text = "";
			strawCost.text = "";
			matchCost.text = "";

		}
	}
}
