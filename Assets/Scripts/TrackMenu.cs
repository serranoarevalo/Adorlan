using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrackMenu : MonoBehaviour {

	public Text coinText;

	public bool[] levels;

	public Button[] levelButtons;

	public Image[] lockIcons;

	public Text[] levelText;

	// Use this for initialization
	void Start () {
		InitializeLevelMenu ();
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

	public void GoToCarMenu(){
		SceneManager.LoadScene ("SelectCar");
		MusicController.instance.PlayClick ();
	}

	public void GoToLevel(){
		MusicController.instance.PlayClick ();
	}
}
