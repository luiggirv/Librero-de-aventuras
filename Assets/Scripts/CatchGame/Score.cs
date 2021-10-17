using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	public Text scoreText;
	public int ballValue;
	public static int scoreCompartido;
	private int score;
	public AudioSource splash;
	public AudioSource wrongSound;
	// Use this for initialization
	void Start () {
		score = 0;
		UpdateScore ();
	}

	void OnTriggerEnter2D (Collider2D collision) {
		if (collision.gameObject.tag == "Bomb")
		{
			wrongSound.Play();
			if (score - ballValue * 2 < 0)
				score = 0;
			else
				score -= ballValue * 2;
			UpdateScore();
		}
		else
		{
			splash.Play();
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

	public void addScore()
    {
		score += ballValue;
		UpdateScore();
	}

	public void subtractScore()
    {
		if (score - ballValue * 2 < 0)
			score = 0;
		else
			score -= ballValue * 2;
		UpdateScore();
	}

	public int showScore()
    {
		return score;
	}
}
