using UnityEngine;
using System.Collections;

public class PlayByEarScript : MonoBehaviour {

	public enum State
	{
		Countdown,
		Listen,
		Playback,
		Results
	}

	public AudioClip[] audioClips;
	public AudioSource source;
	public State state;
	public PianoKeyboardScript piano;
	PianoKey randomKey;
	float countdown;

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
		int rand = (int)(Random.value * audioClips.Length); 
		randomKey = (PianoKey)rand;
		source.clip = audioClips[rand];
	}

	void ChangeState(State paramState)
	{
		state = paramState;

		switch(state)
		{
		case State.Countdown:
			countdown = 3;
			break;
		case State.Listen:
			source.Play();
			break;
		case State.Playback:
			if (piano.GetPianoKeyState(randomKey) == KeyState.Pressed)
				ChangeState(State.Results);
			break;
		case State.Results:
			break;
		}

	}

	void Update () 
	{
		switch(state)
		{
			case State.Countdown:
				countdown -= Time.deltaTime;
				if (countdown <= 0)
					ChangeState(State.Listen);
				break;
			case State.Listen:
				if (!source.isPlaying)
					ChangeState(State.Playback);
				break;
			case State.Playback:
				if (piano.GetPianoKeyState(randomKey) == KeyState.Pressed)
					ChangeState(State.Results);
				break;
			case State.Results:
				break;
		}
	}

	void Draw()
	{

	}
}
