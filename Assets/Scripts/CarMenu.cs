using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarMenu : MonoBehaviour {

	public Text coinText;

	public bool[] players;

	public Image[] priceTags;

	public Text[] selectText;

	public int selectedPlayer;

	public GameObject buyPlayerPanel;

	public Button yesBtn;

	public Button noBtn;

	public Button noCoinsBtn;

	public Text buyPlayerText;

	public Button nextButton;


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
				selectText [i - 1].gameObject.SetActive (true);

			}
		}
	}

	public void CarOneButton(){

		if (selectedPlayer != 0) {
			selectedPlayer = 0;
		}
		MusicController.instance.PlayClick ();
		GameController.instance.selectedPlayer = selectedPlayer;
		GameController.instance.Save ();
		enableNextButton ();

	}

	public void CarTwoButton(){

		if (players [1] == true) {

			if (selectedPlayer != 1) {
				selectedPlayer = 1;
			}
			MusicController.instance.PlayClick ();
			GameController.instance.selectedPlayer = selectedPlayer;
			GameController.instance.Save ();
			enableNextButton ();

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
			MusicController.instance.PlayClick ();
			GameController.instance.selectedPlayer = selectedPlayer;
			GameController.instance.Save ();
			enableNextButton ();

		} else {

			if (GameController.instance.coins >= 200) {
				buyPlayerPanel.SetActive (true);
				buyPlayerText.text = "¿Quieres comprar este carro?";
				yesBtn.onClick.RemoveAllListeners ();
				yesBtn.onClick.AddListener (() => BuyPlayer (2, 200));
				noCoinsBtn.gameObject.SetActive (false);
				Social.ReportProgress("CgkI9J7KgKwcEAIQBA",100.0f,(bool success) => {
				});
			} else {
				buyPlayerPanel.SetActive (true);
				buyPlayerText.text = "No tienes suficientes monedas. Consigue monedas completando niveles.";
				yesBtn.gameObject.SetActive (false);
				noBtn.gameObject.SetActive (false);
				noCoinsBtn.gameObject.SetActive (true);

			}

		}

	}

	public void CarFourButton(){

		if (players [3] == true) {

			if (selectedPlayer != 3) {
				selectedPlayer = 3;
			}
			MusicController.instance.PlayClick ();
			GameController.instance.selectedPlayer = selectedPlayer;
			GameController.instance.Save ();
			enableNextButton ();

		} else {

			if (GameController.instance.coins >= 300) {
				buyPlayerPanel.SetActive (true);
				buyPlayerText.text = "¿Quieres comprar este carro?";
				yesBtn.onClick.RemoveAllListeners ();
				yesBtn.onClick.AddListener (() => BuyPlayer (3, 300));
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

	public void CarFiveButton(){

		if (players [4] == true) {

			if (selectedPlayer != 4) {
				selectedPlayer = 4;
			}
			MusicController.instance.PlayClick ();
			GameController.instance.selectedPlayer = selectedPlayer;
			GameController.instance.Save ();
			enableNextButton ();

		} else {

			if (GameController.instance.coins >= 400) {
				buyPlayerPanel.SetActive (true);
				buyPlayerText.text = "¿Quieres comprar este carro?";
				yesBtn.onClick.RemoveAllListeners ();
				yesBtn.onClick.AddListener (() => BuyPlayer (4, 400));
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

	public void CarSixButton(){

		if (players [5] == true) {

			if (selectedPlayer != 5) {
				selectedPlayer = 5;
			}
			MusicController.instance.PlayClick ();
			GameController.instance.selectedPlayer = selectedPlayer;
			GameController.instance.Save ();
			enableNextButton ();

		} else {

			if (GameController.instance.coins >= 500) {
				buyPlayerPanel.SetActive (true);
				buyPlayerText.text = "¿Quieres comprar este carro?";
				yesBtn.onClick.RemoveAllListeners ();
				yesBtn.onClick.AddListener (() => BuyPlayer (5, 500));
				noCoinsBtn.gameObject.SetActive (false);
				Social.ReportProgress("CgkI9J7KgKwcEAIQBQ",100.0f,(bool success) => {
				});
			} else {
				buyPlayerPanel.SetActive (true);
				buyPlayerText.text = "No tienes suficientes monedas. Consigue monedas completando niveles.";
				yesBtn.gameObject.SetActive (false);
				noBtn.gameObject.SetActive (false);
				noCoinsBtn.gameObject.SetActive (true);

			}

		}

	}

	public void CarSevenButton(){

		if (players [6] == true) {

			if (selectedPlayer != 6) {
				selectedPlayer = 6;
			}
			MusicController.instance.PlayClick ();
			GameController.instance.selectedPlayer = selectedPlayer;
			GameController.instance.Save ();
			enableNextButton ();

		} else {

			if (GameController.instance.coins >= 600) {
				buyPlayerPanel.SetActive (true);
				buyPlayerText.text = "¿Quieres comprar este carro?";
				yesBtn.onClick.RemoveAllListeners ();
				yesBtn.onClick.AddListener (() => BuyPlayer (6, 600));
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

	public void CarEightButton(){

		if (players [7] == true) {

			if (selectedPlayer != 7) {
				selectedPlayer = 7;
			}
			MusicController.instance.PlayClick ();
			GameController.instance.selectedPlayer = selectedPlayer;
			GameController.instance.Save ();
			enableNextButton ();

		} else {

			if (GameController.instance.coins >= 700) {
				buyPlayerPanel.SetActive (true);
				buyPlayerText.text = "¿Quieres comprar este carro?";
				yesBtn.onClick.RemoveAllListeners ();
				yesBtn.onClick.AddListener (() => BuyPlayer (7, 700));
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


	public void CarNineButton(){

		if (players [8] == true) {

			if (selectedPlayer != 8) {
				selectedPlayer = 8;
			}
			MusicController.instance.PlayClick ();
			GameController.instance.selectedPlayer = selectedPlayer;
			GameController.instance.Save ();
			enableNextButton ();

		} else {

			if (GameController.instance.coins >= 800) {
				buyPlayerPanel.SetActive (true);
				buyPlayerText.text = "¿Quieres comprar este carro?";
				yesBtn.onClick.RemoveAllListeners ();
				yesBtn.onClick.AddListener (() => BuyPlayer (8, 800));
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

	public void CarTenButton(){

		if (players [9] == true) {

			if (selectedPlayer != 9) {
				selectedPlayer = 9;
			}
			MusicController.instance.PlayClick ();
			GameController.instance.selectedPlayer = selectedPlayer;
			GameController.instance.Save ();
			enableNextButton ();

		} else {

			if (GameController.instance.coins >= 900) {
				buyPlayerPanel.SetActive (true);
				buyPlayerText.text = "¿Quieres comprar este carro?";
				yesBtn.onClick.RemoveAllListeners ();
				yesBtn.onClick.AddListener (() => BuyPlayer (9, 900));
				noCoinsBtn.gameObject.SetActive (false);
				Social.ReportProgress("CgkI9J7KgKwcEAIQBg",100.0f,(bool success) => {
				});
			} else {
				buyPlayerPanel.SetActive (true);
				buyPlayerText.text = "No tienes suficientes monedas. Consigue monedas completando niveles.";
				yesBtn.gameObject.SetActive (false);
				noBtn.gameObject.SetActive (false);
				noCoinsBtn.gameObject.SetActive (true);

			}

		}

	}

	public void enableNextButton(){
		nextButton.gameObject.SetActive (true);
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
