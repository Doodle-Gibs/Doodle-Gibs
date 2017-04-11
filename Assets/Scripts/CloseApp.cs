using UnityEngine;
using System.Collections;

public class CloseApp : MonoBehaviour {

	public AudioClip sound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		print ("quiting app");
		AudioSource.PlayClipAtPoint (sound, transform.position);
		Application.Quit ();
	}
}
