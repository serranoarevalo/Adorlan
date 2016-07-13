using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class TrackMenu : MonoBehaviour {

	public Text coinText;

	public bool[] levels;

	public Button[] levelButtons;

	public Image[] lockIcons;

	public Text[] levelText;

	// Use this for initialization
	void Start () {
		InitializeLevelMenu ();
		MusicController.instance.StopTrackFX ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void InitializeLevelMenu() {

		coinText.text = "" + GameController.instance.coins;

		levels = GameController.instance.levels;

		for (int i = 1; i < levels.Length; i++) {
			if (levels [i] == true) {
				lockIcons[i].gameObject.SetActive (false);
			} else {
				levelButtons[i].interactable = false;
				levelText [i].gameObject.SetActive (false);
			}
		}

	}

	public void LoadLevel(){
		
		string level = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;


		switch (level) {
		case "Level0":
			GameController.instance.currentLevel = 0;
			SceneManager.LoadScene ("Level0");
			break;
		case "Level1":
			GameController.instance.currentLevel = 1;
			SceneManager.LoadScene ("Level1");
			break;
		case "Level2":
			GameController.instance.currentLevel = 2;
			SceneManager.LoadScene ("Level2");
			break;
		case "Level3":
			GameController.instance.currentLevel = 3;
			SceneManager.LoadScene ("Level3");
			break;
		case "Level4":
			GameController.instance.currentLevel = 4;
			SceneManager.LoadScene ("Level4");
			Social.ReportProgress("CgkI9J7KgKwcEAIQAA",100.0f,(bool success) => {
			});
			break;
		case "Level5":
			GameController.instance.currentLevel = 5;
			SceneManager.LoadScene ("Level5");
			break;
		case "Level6":
			GameController.instance.currentLevel = 6;
			SceneManager.LoadScene ("Level6");
			break;
		case "Level7":
			GameController.instance.currentLevel = 7;
			SceneManager.LoadScene ("Level7");
			break;
		case "Level8":
			GameController.instance.currentLevel = 8;
			SceneManager.LoadScene ("Level8");
			break;
		case "Level9":
			GameController.instance.currentLevel = 9;
			SceneManager.LoadScene ("Level9");
			Social.ReportProgress("CgkI9J7KgKwcEAIQAQ",100.0f,(bool success) => {
			});
			break;
		case "Level10":
			GameController.instance.currentLevel = 10;
			SceneManager.LoadScene ("Level10");
			break;
		case "Level11":
			GameController.instance.currentLevel = 11;
			SceneManager.LoadScene ("Level11");
			break;
		case "Level12":
			GameController.instance.currentLevel = 12;
			SceneManager.LoadScene ("Level12");
			break;
		case "Level13":
			GameController.instance.currentLevel = 13;
			SceneManager.LoadScene ("Level13");
			break;
		case "Level14":
			GameController.instance.currentLevel = 14;
			SceneManager.LoadScene ("Level14");
			Social.ReportProgress("CgkI9J7KgKwcEAIQAg",100.0f,(bool success) => {
			});
			break;
		case "Level15":
			GameController.instance.currentLevel = 15;
			SceneManager.LoadScene ("Level15");
			break;
		case "Level16":
			GameController.instance.currentLevel = 16;
			SceneManager.LoadScene ("Level16");
			break;
		case "Level17":
			GameController.instance.currentLevel = 17;
			SceneManager.LoadScene ("Level17");
			break;
		case "Level18":
			GameController.instance.currentLevel = 18;
			SceneManager.LoadScene ("Level18");
			break;
		case "Level19":
			GameController.instance.currentLevel = 19;
			SceneManager.LoadScene ("Level19");
			Social.ReportProgress("CgkI9J7KgKwcEAIQAw",100.0f,(bool success) => {
			});
			break;
		}
	}

	public void GoToCarMenu(){
		SceneManager.LoadScene ("SelectCar");
		MusicController.instance.PlayClick ();
	}

	public void GoToLevel(){
		MusicController.instance.PlayClick ();
	}
}
