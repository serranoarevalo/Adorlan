using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

	public static MusicController instance;

	private AudioSource bgMusic, click, carAcceleration, crowdSound, raceSound, booSound;

	private bool beginToPlay, incrementPitchBool;

	// Use this for initialization
	void Awake () {
		MakeSingleton ();

		AudioSource[] audioSources = GetComponents<AudioSource> ();

		bgMusic = audioSources [0];
		click = audioSources [1];
		carAcceleration = audioSources [2];
		crowdSound = audioSources [3];
		raceSound = audioSources [4];
		booSound = audioSources [5];

		incrementPitchBool = false;

		if (GameController.instance.isMusicOn) {
			PlayBgMusic ();
		}
	}

	void Update() {
			
		if (beginToPlay && crowdSound.volume <= 0.8) {
				crowdSound.volume += 0.005f;
			} else {
				crowdSound.volume -= 0.005f;
			}

		if (incrementPitchBool && carAcceleration.pitch <= 2) {
			carAcceleration.pitch += 0.05f;
		} else if(!incrementPitchBool && carAcceleration.pitch >= 1) {
			carAcceleration.pitch -= 0.05f;
		}
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

	public void PlayCar() {
		if (GameController.instance.areEffectsOn) {
			carAcceleration.Play ();
		}
	}

	public void PlayCrowd(){
		if (GameController.instance.areEffectsOn) {
			crowdSound.Play ();
			beginToPlay = true;
		}
	}

	public void StopCrowd(){
		if (crowdSound.isPlaying) {
			crowdSound.Stop ();
		}
	}

	public void StopTrackFX(){
		if (crowdSound.isPlaying) {
			beginToPlay = false;
		}
		if (carAcceleration.isPlaying) {
			carAcceleration.Stop ();
		}
		if (booSound.isPlaying) {
			booSound.Stop ();
		}
		if (raceSound.isPlaying) {
			raceSound.Stop ();	
		}
	}

	public void setBeginToPlay(bool beginToPlay) {
		this.beginToPlay = beginToPlay;
	}


	public void incrementPitch(bool incrementPitchBool) {
		this.incrementPitchBool = incrementPitchBool;
	}

	public void playCarSounds(){
		if (GameController.instance.areEffectsOn) {
			carAcceleration.Play ();
		}
	}

	public void bgMusicVolume(bool onOff){
		if (onOff == true) {
			bgMusic.volume = 1;
		} else {
			bgMusic.volume = 0;
		}
	}

	public void playRaceSound(){
		if (GameController.instance.areEffectsOn) {
			raceSound.Play ();
		}
	}

	public void playBooSound(){
		if (GameController.instance.areEffectsOn && !booSound.isPlaying) {
			booSound.Play ();
		}
	}

}
