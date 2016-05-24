using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour {

	public static GamePlayController instance;

	public GameObject levelFailedPanel, levelPassedPanel, pausePanel, wrongAnswerPanel;

	[SerializeField]
	private GameObject[] players;

	public GameObject lapCounter;

	[SerializeField]
	private int currentLapNumber;

	public float levelTime;

	public Text levelTimerText, currentLap, countDownNumbers;

	private float countDownBeforeLevelBegins = 5.0f;

	private bool isGamePaused, hasLevelBegun, levelInProgress, countdownLevel;

	public int levelReward;

	void CreateInstance() {
		if (instance == null)
			instance = this;
	}

	void InitializeGamePlayController(){
		levelTimerText.text = levelTime.ToString ("F0");
		Instantiate (players [GameController.instance.selectedPlayer], new Vector3(60, -50, 30), Quaternion.Euler(0, 0, 90));
		Time.timeScale = 0;
		countDownNumbers.text = countDownBeforeLevelBegins.ToString ("F0");
	}

	void Start() {
		CreateInstance ();
		InitializeGamePlayController ();
		currentLapNumber = 1;
		currentLap.text = currentLapNumber.ToString ();

		hasLevelBegun = false;
	}

	void Update() {
		LevelCountDownTime ();
		CheckLapAndTime ();

		CountDownAndBeginLevel ();
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
		wrongAnswerPanel.SetActive (false);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void ExitLevel() {
		SceneManager.LoadScene ("SelectTrack");
	}

	public void AnswerQuestion() {
		if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.tag == "Correct") {
			GameController.instance.coins += levelReward * 10000;
			GameController.instance.levels [1] = true;
			GameController.instance.Save ();
			SceneManager.LoadScene ("SelectTrack");
			
		} else {
			currentLapNumber = 0;
			levelPassedPanel.SetActive (false);
			wrongAnswerPanel.SetActive (true);
		
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
		
	void CountDownAndBeginLevel() {
		if (!hasLevelBegun) {
			countDownBeforeLevelBegins -= (0.19f * 0.15f);
			countDownNumbers.text = countDownBeforeLevelBegins.ToString ("F0");
			if (countDownBeforeLevelBegins <= 0) {
				Time.timeScale = 1;
				countDownNumbers.gameObject.SetActive (false);
				hasLevelBegun = true;
			}
		}
	}

}
