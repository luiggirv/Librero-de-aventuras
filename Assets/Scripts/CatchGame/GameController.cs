using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using LootLocker.Requests;

public class GameController : MonoBehaviour {

	public Camera cam;
	public GameObject[] balls;
	GameObject[] objetosElegidos = new GameObject[9];
	public float timeLeft;
	public Text timerText;
	public GameObject gameOverText;
	public GameObject restartButton;
	public GameObject splashScreen;
	public GameObject startButton;
	public HatController hat_Controller;

	public int numberSpawn;

	private float maxWidth;
	private bool playing;
	private int ballCount;

	bool esLluvioso = true;
	bool esTormenta = false;
	bool esNevoso = false;
	bool esSoleado = false;

	public GameObject lluvioso;
	public GameObject soleado;
	public GameObject nevoso;
	public GameObject tormenta;

	public GameObject happyMusic;
	public GameObject stormMusic;
	public GameObject rainMusic;

	public GameObject instructionsNevoso;
	public GameObject instructionsTormenta;
	public GameObject instructionsLluvioso;

	public static int LvlIngresado;

	void Start () {

		if (cam == null) {
			cam = Camera.main;
		}
		Debug.Log(balls.Length);

		if (esLluvioso)
        {
			instructionsLluvioso.SetActive(true);
			rainMusic.SetActive(true);
			lluvioso.SetActive(true);
			tormenta.SetActive(false);
			nevoso.SetActive(false);
			soleado.SetActive(false);
			for (int i = 27; i < 36; i++)
            {
				objetosElegidos[i-27] = balls[i];
            }
		}
		else if (esTormenta)
        {
			instructionsTormenta.SetActive(true);
			stormMusic.SetActive(true);
			tormenta.SetActive(true);
			lluvioso.SetActive(false);
			nevoso.SetActive(false);
			soleado.SetActive(false);
			for (int i = 18; i < 27; i++)
			{
				objetosElegidos[i-18] = balls[i];
			}
		}
		else if (esNevoso)
        {
			instructionsNevoso.SetActive(true);
			happyMusic.SetActive(true);
			nevoso.SetActive(true);
			tormenta.SetActive(false);
			lluvioso.SetActive(false);
			soleado.SetActive(false);
			for (int i = 9; i < 18; i++)
			{
				objetosElegidos[i-9] = balls[i];
			}
		}
        else
        {
			instructionsLluvioso.SetActive(true);
			happyMusic.SetActive(true);
			soleado.SetActive(true);
			tormenta.SetActive(false);
			lluvioso.SetActive(false);
			nevoso.SetActive(false);
			for (int i = 0; i < 9; i++)
			{
				objetosElegidos[i] = balls[i];
			}
		}

		Debug.Log(objetosElegidos.Length);
		playing = false;
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
		float ballWidth = objetosElegidos[0].GetComponent<Renderer>().bounds.extents.x;
		maxWidth = targetWidth.x-ballWidth;
		//StartCoroutine (Spawn ());
		UpdateText ();
	}

	void FixedUpdate () {
		if (playing) {
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0) {
				timeLeft = 0;
			}
			UpdateText ();
		}
	}

	public void StartGame () {
		instructionsLluvioso.SetActive(false);
		instructionsNevoso.SetActive(false);
		instructionsTormenta.SetActive(false);
		splashScreen.SetActive (false);
		startButton.SetActive (false);
		playing = true;
		hat_Controller.toggledControl (true);
		StartCoroutine (Spawn ());
	}

	public void BallCountUpdate () {
		ballCount--;
	}

	IEnumerator Spawn () {
		//yield return new WaitForSeconds (2.0f);
		while (timeLeft > 0) {
			int rand = Random.Range (1, numberSpawn);
			while(rand>0){
				GameObject ball = objetosElegidos[Random.Range (0, objetosElegidos.Length)];
				Vector3 spawnPosition = new Vector3 (
					Random.Range (-maxWidth, maxWidth), 
					transform.position.y, 
					0.0f
				);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (ball, spawnPosition, spawnRotation);
				ballCount++;
				rand--;
				yield return new WaitForSeconds (Random.Range (0.5f, 0.7f));
			}
			yield return new WaitForSeconds (Random.Range (1.0f, 2.0f)); //Se espera entre 1 y 2 segundos y vuelve al loop para spawnear de nuevo
		}
		yield return new WaitForSeconds(2.0f);
		gameOverText.SetActive (true);
		yield return new WaitForSeconds(1.0f);
		restartButton.SetActive (true);
		gameOverText.GetComponent<Text>().text = "Fin del juego\n Puntaje final: " + Score.scoreCompartido;
		if (PlayerPrefs.GetInt(LvlIngresado.ToString() + "a") < Score.scoreCompartido)
		{
			PlayerPrefs.SetInt(LvlIngresado.ToString() + "a", Score.scoreCompartido);

			//Para actualizar datos online
			if (PlayerPrefs.HasKey("GUID"))
			{
				string ID = PlayerPrefs.GetString("GUID");
				LootLockerSDKManager.StartSession(ID, (response) =>
				{
					if (response.success)
					{
						LootLockerGetPersistentStorageRequest data = new LootLockerGetPersistentStorageRequest();
						data.AddToPayload(new LootLockerPayload
						{
							key = LvlIngresado.ToString() + "a",
							value = PlayerPrefs.GetInt(LvlIngresado.ToString() + "a").ToString(),
							is_public = true
						});
						LootLockerSDKManager.UpdateOrCreateKeyValue(data, (getPersistentStoragResponse) =>
						{
							if (getPersistentStoragResponse.success)
							{
								Debug.Log("Puntaje del nivel actualizado");
							}
							else
							{
								Debug.Log("Error al actualizar el puntaje del nivel");
							}
						});

						int leaderboardID = 571;
						switch (LvlIngresado)
						{
							case 601:
								leaderboardID = 526;
								break;
							case 602:
								leaderboardID = 553;
								break;
							case 603:
								leaderboardID = 554;
								break;
							case 604:
								leaderboardID = 555;
								break;
							case 605:
								leaderboardID = 556;
								break;
							case 606:
								leaderboardID = 557;
								break;
						}
						LootLockerSDKManager.SubmitScore(ID, PlayerPrefs.GetInt(LvlIngresado.ToString() + "a"), leaderboardID, (response) =>
						{
							if (response.success)
							{
								Debug.Log("Puntaje guardado en el Leaderboard");
							}
							else
							{
								Debug.Log("Error al guardar puntaje en el Leaderboard");
							}
						}
						);
					}
					else
					{
						Debug.Log("Failed" + response.Error);
					}
				});
			}
		}
	} 

	void UpdateText () {
		timerText.text = "Tiempo restante\n" + Mathf.RoundToInt (timeLeft);
	}
}
