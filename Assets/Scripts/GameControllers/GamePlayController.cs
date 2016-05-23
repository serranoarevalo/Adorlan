using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour {

	public static GamePlayController instance;

	public GameObject levelFailedPanel, levelPassedPanel, pausePanel ;

	[SerializeField]
	private GameObject[] players;

	public GameObject lapCounter;

	[SerializeField]
	private int currentLapNumber;

	public float levelTime;

	public Text levelTimerText, currentLap;

	private float countDownBeforeLevelBegins = 3.0f;

	private bool isGamePaused, hasLevelBegun, levelInProgress, countdownLevel;

	void CreateInstance() {
		if (instance == null)
			instance = this;
	}

	void InitializeGamePlayController(){
		levelTimerText.text = levelTime.ToString ("F0");
		Instantiate (players [GameController.instance.selectedPlayer], new Vector3(60, -50, 30), Quaternion.Euler(0, 0, 90));
	}

	void Start() {
		CreateInstance ();
		InitializeGamePlayController ();
		currentLapNumber = 1;
		currentLap.text = currentLapNumber.ToString ();

		if (Time.timeScale == 0) {
			Time.timeScale = 1;
		}

	}

	void Update() {
		LevelCountDownTime ();
		CheckLapAndTime ();
	}

	void LevelCountDownTime() {
		levelTime -= Time.deltaTime;
		levelTimerText.text = levelTime.ToString ("F0");
	}

	void CheckLapAndTime() {

		if (levelTime <= 0) {
			Time.timeScale = 0;
			levelFailedPanel.SetActive (true);
		}

		if (currentLapNumber > 3 && levelTime > 0) {
			levelPassedPanel.SetActive (true);
			Time.timeScale = 0;
		}
	}

	public void Lap() {
		currentLapNumber++;
		if (currentLapNumber <= 3) {
			currentLap.text = currentLapNumber.ToString ("F0");
		}
	}


	public void RestartLevel() {
		levelFailedPanel.SetActive (false);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void ExitLevel() {
		SceneManager.LoadScene ("SelectTrack");
	}

	public void AnswerQuestion() {
		if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.tag == "Correct") {
			Debug.Log ("Correcto!");
		} else {
			Debug.Log ("Incorrecto!");
		}
	}

	public void PuseGame() {
		Time.timeScale = 0;
		pausePanel.SetActive (true);
	}

	public void UnPauseGame() {
		pausePanel.SetActive (false);
		Time.timeScale = 1;
	}




}
