using UnityEngine;
using System.Collections;

public class EraseCloud : MonoBehaviour {


	private int team;
	private int damage;
	public int frames = 0;
	public float ground;
	public Animator animator;
	public float speed = 1.5f;
	public eraserarmy parent;
	
	// Use this for initialization
	void Start () {
		damage = 100;
		speed = 0;
	}
	
	// Update is called once per frame
	void Update () {

		/*if (frames >= 12)
			Destroy (gameObject);
		else 
			frames += 1;*/
		//print (frames);
		//transform.position = Vector3.MoveTowards (transform.position, new Vector2 (13 * team * -1, -2), speed * Time.deltaTime);

	}

	IEnumerator OnCollisionEnter(Collision target){
		target.gameObject.SendMessage ("damageRecieved", damage, SendMessageOptions.DontRequireReceiver);
		print ("cloud hit");
		//parent.SendMessage ("iDied", SendMessageOptions.DontRequireReceiver);
		yield return new WaitForSeconds (1f);
		Destroy (gameObject);
		//animator.SetInteger ("AnimState", 2);
		//gameObject.rigidbody2D.isKinematic = true;
		//gameObject.collider2D.enabled = false;
	}
}
