using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeMenu : MonoBehaviour {

	[SerializeField]
	private GameObject panel, blockedPanel, sendBtn, sendingText, sendingErrorText, startGameBtn, successText;
	[SerializeField]
	private Text musicText, effectsText, nameText, lastNameText, emailText, tokenText;

	private bool hasName, hasLastName, hasEmail, hasToken;

	public string jsonObj;

	public string url = "http://127.0.0.1:8000/pre-approved";


	void Start(){

		hasName = false;
		hasLastName = false;
		hasEmail = false;
		hasToken = false;

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
		} else {
			blockedPanel.gameObject.SetActive (true);
			MusicController.instance.StopBgMusic ();
		}
	}

	public void SendForm(){
		if (hasName && hasLastName && hasEmail && hasToken) {

			WWWForm jsonForm = new WWWForm();

			jsonForm.AddField("name",nameText.text.ToString ());
			jsonForm.AddField("last_name",lastNameText.text.ToString ());
			jsonForm.AddField("email",emailText.text.ToString ());
			jsonForm.AddField("token",tokenText.text.ToString ());

			WWW www = new WWW ("http://127.0.0.1:8000/pre-approved", jsonForm);

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

		}
		else
		{
			Debug.Log("WWW Error: " + www.error);

			sendingText.gameObject.SetActive (false);

			sendingErrorText.gameObject.SetActive (true);

		}
	}

	public void StartGame(){
		GameController.instance.isApproved = true;

		GameController.instance.Save ();

		blockedPanel.gameObject.SetActive (false);

		MusicController.instance.PlayBgMusic ();
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
