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

	public string tokenString;

	public bool[] players;
	public bool[] levels;
	public bool[] achivements;

	public int[] highScores;



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

			players = new bool[10];
			levels = new bool[20];
			achivements = new bool[7];
			highScores = new int[20];

			players [0] = true;
			for (int i = 1; i < players.Length; i++) {
				players [i] = false;
			}

			levels [0] = true;
			for (int i = 1; i < levels.Length; i++) {
				levels [i] = false;
			}

			for (int i = 0; i < achivements.Length; i++) {
				achivements [i] = false;
			}

			for (int i = 0; i < highScores.Length; i++) {
				highScores [i] = 0;
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
			data.setAreEffectsOn (areEffectsOn);

			data.setPlayers (players);
			data.setLevels (levels);
			data.setAchivements (achivements);
			data.setHighScores (highScores);

			Save ();

			Load ();

		} else {

			isGameStartedFirstTime = data.getIsGameStartedFirstTime ();
			isMusicOn = data.getIsMusicOn ();
			areEffectsOn = data.getAreEffectsOn ();
			isApproved = data.getIsApproved ();
			hasToken = data.getHasToken ();

			tokenString = data.getTokenString ();

			coins = data.getCoins();

			selectedPlayer = data.getSelectedPlayer ();
			selectedLevel = data.getSelectedLevel ();
			achivements = data.getAchivements ();
			highScores = data.getHighScores ();

			players = data.getPlayers ();
			levels = data.getLevels ();
			achivements = data.getAchivements ();



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

				data.setPlayers(players);
				data.setLevels(levels);
				data.setAchivements(achivements);
				data.setHighScores(highScores);

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

	private bool[] players;
	private bool[] levels;
	private bool[] achivements;

	private int[] highScores;

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

	public void setAchivements(bool[] achivements){
		this.achivements = achivements;
	}

	public bool[] getAchivements(){
		return this.achivements;
	}

	public void setHighScores(int[] highScores){
		this.highScores = highScores;
	}

	public int[] getHighScores(){
		return this.highScores;
	}
}