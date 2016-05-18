using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeMenu : MonoBehaviour {

	[SerializeField]
	private GameObject panel;
	[SerializeField]
	private Text musicText, effectsText;

	void Start(){
		if (GameController.instance.areEffectsOn) {
			effectsText.text = "Apagar";
		} else {
			effectsText.text = "Prender";
		}

		if (GameController.instance.isMusicOn) {
			musicText.text = "Apagar";
		} else {
			musicText.text = "Prender";
		}
	}

	public void GoToCarMenu(){
		SceneManager.LoadScene ("SelectCar");
		MusicController.instance.PlayClick ();
	}

	public void OpenOptions(){
		panel.SetActive (true);
		MusicController.instance.PlayClick ();
	}

	public void CloseOptons(){
		panel.SetActive (false);
		MusicController.instance.PlayClick ();
	}

	public void EffectsControl(){
		if (GameController.instance.areEffectsOn) {
			GameController.instance.areEffectsOn = false;
			GameController.instance.Save ();
			effectsText.text = "Prender";
		} else {
			GameController.instance.areEffectsOn = true;
			GameController.instance.Save ();
			effectsText.text = "Apagar";
		}
	}

	public void MusicControl(){
		if (GameController.instance.isMusicOn) {
			MusicController.instance.StopBgMusic ();
			GameController.instance.isMusicOn = false;
			GameController.instance.Save ();
			musicText.text = "Prender";
		} else {
			MusicController.instance.PlayBgMusic ();
			GameController.instance.isMusicOn = true;
			GameController.instance.Save ();
			musicText.text = "Apagar";
		}
	}
}
