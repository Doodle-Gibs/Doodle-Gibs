using UnityEngine;
using System.Collections;

public class LoadGameScreenScript : MonoBehaviour {

	public string level;
	//public AudioClip sound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		print (level);
	//	AudioSource.PlayClipAtPoint (sound, transform.position);
		Application.LoadLevel (level);
	}
	/*
	void OnGui(){
		Vector2 screenPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		Vector2 convertedGUIPos = GUIUtility.ScreenToGUIPoint(screenPos);
		int wid = Screen.width / 16;
		int hei = Screen.height / 6;
		GUI.DrawTexture (new Rect (convertedGUIPos.x - (wid / 2), -1 * convertedGUIPos.y + (hei * 5.5f), wid, Screen.height/5.5f), image);
	}
	*/
}
