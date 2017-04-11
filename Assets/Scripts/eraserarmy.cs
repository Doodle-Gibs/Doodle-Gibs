using UnityEngine;
using System.Collections;

public class eraserarmy : Unit {
	
	//public bool moving = false;
	public bool readytofire = true;
	public EraseCloud eCloud;
	public AudioClip eraseSound;


	// Use this for initialization
	void Start () {
		health = 25;
		damage = 5;
		speed = 1.5f;
		cost = 10;
		player.SendMessage ("setInk", cost);
	//	player.insArmy ("eraserman");
		player.addObject (gameObject);
		BallReady ();
		//animator.SetInteger ("AnimState", 3);

	}
	
	// Update is called once per frame
	void Update () {
		if (moving ==true && target !=null){
			gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, new Vector2 ((target.position.x - (team * 2 * -1)), target.position.y - 2), 1.5f * Time.deltaTime);
			animator.SetInteger("AnimState", 2);
		//	BallReady ();
		}
		if (sent == true && target ==null && moving==true){
			if (transform.position.x*team < 0) {
				//go to castle
				target = player.opponent.armyObjects[0].transform;

			}
			else{
				sent = false;
			}
		}
		//print (frames);
		if (transform.position.x*team < 0) {

			if (inArmy == false){
				player.insArmy ("eraserarmy");
				inArmy = true;
			}
		}
		if (health <= 0) {
			//animator.SetInteger ("AnimState", 4);
			dead = true;
			gameObject.collider.enabled =false;
			player.remArmy ("eraserarmy");
			player.remObject(gameObject);
			//animator.SetInteger("AnimState", 4);
			//if (frames == 50){
			Destroy(gameObject);
			//}else{
			//	frames += 1;
			//}
		}

		if (frames == 24) {
			BallReady();
		} else{
			frames += 1;
		}
		
		/*if (moving == true) {
			transform.position = Vector3.MoveTowards (transform.position, new Vector2 (13 * team * -1, -2), speed * Time.deltaTime);
			if (transform.position.x*team < 0) {
				animator.SetInteger("AnimState", 2);
				if (readytofire)
					FireBall();
					AudioSource.PlayClipAtPoint(eraseSound, new Vector3(0,0,0));
			}
			//	EraseCloud clone = Instantiate(eCloud, new Vector2(transform.position.x+1.5f, transform.position.y+.3f),Quaternion.identity) as EraseCloud;
			else
				animator.SetInteger("AnimState", 1);
		}
		if (frames == 12) {
			FireBall();
			frames = 0;
		}
		if (readytofire && moving && frames >= 12){
			FireBall ();
			frames = 0;
		}*/
	}
	/*void OnMouseDown(){
		player.displayArmy (gameObject.transform);
		moving = true;
	}*/

	void OnCollisionEnter(Collision target){
		//if (readytofire == true) {
		if (readytofire == true){
			print ("eraser firing");
			FireBall ();
			readytofire = false;
			//yield return new WaitForSeconds (2f);
		}
			//readytofire = true;
		//}
	}
	
	void BallReady() {
		readytofire = true;
		//yield return new WaitForSeconds (2f);
		
	}

	void FireBall() {
		// safe guard
		//if (!eCloud)
		//	return;
		// create new ball
		//float add = team * -1;
		EraseCloud clone = Instantiate(eCloud, new Vector2(transform.position.x+.7f,transform.position.y+1.2f), Quaternion.identity) as EraseCloud;
		// hide fake ball
		//transform.Find("BallPos").gameObject.SetActive (false);

		
		// reset readytofire variable
		readytofire = false;
		//yield return new WaitForSeconds (3f);
	}

}
