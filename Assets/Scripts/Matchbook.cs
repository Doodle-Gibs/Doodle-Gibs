using UnityEngine;
using System.Collections;

public class Matchbook : Building {

	//public Matchbook match;
	public match match;
	public AudioClip openSound;

	// Use this for initialization
	void Start () {
		health = 350;
		cost = 500;
		player.SendMessage ("setInk", cost);
		player.addObject (gameObject);
		player.insArmy ("Matchbook");
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			//animator.SetInteger ("AnimState", 4);
			dead = true;
			gameObject.collider2D.enabled = false;
			player.remArmy ("Matchbook");
			player.remObject(gameObject);
			Destroy(gameObject);
		}
	}

	IEnumerator OnMouseUp(){
		//print ("You Clicked Me!!!!");

		if (player.ink > (cost / 10)) {
			float add = team * 2f * -1;
			match clone = Instantiate (match, new Vector2 (transform.position.x + add, transform.position.y - 1), Quaternion.identity) as match;
			//print ("Closing");
			clone.SendMessage ("setPlayer", player);
			if (team == 1)
				clone.transform.eulerAngles = new Vector3 (0, 180, 0);
			
			animator.SetInteger ("AnimState", 1);
			AudioSource.PlayClipAtPoint (openSound, new Vector3 (0, 0, 0));
			yield return new WaitForSeconds(1.1f);
			animator.SetInteger ("AnimState", 3);
		}
	}


}
