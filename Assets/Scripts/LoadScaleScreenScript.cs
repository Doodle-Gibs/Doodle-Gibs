using UnityEngine;
using System.Collections;

public class LoadScaleScreenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		print ("loading scale screen");
		Application.LoadLevel (2);
	}
}
