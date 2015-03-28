using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayByEarEasyScript : MonoBehaviour {

	public enum State
	{
		Countdown,
		Listen,		
		Prompt,
		Playback,
		Results
	}

	public AudioClip[] audioClips;
	public AudioSource source;
	public State state;
	public PianoKeyboardScript piano;
	PianoKey randomKey;
	float countdown;
	public Text text;
	public GameObject menu_1; 
	public GameObject menu_2; 

	// Use this for initialization
	void Start () 
	{		
		audioClips = new AudioClip[]{
			Resources.Load<AudioClip>("Sounds/piano/LC"),
			Resources.Load<AudioClip>("Sounds/piano/LCs"),
			Resources.Load<AudioClip>("Sounds/piano/LD"),
			Resources.Load<AudioClip>("Sounds/piano/LDs"),
			Resources.Load<AudioClip>("Sounds/piano/LE"),
			Resources.Load<AudioClip>("Sounds/piano/LF"),
			Resources.Load<AudioClip>("Sounds/piano/LFs"),
			Resources.Load<AudioClip>("Sounds/piano/LG"),
			Resources.Load<AudioClip>("Sounds/piano/LGs"),
			Resources.Load<AudioClip>("Sounds/piano/LA"),
			Resources.Load<AudioClip>("Sounds/piano/LAs"),
			Resources.Load<AudioClip>("Sounds/piano/LB"),
			Resources.Load<AudioClip>("Sounds/piano/HC"),
			Resources.Load<AudioClip>("Sounds/piano/HCs"),
			Resources.Load<AudioClip>("Sounds/piano/HD"),
			Resources.Load<AudioClip>("Sounds/piano/HDs"),
			Resources.Load<AudioClip>("Sounds/piano/HE"),
			Resources.Load<AudioClip>("Sounds/piano/HF"),
			Resources.Load<AudioClip>("Sounds/piano/HFs"),
			Resources.Load<AudioClip>("Sounds/piano/HG"),
			Resources.Load<AudioClip>("Sounds/piano/HGs"),
			Resources.Load<AudioClip>("Sounds/piano/HA"),
			Resources.Load<AudioClip>("Sounds/piano/HAs"),
			Resources.Load<AudioClip>("Sounds/piano/HB")
		};
		ChangeState(State.Countdown);
	}

	void ChangeState(State paramState)
	{
		state = paramState;

		switch(state)
		{
		case State.Countdown:
			menu_1.SetActive(false);
			menu_2.SetActive(false);

			int rand = (int)(Random.value * audioClips.Length); 
			randomKey = (PianoKey)rand;
			source.clip = audioClips[rand];

			countdown = 3;
			break;
		case State.Listen:
			menu_1.SetActive(false);
			menu_2.SetActive(false);
			source.Play();
			break;
		case State.Prompt:
			menu_1.SetActive(true);
			menu_2.SetActive(false);
			break;
		case State.Playback:
			menu_1.SetActive(false);
			menu_2.SetActive(false);
			if (piano.GetPianoKeyState(randomKey) == KeyState.Pressed)
				ChangeState(State.Results);
			break;
		case State.Results:
			menu_1.SetActive(false);
			menu_2.SetActive(true);
			break;
		}
	}
	
	public void OnReady()
	{
		ChangeState(State.Playback);
	}
	
	public void OnListen()
	{
		ChangeState(State.Listen);
	}
	
	public void OnReplay()
	{
		ChangeState(State.Listen);
	}
	
	public void OnNext()
	{
		ChangeState(State.Countdown);
	}

	public void OnMenu()
	{
	}
	
	void Update () 
	{
		switch(state)
		{
			case State.Countdown:
				countdown -= Time.deltaTime;
				text.text = ((int)countdown + 1).ToString();
				if (countdown <= 0)
					ChangeState(State.Listen);
				break;
			case State.Listen:
				text.enabled = false;
				if (!source.isPlaying)
					ChangeState(State.Prompt);
				break;
			case State.Prompt:
				break;
			case State.Playback:
				text.enabled = true;
				text.text = "Which note did you hear?";
				if (piano.GetPianoKeyState(randomKey) == KeyState.Pressed)
					ChangeState(State.Results);
				break;
		case State.Results:
			text.text = "Correct!";
				break;
		}
	}
}
