using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class HomeMenu : MonoBehaviour {

	[SerializeField]
	private GameObject panel, blockedPanel, sendBtn, sendingText, sendingErrorText, startGameBtn, successText, tokenForm, createTokenForm, sendingTextToken, sendTokenForm, sendingErrorTokenText, closeApp, successTokenText, checkingToken, tokenSent, playBtn;
	[SerializeField]
	private Text musicText, effectsText, nameText, lastNameText, emailText, tokenText, tokenNameText, tokenLastNameText, tokenEmailText, tokenTokenText, tokenButtonText, checkTokenSub;
	[SerializeField]
	private InputField tokenField;

	private bool hasName, hasLastName, hasEmail, hasToken,hasTokenName, hasTokenLastName, hasTokenEmail;

	public string tokenString;

	private string tokenFromServer;

	void Start(){

		hasName = false;
		hasLastName = false;
		hasEmail = false;
		hasToken = false;
		hasTokenName = false;
		hasTokenLastName = false;
		hasTokenEmail = false; 

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

		if (GameController.instance.isApproved) {
			blockedPanel.gameObject.SetActive (false);
			PlayGamesPlatform.Activate ();
			LogIn();
		} else if (GameController.instance.hasToken && !GameController.instance.isApproved) {
			checkingToken.gameObject.SetActive (true);
			MusicController.instance.StopBgMusic ();
			checkTokenWithAPI ();
		} else {
			blockedPanel.gameObject.SetActive (true);
			MusicController.instance.StopBgMusic ();
		}


	}

	public void LogIn()
	{
		Social.localUser.Authenticate ((bool success) =>
			{
				if (success) {
					Debug.Log ("Login Sucess");
				} else {
					Debug.Log ("Login failed");
				}
			});
	}

	public void checkTokenWithAPI(){
		if (GameController.instance.hasToken && GameController.instance.tokenString.Length > 1) {
			WWWForm tokenOnlyForm = new WWWForm ();

			tokenOnlyForm.AddField ("token", GameController.instance.tokenString);

			WWW www = new WWW ("http://adorlan.herokuapp.com/tokens", tokenOnlyForm);

			StartCoroutine (StartCheckingToken (www));

		}
	}

	IEnumerator StartCheckingToken(WWW www)
	{
		yield return 360;

		StartCoroutine(CheckTokenRequest(www));
	}

	IEnumerator CheckTokenRequest(WWW www) 
	{
		yield return www;

		if (www.error == null) 
		{
			Debug.Log (www.text);

			checkTokenSub.text = "Tu token ha sido aprobado";

			playBtn.gameObject.SetActive (true);

			GameController.instance.isApproved = true;
			GameController.instance.Save ();
		} 
		else 
		{
			Debug.Log ("WWW Error: " + www.error);

			checkTokenSub.text = "Tu token todavía no ha sido aprobado";
		}
	}

	public void SendForm(){
		if (hasName && hasLastName && hasEmail && hasToken) {

			WWWForm jsonForm = new WWWForm();

			jsonForm.AddField("name",nameText.text.ToString ());
			jsonForm.AddField("last_name",lastNameText.text.ToString ());
			jsonForm.AddField("email",emailText.text.ToString ());
			jsonForm.AddField("token",tokenText.text.ToString ());

			WWW www = new WWW ("http://adorlan.herokuapp.com/pre-approved", jsonForm);

			StartCoroutine(WaitForRequest(www));

			sendingText.gameObject.SetActive (true);

			sendingErrorText.gameObject.SetActive (false);

		}
	}

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;

		Debug.Log (www.text);

		if (www.error == null)
		{
			Debug.Log("Approved");

			sendBtn.gameObject.SetActive (false);

			startGameBtn.gameObject.SetActive (true);

			sendingText.gameObject.SetActive (false);

			successText.gameObject.SetActive (true);

			GameController.instance.isApproved = true;

			GameController.instance.Save ();

		}
		else
		{
			Debug.Log("WWW Error: " + www.error);

			sendingText.gameObject.SetActive (false);

			sendingErrorText.gameObject.SetActive (true);

		}
	}

	public void SendTokenForm(){

		string tokenString = "" + System.DateTime.Now.ToString("s") + "" + SystemInfo.deviceUniqueIdentifier;

		Debug.Log (tokenString);
		if (hasTokenName && hasTokenLastName && hasTokenEmail) {
			WWWForm tokenJsonForm = new WWWForm();

			tokenJsonForm.AddField("name",tokenNameText.text.ToString ());
			tokenJsonForm.AddField("last_name",tokenLastNameText.text.ToString ());
			tokenJsonForm.AddField("email", tokenEmailText.text.ToString ());
			tokenJsonForm.AddField("token", tokenString);

			WWW www = new WWW ("http://adorlan.herokuapp.com/users", tokenJsonForm);

			StartCoroutine(WaitForRequestToken(www, tokenString));

			sendingTextToken.gameObject.SetActive (true);


		}
	}

	IEnumerator WaitForRequestToken(WWW www, string tokenString)
	{
		yield return www;

		Debug.Log (www.text);

		if (www.error == null)
		{
			Debug.Log("Approved");

			sendingTextToken.gameObject.SetActive (false);

			closeApp.gameObject.SetActive (true);

			sendTokenForm.gameObject.SetActive (false);

			successTokenText.gameObject.SetActive (true);

			Debug.Log (tokenString);

			GameController.instance.tokenString = tokenString;
			GameController.instance.hasToken = true;
			GameController.instance.Save ();

		}
		else
		{
			Debug.Log("WWW Error: " + www.error);

			sendingTextToken.gameObject.SetActive (false);

			sendingErrorTokenText.gameObject.SetActive (true);

		}
	}

	public void FinishToken(){
		createTokenForm.gameObject.SetActive (false);
		tokenSent.gameObject.SetActive (true);
	}

	public void StartGame(){

		blockedPanel.gameObject.SetActive (false);
		tokenForm.gameObject.SetActive (false);
		checkingToken.gameObject.SetActive (false);

		MusicController.instance.PlayBgMusic ();

		PlayGamesPlatform.Activate ();
		LogIn();
	}


	public void checkName(){
		if (nameText.text.Length > 1) {
			hasName = true;
		} else {
			hasName = false;
		}
	}

	public void checkLastName(){
		if (lastNameText.text.Length > 1) {
			hasLastName = true;
		} else {
			hasLastName = false;
		}
	}

	public void checkEmail(){
		if (emailText.text.Length > 1) {
			hasEmail = true;
		} else {
			hasEmail = false;
		}
	}

	public void checkToken(){
		if (tokenText.text.Length > 1) {
			hasToken = true;
		} else {
			hasToken = false;
		}
	}

	public void checkTokenName(){
		if (tokenNameText.text.Length > 1) {
			hasTokenName = true;
		} else {
			hasTokenName = false;
		}
	}

	public void checkTokenLastName(){
		if (tokenLastNameText.text.Length > 1) {
			hasTokenLastName = true;
		} else {
			hasTokenLastName = false;
		}
	}

	public void checkTokenEmail(){
		if (tokenEmailText.text.Length > 1) {
			hasTokenEmail = true;
		} else {
			hasTokenEmail = false;
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

	public void GoToTokenForm(){
		blockedPanel.gameObject.SetActive (false);
		tokenForm.gameObject.SetActive (true);
	}

	public void GoBackFromToken(){
		tokenForm.gameObject.SetActive (false);
		createTokenForm.gameObject.SetActive (false);
		blockedPanel.gameObject.SetActive (true);
	}

	public void GoToCreateTokenForm(){
		blockedPanel.gameObject.SetActive (false);
		createTokenForm.gameObject.SetActive (true);

		tokenField.interactable = false;
		tokenField.text = SystemInfo.deviceUniqueIdentifier;
	}

	public void OpenLeaderBoard(){
		Social.ShowLeaderboardUI ();
	}
}
