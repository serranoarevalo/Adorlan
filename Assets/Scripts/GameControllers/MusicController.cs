using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

	public static MusicController instance;

	private AudioSource bgMusic, click;

	// Use this for initialization
	void Awake () {
		MakeSingleton ();

		AudioSource[] audioSources = GetComponents<AudioSource> ();

		bgMusic = audioSources [0];
		click = audioSources [1];
	}

	void MakeSingleton(){
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}
		

	public void StopBgMusic(){
		if (bgMusic.isPlaying) {
			bgMusic.Stop ();
		}
	}

	public void PlayBgMusic(){
		if (!bgMusic.isPlaying) {
			bgMusic.Play ();
		}
	}

	public void PlayClick(){
		if (GameController.instance.areEffectsOn) {
			click.Play ();
		}
	}
}
