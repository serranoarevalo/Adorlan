using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GamePlayController : MonoBehaviour {

	public static GamePlayController instance;

	public GameObject levelFailedPanel, levelPassedPanel, pausePanel, wrongAnswerPanel, rewardPanel;

	[SerializeField]
	private GameObject[] players;

	public GameObject lapCounter;

	[SerializeField]
	private int currentLapNumber;

	public float levelTime;

	public Text levelTimerText, currentLap, countDownNumbers, rewardOne, rewardTwo;

	private float countDownBeforeLevelBegins = 3.0f;

	private bool isGamePaused, hasLevelBegun, levelInProgress, countdownLevel, nextLevel, checkedLap;

	public int levelReward;

	private int currentHighScore, scoreTime;

	public string leaderboard;

	void CreateInstance() {
		if (instance == null)
			instance = this;
	}

	void Awake() {
		Instantiate (players [GameController.instance.selectedPlayer], new Vector3(60, -50, 30), Quaternion.Euler(0, 0, 90));
		scoreTime = (int)levelTime;
	}

	void InitializeGamePlayController(){
		levelTimerText.text = levelTime.ToString ("F0");
		Time.timeScale = 0;
		countDownNumbers.text = countDownBeforeLevelBegins.ToString ("F0");
		MusicController.instance.bgMusicVolume (false);
	}

	void Start() {
		CreateInstance ();
		InitializeGamePlayController ();
		MusicController.instance.StopTrackFX ();
		currentLapNumber = 1;
		currentLap.text = currentLapNumber.ToString ();
		MusicController.instance.playRaceSound ();

		hasLevelBegun = false;
		MusicController.instance.PlayCrowd ();
		MusicController.instance.playCarSounds ();
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

		if (levelTime <= 10) {
			levelTimerText.color = Color.red;
		}

		if (levelTime <= 0) {
			MusicController.instance.playBooSound ();
			levelFailedPanel.SetActive (true);
			Time.timeScale = 0;
		}

		if (currentLapNumber > 3 && levelTime > 0) {
			Time.timeScale = 0;
			levelPassedPanel.SetActive (true);
		}
	}

	public void Lap() {
		if (checkedLap) {
			currentLapNumber++;
			checkedLap = false;
			if (currentLapNumber <= 3) {
				currentLap.text = currentLapNumber.ToString ("F0");
			}
		}
	}


	public void RestartLevel() {
		levelFailedPanel.SetActive (false);
		wrongAnswerPanel.SetActive (false);
		MusicController.instance.StopTrackFX ();
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void ExitLevel() {
		SceneManager.LoadScene ("SelectTrack");
		MusicController.instance.StopTrackFX ();
		if (GameController.instance.isMusicOn) {
			MusicController.instance.bgMusicVolume (true);
		}
	}
		

	public void AnswerQuestion() {
		if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.tag == "Correct") {

			currentHighScore = GameController.instance.highScores[GameController.instance.currentLevel];


			scoreTime = scoreTime - (int)levelTime;

			Debug.Log (currentHighScore);


			if (currentHighScore > scoreTime) {
				GameController.instance.highScores [GameController.instance.currentLevel] = (int)scoreTime;

				if (Social.localUser.authenticated) {
					Social.ReportScore ((long)scoreTime, leaderboard, (bool success) =>
						{
							if (success) {
								Debug.Log ("Update Score Success");

							} else {
								Debug.Log ("Update Score Fail");
							}
						});
				}
			}

			currentLapNumber = 0;
			levelPassedPanel.SetActive (false);
			if(GameController.instance.currentLevel != 19) nextLevel = GameController.instance.levels[GameController.instance.currentLevel + 1];
			if (nextLevel == false) {
				rewardOne.text = "+ " + levelReward.ToString ("F0") + " Monedas";	
			} else {
				rewardOne.text = "+ 10 Monedas";
			}
			if (nextLevel == false && GameController.instance.currentLevel != 19 && currentHighScore > scoreTime) {
				rewardTwo.text = "Nueva pista desbloqueada\nNuevo tiempo record";
			} else if (nextLevel == false && GameController.instance.currentLevel != 19) {
				rewardTwo.text = "Nueva pista desbloqueada";
			} else if (currentHighScore < (int)levelTime) {
				rewardTwo.text = "Nuevo tiempo record";
			} else {
				rewardTwo.text = "";
			}
			rewardPanel.SetActive (true);
			if (GameController.instance.currentLevel != 19) {
				GameController.instance.levels [GameController.instance.currentLevel + 1] = true;
			}

			if (nextLevel == false) {
				GameController.instance.coins += levelReward;	
			} else {
				GameController.instance.coins += 10;
			}
			GameController.instance.Save ();

		} else {
			MusicController.instance.StopCrowd();
			MusicController.instance.playBooSound ();
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

	public void loadNextLevel() {
		SceneManager.LoadScene ("SelectTrack");
		MusicController.instance.StopTrackFX ();
		if (GameController.instance.isMusicOn) {
			MusicController.instance.bgMusicVolume (true);
		}
	}

	public void checkLap(){
		checkedLap = true;
	}

}
