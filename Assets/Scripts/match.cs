using UnityEngine;
using System.Collections;

public class match : Unit {

	// Use this for initialization
	public AudioClip strikeSound;
	public Explosion explode;
	private bool readyToFire = true;

	void Start () {
		health = 30;
		damage = 50;
		speed = 2.5f;
		cost = 10;
		player.SendMessage ("setInk", cost);
		player.addObject (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (moving ==true && target!=null){
			gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, new Vector2 ((target.position.x - (team * -1)), target.position.y), 1.5f * Time.deltaTime);
		}
		if (transform.position.x*team < 0) {
			if (inArmy == false){
				player.insArmy ("match");
				inArmy = true;
			}
		}
		if (sent == true && target ==null && moving == true){
			if (transform.position.x*team < 0) {
				//go to castle
				target = player.opponent.armyObjects[0].transform;
			}
			else{
				//reset to moveable
				sent = false;
			}
		}
		if (health <= 0) {
			//animator.SetInteger ("AnimState", 4);
			dead = true;
			gameObject.collider.enabled =false;
			player.remArmy ("match");
			player.remObject(gameObject);
			//animator.SetInteger("AnimState", 4);
			//if (frames == 50){
			Destroy(gameObject);
			//}else{
			//	frames += 1;
			//}
		}
	}

	void OnMouseUp(){
		//print ("attack anim");
		animator.SetInteger ("AnimState", 2);

		if (strikeSound)
			AudioSource.PlayClipAtPoint (strikeSound, new Vector3 (0, 0, 0));
	}


	IEnumerator OnCollisionEnter(Collision target) {
		
				// safeguard: check if the audio clip is assigned
				//target.gameObject.SendMessage ("damageRecieved", damage, SendMessageOptions.DontRequireReceiver);
		if (readyToFire == true){
			print ("Hit The Target");
			Explosion clone = Instantiate (explode, new Vector2 (transform.position.x, transform.position.y), Quaternion.identity) as Explosion;
			readyToFire = false;
			yield return new WaitForSeconds (.1f);
			Destroy (gameObject);
		}
	}


}
