using UnityEngine;
using System.Collections;

public class GoToClick: MonoBehaviour {

	public AudioClip bounceSound;
	public float speed = 1.5f;

	private Vector3 target;
	
	void Start () {
		target = transform.position;
	}
	
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			target.z = transform.position.z;

			AudioSource.PlayClipAtPoint(bounceSound, transform.position);
		}
		transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
	}    
}
