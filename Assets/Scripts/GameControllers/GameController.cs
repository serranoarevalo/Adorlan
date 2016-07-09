using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameController : MonoBehaviour {

	public static GameController instance;

	private GameData data;

	public int currentLevel = -1 ;
	public int currentScore;

	public bool isGameStartedFirstTime;
	public bool isMusicOn;
	public bool areEffectsOn;
	public bool isApproved;
	public bool hasToken;

	public int selectedPlayer;
	public int selectedLevel;
	public int coins;
	public int highScore;

	public string tokenString;

	public bool[] players;
	public bool[] levels;

	void Awake(){
		MakeSingleton ();
		InitializeGameVariables ();
	}
		
	void MakeSingleton(){
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	void InitializeGameVariables(){

		Load ();

		if (data != null) {
			isGameStartedFirstTime = data.getIsGameStartedFirstTime ();
		} else {
			isGameStartedFirstTime = true;
		}


		if (isGameStartedFirstTime) {

			isGameStartedFirstTime = false;
			isMusicOn = true;
			areEffectsOn = true;
			isApproved = false;
			hasToken = false;

			tokenString = "";

			selectedPlayer = 0;
			selectedLevel = 0;

			coins = 0;
			highScore = 0;

			players = new bool[10];
			levels = new bool[20];

			players [0] = true;
			for (int i = 1; i < players.Length; i++) {
				players [i] = false;
			}

			levels [0] = true;
			for (int i = 1; i < levels.Length; i++) {
				levels [i] = false;
			}

			data = new GameData ();


			data.setIsGameStartedFirstTime (isGameStartedFirstTime);
			data.setIsMusicOn (isMusicOn);
			data.setIsApproved (isApproved);
			data.setHasToken (hasToken);

			data.setSelectedPlayer (selectedPlayer);
			data.setSelectedLevel (selectedLevel);

			data.setTokenString (tokenString);

			data.setCoins (coins);
			data.setHighScore (highScore);
			data.setAreEffectsOn (areEffectsOn);

			data.setPlayers (players);
			data.setLevels (levels);

			Save ();

			Load ();

		} else {

			isGameStartedFirstTime = data.getIsGameStartedFirstTime ();
			isMusicOn = data.getIsMusicOn ();
			areEffectsOn = data.getAreEffectsOn ();
			isApproved = data.getIsApproved ();
			hasToken = data.getHasToken ();

			tokenString = data.getTokenString ();

			highScore = data.getHighScore();
			coins = data.getCoins();

			selectedPlayer = data.getSelectedPlayer ();
			selectedLevel = data.getSelectedLevel ();

			players = data.getPlayers ();
			levels = data.getLevels ();


		}
	
	}

	public void Save(){

		FileStream file = null;

		try {
			BinaryFormatter bf = new BinaryFormatter();

			file = File.Create(Application.persistentDataPath + "/GameData.dat");

			if(data != null){

				data.setIsGameStartedFirstTime(isGameStartedFirstTime);
				data.setIsMusicOn(isMusicOn);
				data.setAreEffectsOn(areEffectsOn);
				data.setIsApproved(isApproved);
				data.setHasToken(hasToken);

				data.setSelectedPlayer(selectedPlayer);
				data.setSelectedLevel(selectedLevel);

				data.setTokenString(tokenString);

				data.setCoins(coins);
				data.setHighScore(highScore);

				data.setPlayers(players);
				data.setLevels(levels);

				bf.Serialize(file, data);
			}

		} catch(Exception e) {
			
		} finally {
			if (file != null) {
				file.Close ();
			}
		}

	}

	public void Load(){
		FileStream file = null;

		try{

			BinaryFormatter bf = new BinaryFormatter();

			file = File.Open(Application.persistentDataPath + "/GameData.dat", FileMode.Open);

			data = (GameData)bf.Deserialize(file);

		} catch(Exception e) {
		
		} finally {
			if (file != null) {
				file.Close ();
			}
		}
	}

	
}

[Serializable]
class GameData {
	private bool isGameStartedFirstTime;
	private bool isMusicOn;
	private bool areEffectsOn;
	private bool isApproved;
	private bool hasToken;

	private string tokenString;

	private int selectedPlayer;
	private int selectedLevel;
	private int coins;
	private int highScore;

	private bool[] players;
	private bool[] levels;

	public void setIsGameStartedFirstTime(bool isGameStartedFirstTime){
		this.isGameStartedFirstTime = isGameStartedFirstTime;
	}

	public bool getIsGameStartedFirstTime() {
		return this.isGameStartedFirstTime;
	}

	public void setIsMusicOn(bool isMusicOn){
		this.isMusicOn = isMusicOn;
	}

	public bool getIsMusicOn(){
		return this.isMusicOn;
	}

	public void setAreEffectsOn(bool areEffectsOn){
		this.areEffectsOn = areEffectsOn;
	}

	public bool getAreEffectsOn(){
		return this.areEffectsOn;
	}

	public void setSelectedPlayer(int selectedPlayer){
		this.selectedPlayer = selectedPlayer;
	}

	public int getSelectedPlayer(){
		return this.selectedPlayer;
	}

	public void setSelectedLevel(int selectedLevel){
		this.selectedLevel = selectedLevel;
	}

	public int getSelectedLevel(){
		return this.selectedLevel;
	}

	public void setHighScore(int highScore){
		this.highScore = highScore;
	}

	public int getHighScore(){
		return this.highScore;
	}

	public void setCoins(int coins){
		this.coins = coins;
	}

	public int getCoins(){
		return this.coins;
	}

	public void setPlayers(bool[] players) {
		this.players = players;
	}

	public bool[] getPlayers(){
		return this.players;
	}

	public void setLevels(bool[] levels){
		this.levels = levels;
	}

	public bool[] getLevels(){
		return this.levels;
	}

	public void setIsApproved(bool isApproved){
		this.isApproved = isApproved;
	}

	public bool getIsApproved(){
		return this.isApproved;
	}

	public void setHasToken(bool hasToken){
		this.hasToken = hasToken;
	}

	public bool getHasToken(){
		return this.hasToken;
	}

	public void setTokenString(string tokenString){
		this.tokenString = tokenString;
	}

	public string getTokenString(){
		return this.tokenString;
	}

}