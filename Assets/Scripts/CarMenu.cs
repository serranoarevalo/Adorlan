using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarMenu : MonoBehaviour {

	public Text coinText;

	public bool[] players;

	public Image[] priceTags;

	public int selectedPlayer;

	public GameObject buyPlayerPanel;

	public Button yesBtn;

	public Button noBtn;

	public Button noCoinsBtn;

	public Text buyPlayerText;


	// Use this for initialization
	void Awake () {
		InitializePlayerMenuController ();
	}
	
	// Update is called once per frame
	void InitializePlayerMenuController () {

		coinText.text = "" + GameController.instance.coins;
		players = GameController.instance.players;
		selectedPlayer = GameController.instance.selectedPlayer;

		for (int i = 1; i < players.Length; i++) {
			if (players [i] == true) {
				priceTags [i - 1].gameObject.SetActive (false);
			}
		}
	}

	public void CarOneButton(){

		if (selectedPlayer != 0) {
			selectedPlayer = 0;
		}

		GameController.instance.selectedPlayer = selectedPlayer;
		GameController.instance.Save ();

	}

	public void CarTwoButton(){

		if (players [1] == true) {

			if (selectedPlayer != 1) {
				selectedPlayer = 1;
			}

			GameController.instance.selectedPlayer = selectedPlayer;
			GameController.instance.Save ();

		} else {
		
			if (GameController.instance.coins >= 100) {
				buyPlayerPanel.SetActive (true);
				buyPlayerText.text = "¿Quieres comprar este carro?";
				yesBtn.onClick.RemoveAllListeners ();
				yesBtn.onClick.AddListener (() => BuyPlayer (1, 100));
				noCoinsBtn.gameObject.SetActive (false);
			} else {
				buyPlayerPanel.SetActive (true);
				buyPlayerText.text = "No tienes suficientes monedas. Consigue monedas completando niveles.";
				yesBtn.gameObject.SetActive (false);
				noBtn.gameObject.SetActive (false);
				noCoinsBtn.gameObject.SetActive (true);

			}
				
		}

	}

	public void CarThreeButton(){

		if (players [2] == true) {

			if (selectedPlayer != 2) {
				selectedPlayer = 2;
			}

			GameController.instance.selectedPlayer = selectedPlayer;
			GameController.instance.Save ();

		}

	}

	public void CarFourButton(){

		if (players [3] == true) {

			if (selectedPlayer != 3) {
				selectedPlayer = 3;
			}

			GameController.instance.selectedPlayer = selectedPlayer;
			GameController.instance.Save ();

		}

	}

	public void CarFiveButton(){

		if (players [4] == true) {

			if (selectedPlayer != 4) {
				selectedPlayer = 4;
			}

			GameController.instance.selectedPlayer = selectedPlayer;
			GameController.instance.Save ();

		}

	}

	public void CarSixButton(){

		if (players [5] == true) {

			if (selectedPlayer != 5) {
				selectedPlayer = 5;
			}

			GameController.instance.selectedPlayer = selectedPlayer;
			GameController.instance.Save ();

		}

	}

	public void CarSevenButton(){

		if (players [6] == true) {

			if (selectedPlayer != 6) {
				selectedPlayer = 6;
			}

			GameController.instance.selectedPlayer = selectedPlayer;
			GameController.instance.Save ();

		}

	}

	public void CarEightButton(){

		if (players [7] == true) {

			if (selectedPlayer != 7) {
				selectedPlayer = 7;
			}

			GameController.instance.selectedPlayer = selectedPlayer;
			GameController.instance.Save ();

		}

	}


	public void CarNineButton(){

		if (players [8] == true) {

			if (selectedPlayer != 8) {
				selectedPlayer = 8;
			}

			GameController.instance.selectedPlayer = selectedPlayer;
			GameController.instance.Save ();

		}

	}

	public void CarTenButton(){

		if (players [9] == true) {

			if (selectedPlayer != 9) {
				selectedPlayer = 9;
			}

			GameController.instance.selectedPlayer = selectedPlayer;
			GameController.instance.Save ();

		}

	}

	public void BuyPlayer(int index, int price) {
	
		GameController.instance.players [index] = true;
		GameController.instance.coins -= price;
		GameController.instance.Save ();
		InitializePlayerMenuController ();	

		buyPlayerPanel.SetActive (false);
	}

	public void CloseBuyPanel(){
		buyPlayerPanel.SetActive (false);
	}

	public void GoToMenu(){
		SceneManager.LoadScene ("MainMenu");
		MusicController.instance.PlayClick ();
	}

	public void GoToTrackMenu(){
		SceneManager.LoadScene ("SelectTrack");
		MusicController.instance.PlayClick ();
	}
}
