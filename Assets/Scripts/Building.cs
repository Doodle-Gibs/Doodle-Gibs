using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {
	
	public int team;
	public int health = 1;
	public bool dead;
	public int cost;

	public Player player;

	public Animator animator;


	// Use this for initialization
	void Start () {
		//player.SendMessage ("setInk", cost);
		//team = player.team;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void damageRecieved(int dam){
		health = health - dam;

	}

	void setPlayer(Player play){
		player = play;
		team = player.team;
	}
	/*
	void OnMouseDown(){
		if ((cost/10)<player.ink){
			animator.SetInteger ("AnimState", 1);
		//	print ("Opening");
		//	player.SendMessage("setInk",cost);
		}
	}*/



	/*
	void OnMouseUp(){
		//animator.SetInteger ("AnimState", 2);
		print ("Closing");
		animator.SetInteger ("AnimState", 3);
		
	}*/
}
