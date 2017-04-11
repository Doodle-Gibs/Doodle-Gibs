using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using System;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BoxCollider))]

public class MenuButton : MonoBehaviour {


	public float Speed = 10f;
	
	/// <summary>Controls pan speed.</summary>
	public float PanMultiplier = 1f;

	
	private Vector3 localPositionToGo;

	// last* variables are needed to detect when Transform's properties were changed outside of this script
	private Vector3 lastLocalPosition;



	//private Vector3 screenPoint;
	public Vector3 buildPoint;
	public GameObject clone;
	public int team;
	public Player player;
	public bool positive;
	public bool curPos;
	public int cost;
	public float fraction;
	public Texture2D image;

	void Start () {
		setDefaults ();


	}

	void Update(){


		if (player.ink > cost) {

			curPos = lastLocalPosition.x > 0;
		//	print(transform.position.x);
			fraction = Speed * Time.deltaTime;
			if (gameObject.name.Contains("ink")){
				if (!Mathf.Approximately (transform.localPosition.y, lastLocalPosition.y))
					localPositionToGo.y = transform.localPosition.y;
				if (!Mathf.Approximately (transform.localPosition.z, lastLocalPosition.z))
					localPositionToGo.z = transform.localPosition.z;
				localPositionToGo.x = 18f*team;
				transform.localPosition = lastLocalPosition = Vector3.Lerp (transform.localPosition, localPositionToGo, fraction);
			}
			else{
				if (curPos == positive && Mathf.Abs (lastLocalPosition.x) > 6){
					if (lastLocalPosition.x*team >=15f){
						localPositionToGo.x = lastLocalPosition.x+(.1f*(team*-1));
					}
					else{
						if (!Mathf.Approximately (transform.localPosition.x, lastLocalPosition.x))
							localPositionToGo.x = transform.localPosition.x;
					}
					if (!Mathf.Approximately (transform.localPosition.y, lastLocalPosition.y))
						localPositionToGo.y = transform.localPosition.y;
					if (!Mathf.Approximately (transform.localPosition.z, lastLocalPosition.z))
						localPositionToGo.z = transform.localPosition.z;
					transform.localPosition = lastLocalPosition = Vector3.Lerp (transform.localPosition, localPositionToGo, fraction);
				}
				else{
					if (!Mathf.Approximately (transform.localPosition.y, lastLocalPosition.y))
						localPositionToGo.y = transform.localPosition.y;
					if (!Mathf.Approximately (transform.localPosition.z, lastLocalPosition.z))
						localPositionToGo.z = transform.localPosition.z;
					localPositionToGo.x = lastLocalPosition.x-(.1f*(team*-1));
					transform.localPosition = lastLocalPosition = Vector3.Lerp (transform.localPosition, localPositionToGo, fraction);
				}
			}

		}
	}
	

	void OnGUI(){

		Vector2 screenPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		Vector2 convertedGUIPos = GUIUtility.ScreenToGUIPoint(screenPos);
		int wid = Screen.width / 17;
		int hei = Screen.height / 6;
		//print (wid);
		//print (hei);
		GUI.DrawTexture (new Rect (convertedGUIPos.x - (wid / 2), -1 * convertedGUIPos.y + (hei * 5.5f), wid, Screen.height/8f), image);
	}

	private void setDefaults()
	{
		localPositionToGo = lastLocalPosition = transform.localPosition;
	}



	private void OnEnable()
	{
			GetComponent<PanGesture> ().PanStarted += panStartHandler;
			GetComponent<PanGesture> ().Panned += panHandler;
			GetComponent<PanGesture> ().PanCompleted += panEndHandler;

	}
		

	
	/*void OnMouseDrag()
	{
		if (player.ink > cost) {
			Vector2 curScreenPoint = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			
			Vector2 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint);
			curPos = curPosition.x > 0;
			
			
			if (curPos == positive && Mathf.Abs (curPosition.x) > 6)
				clone.transform.position = curPosition;
			else {
				clone.transform.position = new Vector3 (team * 6, curPosition.y, 1);
			}
			//if (-6f>curPosition.y >6f){
			//	clone.transform.position[1] = (clone.transform.position.y/Mathf.Abs(clone.transform.position.y))*6;
			//}
		}*/

	private void OnDisable()
	{
		GetComponent<PanGesture>().PanStarted -= panStartHandler;
		GetComponent<PanGesture>().Panned -= panHandler;
		GetComponent<PanGesture>().PanCompleted -= panEndHandler;


	}
		

	private void panStartHandler(object sender, EventArgs e)
	{

		if (player.ink > cost)

			clone = Instantiate (gameObject, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
	}

	private void panHandler(object sender, EventArgs e)
	{
		//if (player.ink > cost){
			var gesture = (PanGesture)sender;

			localPositionToGo += gesture.LocalDeltaPosition * PanMultiplier;
	//	}

	
	}
	private void panEndHandler(object sender, EventArgs e)
	{	

		if (player.ink > cost){
			buildPoint = GetComponent<PanGesture>().transform.position;

			if (gameObject.name.Contains ("(Clone)"))
				gameObject.name = gameObject.name.Replace ("(Clone)", "");
			string item = UppercaseFirst (gameObject.name);
			GameObject instance = Instantiate (Resources.Load (item), buildPoint, Quaternion.identity) as GameObject;
			instance.gameObject.SendMessage ("setPlayer", player);
			if (team == 1) {
				instance.gameObject.transform.eulerAngles = new Vector3 (0, 180, 0);
			}
			Destroy (gameObject);
		}
	}

	private string UppercaseFirst(string s)
	{
		if (string.IsNullOrEmpty(s))
			return string.Empty;

		int cut = s.Length-2;
		s = char.ToUpper(s[0]) + s.Substring(1,cut);

		// Return char and concat substring.

		return s;
	}
	
}
/*
	
	void OnMouseDrag()
	{
		if (player.ink > cost) {
			Vector2 curScreenPoint = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);

			Vector2 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint);
			curPos = curPosition.x > 0;


			if (curPos == positive && Mathf.Abs (curPosition.x) > 6)
				clone.transform.position = curPosition;
			else {
				clone.transform.position = new Vector3 (team * 6, curPosition.y, 1);
			}
			//if (-6f>curPosition.y >6f){
			//	clone.transform.position[1] = (clone.transform.position.y/Mathf.Abs(clone.transform.position.y))*6;
			//}
		}
	}*/


