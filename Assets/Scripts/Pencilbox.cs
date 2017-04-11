using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using System;
using Random = UnityEngine.Random;

public class Pencilbox : Building {

	//public Animator animator;
	private Vector2 startPos = new Vector2();

	public eraserarmy eArmy;
	public int frames = 0;
	public AudioClip openSound;

	// Use this for initialization
	void Start () {
		health = 100;
		cost = 100;
		player.SendMessage ("setInk", cost);
		player.insArmy ("Pencilbox");
		player.addObject (gameObject);
	
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			//animator.SetInteger ("AnimState", 4);
			dead = true;
			gameObject.collider2D.enabled = false;
			player.remArmy ("Pencilbox");
			player.remObject(gameObject);
			animator.SetInteger("AnimState", 4);
			if (frames == 50){

				Destroy(gameObject);
			}
			else 
				frames += 1;
		}
		/*if (Time.frameCount % 84 == 0){
			animator.SetInteger ("AnimState", 1);
			print ("Opening");
			print (Time.frameCount);
		} else if (Time.frameCount % 132 == 0){
			animator.SetInteger ("AnimState", 2);
			print ("Closing");
			print (Time.frameCount);
		} else if (Time.frameCount % 60 == 0){
			animator.SetInteger ("AnimState", 3);
			print ("Idle");
			print(Time.frameCount);
		}*/

	}
	private void OnEnable()
	{
		// press/release gesture for adding force like slingshot
		GetComponent<PressGesture>().Pressed += pressedHandler;
		GetComponent<ReleaseGesture>().Released += releasedHandler;
	}
	
	private void OnDisable()
	{
		// remove all registered callback function
		GetComponent<PressGesture>().Pressed -= pressedHandler;
		GetComponent<ReleaseGesture>().Released -= releasedHandler;
	}
	
	private void pressedHandler(object sender, EventArgs e)
	{
		print ("berrs");
		//GetComponent<PressGesture>().Pressed -= pressedHandler;
		//GetComponent<ReleaseGesture>().Released -= releasedHandler;
		// record press point
		//var gesture = sender as PressGesture;
		//startPos = gesture.NormalizedScreenPosition;
		
		// let's print out touch id and touch point screen coordinate
		//Vector2 tPoint = gesture.NormalizedScreenPosition;

	}
	private void releasedHandler(object sender, EventArgs e)

	{
		//GetComponent<PressGesture>().Pressed -= pressedHandler;
		//GetComponent<ReleaseGesture>().Released -= releasedHandler;
		print ("chhers");
		// add force when touch releases
		//var gesture = sender as ReleaseGesture;
		//Vector2 force = gesture.NormalizedScreenPosition - startPos;
		//rigidbody2D.AddForce (force*1.0f);

		//Vector2 tPoint = gesture.NormalizedScreenPosition;
		if (player.ink > (cost / 10)) {
			//animator.SetInteger ("AnimState", 2);
			float add = team * 3f * -1;
			eraserarmy clone = Instantiate (eArmy, new Vector2 (transform.position.x + add, transform.position.y - 1), Quaternion.identity) as eraserarmy;
			//print ("Closing");
			clone.SendMessage ("setPlayer", player);
			if (team == 1)
				clone.transform.eulerAngles = new Vector3 (0, 180, 0);
			animator.SetInteger ("AnimState", 1);
			//if (openSound)
			AudioSource.PlayClipAtPoint(openSound, new Vector3(0,0,0));
			//yield return new WaitForSeconds(1.4f);
			animator.SetInteger("AnimState",3);
		}
	}



	/*IEnumerator OnMouseUp(){
		if (player.ink > (cost / 10)) {
			//animator.SetInteger ("AnimState", 2);
			float add = team * 3f * -1;
			eraserarmy clone = Instantiate (eArmy, new Vector2 (transform.position.x + add, transform.position.y - 1), Quaternion.identity) as eraserarmy;
			//print ("Closing");
			clone.SendMessage ("setPlayer", player);
			if (team == 1)
					clone.transform.eulerAngles = new Vector3 (0, 180, 0);
			animator.SetInteger ("AnimState", 1);
			//if (openSound)
			AudioSource.PlayClipAtPoint(openSound, new Vector3(0,0,0));
			yield return new WaitForSeconds(1.4f);
			animator.SetInteger("AnimState",3);
		}
		
	}*/



}
