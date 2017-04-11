using UnityEngine;
using System.Collections;

public class Castle : Building {

	private int frames = 0;
	// Use this for initialization
	void Start () {
		health = 500;
		cost = 0;
		gameObject.renderer.material.color = player.color;
		//print (player.color);
		player.addObject (gameObject);

	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			dead = true;
			//gameObject.collider.enabled =false;
			//player.remArmy ("Castle");
			//animator.SetInteger("AnimState", 1);
			if (frames >= 61){
				//player.remObject(gameObject);
				print ("Castle");
				print (team.GetType());
				player.victor(team);
				//Destroy(gameObject);
			}else{
				frames += 1;
				print ("frames");
				print (frames.GetType());
			}
		}
	}
	public void addCastle(Player player){
		player.addObject (gameObject);
	}

}
