using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	public Text scoreText;
	public int ballValue;
	public static int scoreCompartido;
	private int score;

	// Use this for initialization
	void Start () {
		score = 0;
		UpdateScore ();
	}

	void OnTriggerEnter2D (Collider2D collision) {
		if (collision.gameObject.tag == "Bomb")
		{
			score -= ballValue * 2;
			UpdateScore();
		}
		else
		{
			score += ballValue;
			UpdateScore();
		}
	}

	//void OnCollisionEnter2D (Collision2D collision) {
	//	if (collision.gameObject.tag == "Bomb" || collision.gameObject.tag == "Bottle" || collision.gameObject.tag == "GlassBottle" || collision.gameObject.tag == "TrashCan") {
	//		score -= ballValue * 2;
	//		UpdateScore ();
	//	}
	//}

	void UpdateScore () {
		scoreText.text = "Puntaje\n" + score;
		scoreCompartido = score;
	}
}
