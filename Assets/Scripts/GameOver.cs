using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	private bool isWinner;
	private int winTeam;
	public Text winnerUI;
	public Color winnerColor;

	// Use this for initialization
	void Start () {
		isWinner = false;
		winnerUI.transform.position = new Vector3(winnerUI.transform.position.x, winnerUI.transform.position.y + 10f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (isWinner == true)
			gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,new Vector3(-25,1,0), 3f * Time.deltaTime);
			//(gameObject.transform.position, new Vector2 ((target.position.x - (team * 2 * -1)), target.position.y - 2), 1.5f * Time.deltaTime);
		if (gameObject.transform.position.x == -25) {
			winnerUI.color = winnerColor;
			winnerUI.text = "Player " + winTeam.ToString()+" wins!!!";
			winnerUI.transform.localScale = new Vector3(Screen.width/Screen.width * 2, Screen.height/Screen.height * 2, 0);
			Time.timeScale = 0;
		}
	}

	void OnCollisionEnter(Collision target){
		print (target.gameObject.name);
		Destroy (target.gameObject);
	}

	public void victory(int wTeam, Color wColor){
		print ("GameOver");
		print (wTeam);

		winTeam = wTeam;
		print (winTeam);

		winnerColor = wColor;
		print (winnerColor);
		isWinner = true;
	}
}
