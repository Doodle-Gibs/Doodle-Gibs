using UnityEngine;
using System.Collections;

public class straw: Unit {

	public SpitBall spitball;
	public bool readytofire = false;
	public bool firing = false;
	private float xCoord;
	//public Animator animator;


	// Use this for initialization
	void Start () {
		health = 50;
		damage = 10;
		speed = 1.5f;
		cost = 20;
		player.SendMessage ("setInk", cost);
		player.addObject (gameObject);
		xCoord = Random.Range (1f, 12f);
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x*team > 0) {
			animator.SetInteger ("AnimState", 2);
		} else {
			if (inArmy == false){
				player.insArmy ("straw");
				inArmy = true;
			}
		}
		if (moving ==true && target!= null){
			gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, new Vector2 ((target.position.x - (team * 8 * -1)), target.position.y - 4), 1.5f * Time.deltaTime);
			if (Time.frameCount % 80 == 0){
				BallReady();
				animator.SetInteger("AnimState",3);
				FireBall();
			} else if (Time.frameCount % 25 == 0) {
				animator.SetInteger("AnimState",2);
			} else if (Time.frameCount % 60 == 0) {
				animator.SetInteger("AnimState",1);
			}
		}
		if (sent == true && target ==null && moving == true){
			if (transform.position.x*team < 0) {
				//go to castle
				target = player.opponent.armyObjects[0].transform;
			}
			else{
				print ("Poopsy");
				sent = false;
			}
		}
		if (health <= 0) {
			//animator.SetInteger ("AnimState", 4);
			dead = true;
			gameObject.collider2D.enabled =false;
			player.remArmy ("straw");
			player.remObject(gameObject);
			//animator.SetInteger("AnimState", 4);
			//if (frames == 50){
				Destroy(gameObject);
			//}else{
			//	frames += 1;
			//}
		}

	}

		/*
		frames = frames + 1;
		if (transform.position.x < 0) {
			animator.SetInteger ("AnimState", 2);
			frames = 0;
		} else {
			if (frames == 80) { //firing animation and firing code
				BallReady ();
				animator.SetInteger ("AnimState", 3);
				FireBall ();
				frames = 0;
			} else if (frames == 25) { //sets to walking animation
				animator.SetInteger ("AnimState", 2);
			} else if (frames == 60) { //sets to idle animation
				animator.SetInteger ("AnimState", 1);
			}
		}
	*/
	
	void BallReady() {
		readytofire = true;

	}

	void FireBall() {
		
		// safe guard
		/*if (!spitball)
			print ("sadness");
			return;*/
		// create new ball
		SpitBall clone = Instantiate(spitball, new Vector2(transform.position.x+0.7f,transform.position.y+1.2f), Quaternion.identity) as SpitBall;
		// hide fake ball
		//transform.Find("BallPos").gameObject.SetActive (false);

		// candidate ball moving angle for player 1 (left side one)
		//float angle = Mathf.Deg2Rad * Random.Range (-30, 30);

		float angle = Mathf.Deg2Rad * 30;
		float addForce = 0.4f;

		if (team == 1) {
			angle = angle * -1;
			addForce = addForce*-1;
			clone.transform.eulerAngles = new Vector3 (0, 180, 0);
		}

		// create vector2 for the angle
		Vector2 force = new Vector2(Mathf.Cos (angle), Mathf.Sin (angle));
		
		// in case of player2, reverse x direction
		// a simple trick to check the player by checking its x position
		//if (transform.position.x > 0)
		//	force.x = -force.x;
		clone.ground=transform.position.y - 1f;
	
		// apply initial force to rigidbody
		clone.rigidbody.AddForce (force*addForce);

		// reset readytofire variable
		readytofire = false;
	}
}
