using UnityEngine;
using System.Collections;

public class Unit: MonoBehaviour {

	public int team;
	public int health;
	public int damage;
	public float speed;
	public int cost;
	public Player player;
	public bool dead = false;
	public bool moving = false;
	public Transform target;
	public Animator animator;
	public bool sent = false;
	public bool inArmy = false;
	public int frames = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


	}

	public void setMoving(Transform offense){
		target = offense;
		moving = true;
	}
	void OnMouseDown(){
		if (sent == false){
			player.displayArmy (gameObject.transform);
			sent = true;
		}
	}
	void damageRecieved(int dam){
		health = health - dam;
	}

	void setPlayer(Player play){
		player = play;
		team = player.team;
	}
}