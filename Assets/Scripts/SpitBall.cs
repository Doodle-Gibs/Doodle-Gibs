using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;


public class SpitBall : MonoBehaviour {

	//unit  or projectile? different enough to have two, projectile a TYPE of unit?

	private int team;
	private int damage;
	private int frames;
	public float ground;
	public float hitTime;
	public Animator animator;
	
	// collision sound clip
	public AudioClip squelchSound;
	
	// variable to store start position of dragging for slingshot!
	//private Vector2 startPos = new Vector2();
	
	// Use this for initialization
	void Start () {
		damage = 100;
		//health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		/*like the ball from the player in brick breaker,
		 * most of this stuff should be done in the straw class.
		 * clones of this will be made every time one gets destroyed,
		 * or alternatively, every set few seconds. 
		 */
		//if (frames >= 12) {
		//	print ("turn on spitball collider");
		//} else
			frames += 1;

		if (transform.position.y <= ground) {
			if (squelchSound)
				// simple audio clip playback
				AudioSource.PlayClipAtPoint (squelchSound, transform.position);
			//print ("hit ground");
			Destroy (gameObject);
		} 
	}
	
	// Collision handling: make a bouncing sound when hit a wall
	IEnumerator OnCollisionEnter(Collision target) {
		print ("spitball hit");
		// safeguard: check if the audio clip is assigned
		if (squelchSound)
			// simple audio clip playback
			AudioSource.PlayClipAtPoint(squelchSound, transform.position);

		target.gameObject.SendMessage ("damageRecieved", damage, SendMessageOptions.DontRequireReceiver);
		animator.SetInteger ("AnimState", 2);

		//hitTime = Time.time;
		gameObject.rigidbody.isKinematic = true;
		gameObject.collider.enabled = false;

		yield return new WaitForSeconds (2f);
		Destroy (gameObject);
	}

	public int getDamage()
	{
		return damage;
	}
}