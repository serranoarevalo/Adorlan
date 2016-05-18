using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TrackMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoToCarMenu(){
		SceneManager.LoadScene ("SelectCar");
		MusicController.instance.PlayClick ();
	}

	public void GoToLevel(){
		MusicController.instance.PlayClick ();
	}
}
