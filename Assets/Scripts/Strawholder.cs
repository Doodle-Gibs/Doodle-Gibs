using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using System;
using Random = UnityEngine.Random;

public class Strawholder : Building {

	//public Animator animator;
	public straw straw;
	public int frames = 0;
	public AudioClip openSound;

	//private Vector2 startPos = new Vector2 ();

	// Use this for initialization
	void Start () {
		health = 200;
		cost = 200;
		player.SendMessage ("setInk", cost);
		player.insArmy ("Strawholder");
		player.addObject (gameObject);

		//playerMessage = gameObject.AddComponent ("PlayerMessage") as PlayerMessage;
		//player2 = gameObject.AddComponent ("Player2") as Player2;
	}
	
	// Update is called once per frame
	void Update () {
		//print (Time.frameCount);
		if (health <= 0) {
			animator.SetInteger ("AnimState", 4);
			dead = true;
			gameObject.collider2D.enabled =false;
			player.remArmy ("Strawholder");
			player.remObject(gameObject);
			animator.SetInteger("AnimState", 4);
			if (frames == 50){
				Destroy(gameObject);
			}else{
				frames += 1;
			}
		}

		/*if (!dead) {
			if (Time.frameCount % 84 == 0){
				animator.SetInteger ("AnimState", 2);
				print ("Opening");
				print (Time.frameCount);
			} else if (Time.frameCount % 132 == 0){
				animator.SetInteger ("AnimState", 3);
				print ("Closing");
				print (Time.frameCount);
			} else if (Time.frameCount % 60 == 0){
				animator.SetInteger ("AnimState", 1);
				print ("Idle");
				print(Time.frameCount);
			}
		} else {
			float death = Time.frameCount;
			if (Time.frameCount - death == 170){
				Destroy (gameObject);
			}
		}*/
	}
	private void OnEnable()
	{
		print ("cheers");
		GetComponent<TapGesture>().Tapped += tappedHandler;
	//	GetComponent<ReleaseGesture>().Released += releasedHandler;
	}
	
	private void OnDisable()
	{
		// remove all registered callback function
		GetComponent<TapGesture>().Tapped -= tappedHandler;
	//	GetComponent<ReleaseGesture>().Released -= releasedHandler;
	}
	
	private void tappedHandler(object sender, EventArgs e)
	{
		print ("POOP");
		animator.SetInteger ("AnimState", 1);
		float add = team * 2f * -1;
		straw clone = Instantiate (straw, new Vector2 (transform.position.x + add, transform.position.y - 1), Quaternion.identity) as straw;
		clone.SendMessage ("setPlayer", player);
		if (team == 1)
			clone.transform.eulerAngles = new Vector3 (0, 180, 0);
		animator.SetInteger ("AnimState", 3);
		AudioSource.PlayClipAtPoint (openSound, new Vector3 (0, 0, 0));
		animator.SetInteger ("AnimState", 1);
		//yield return new WaitForSeconds(1.5f);
		animator.SetInteger("AnimState",3);
		// record press point
		/*var gesture = sender as PressGesture;
		startPos = gesture.NormalizedScreenPosition;
		
		// let's print out touch id and touch point screen coordinate
		Vector2 tPoint = gesture.NormalizedScreenPosition;
		print ("touch id (" + gesture.ActiveTouches[0].Id + ") press point: " + tPoint);*/
		
	}
	/*private void releasedHandler(object sender, EventArgs e)
	{
		// add force when touch releases
		/*var gesture = sender as ReleaseGesture;
		Vector2 force = gesture.NormalizedScreenPosition - startPos;
		rigidbody2D.AddForce (force*1.0f);
		
		Vector2 tPoint = gesture.NormalizedScreenPosition;
		
		// note that touch id is not available at this point
		// touch list is cleared before this handler called
		print ("touch release point: " + tPoint);
		print ("PEEEE");
		animator.SetInteger ("AnimState", 3);
	}*/
	/*
		
	IEnumerator OnMouseUp(){
		if (player.ink > (cost / 10)) {
			float add = team * 2f * -1;
			straw clone = Instantiate (straw, new Vector2 (transform.position.x + add, transform.position.y - 1), Quaternion.identity) as straw;
			//print ("Closing");
			clone.SendMessage ("setPlayer", player);
			if (team == 1)
					clone.transform.eulerAngles = new Vector3 (0, 180, 0);

			AudioSource.PlayClipAtPoint (openSound, new Vector3 (0, 0, 0));
			animator.SetInteger ("AnimState", 1);
			yield return new WaitForSeconds(1.5f);
			animator.SetInteger("AnimState",3);
		}
	}*/

}

/*
		frames += 1;
		if (health <= 0) {
			animator.SetInteger ("AnimState", 4);
			dead = true;
			gameObject.collider2D.enabled =false;
			//deadFrames =frames;
		}

		if (!dead){
			if (frames == 80) { //set open animation
					animator.SetInteger ("AnimState", 2);
					frames = 0;
			} else if (frames == 37) { //set closing animation
					animator.SetInteger ("AnimState", 3);
			} else if (frames == 60) { //set idle animation
					animator.SetInteger ("AnimState", 1);
			}
		}
		else{
			deadFrames +=1;
		}
		if (deadFrames ==170){
			Destroy (gameObject);
		}
*/