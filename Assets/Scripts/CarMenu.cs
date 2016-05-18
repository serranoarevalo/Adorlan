using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CarMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
