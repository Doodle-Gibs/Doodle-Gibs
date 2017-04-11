using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {


	private int team;
	private int damage;
	public int frames = 0;
	public float ground;
	public Animator animator;
	public float speed = 1.5f;

	// Use this for initialization
	void Start () {
		damage = 100;
		speed = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator OnCollisionEnter(Collision target) {
		
		// safeguard: check if the audio clip is assigned
		target.gameObject.SendMessage ("damageRecieved", damage, SendMessageOptions.DontRequireReceiver);
		print ("Exploded On The Target");
		yield return new WaitForSeconds (1f);
		Destroy (gameObject);
	}
}
