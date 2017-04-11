using UnityEngine;
using System.Collections;

public class Inkmill : Building {
	public int frames=0;
	//Renderer rend = GetComponent<Renderer>();
	// Use this for initialization
	void Start () {
		health = 1000;
		cost = 1000;
		//player.SendMessage ("setInk", cost);
		//player.insArmy ("inkmill");
		gameObject.renderer.material.color = player.color;

	
	}
	
	// Update is called once per frame
	void Update () {
		if (frames == 84){
			player.ink +=2;
			
			frames=0;
		}
		frames += 1;
	}
}
