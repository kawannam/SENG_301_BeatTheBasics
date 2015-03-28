using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public interface PianoKeyboardObserver
{
	void OnPianoKeyDown(PianoKey paramKey);
}

public class PlayByEarHardScript : MonoBehaviour, PianoKeyboardObserver {

	public enum State
	{
		Init,
		Countdown,
		Listen,		
		WaitReady,
		Input,
		Results
	}
	private const int NUM_OF_NOTES = 3;
	private const float NOTE_DURATION = 0.5f;
	public AudioClip[] audioClips;
	public AudioSource source;
	public State state;
	public PianoKeyboardScript piano;
	public Text text;
	public GameObject menu_1; 
	public GameObject menu_2; 
	public float countdown;

	// tune playing
	public PianoKey[] songKeys;
	public int songIdx;
	public float songTimer;

	// user input
	public PianoKey[] inputKeys;
	public int inputIdx;

	// results 
	public float resultsTimer;
	public int resultsIdx;
	public int resultsPoints;

	// Use this for initialization
	void Start () 
	{					
		audioClips = new AudioClip[Constants.PIANO_NUM_KEYS];
		for (int i = 0; i < Constants.PIANO_NUM_KEYS; i++)
			audioClips[i] = Resources.Load<AudioClip>(Constants.PIANO_SOUND_FILES[i]);
	
		ChangeState(State.Init);
	}

	void ChangeState(State paramState)
	{
		state = paramState;

		switch(state)
		{
		case State.Init:
			menu_1.SetActive(false);
			menu_2.SetActive(false);
			songKeys = new PianoKey[NUM_OF_NOTES];
			for (int i = 0; i < NUM_OF_NOTES; i++)
			{
				int rand = (int)(Random.value * Constants.PIANO_NUM_KEYS); 
				songKeys[i] = (PianoKey)rand;
			}
			songKeys[0] = PianoKey.H_A;
			songKeys[1] = PianoKey.H_As;
			songKeys[2] = PianoKey.H_B;
			ChangeState(State.Countdown);
			break;
		case State.Countdown:
			menu_1.SetActive(false);
			menu_2.SetActive(false);
			countdown = 3;
			break;
		case State.Listen:
			text.enabled = false;
			menu_1.SetActive(false);
			menu_2.SetActive(false);
			songIdx = 0;
			songTimer = 0;
			break;
		case State.WaitReady:
			menu_1.SetActive(true);
			menu_2.SetActive(false);
			break;
		case State.Input:
			text.text = "Which note did you hear?";
			piano.observers.Add(this);
			menu_1.SetActive(false);
			menu_2.SetActive(false);
			inputKeys = new PianoKey[songKeys.Length];
			inputIdx = 0;
			break;
		case State.Results:
			piano.observers.Remove(this);
			menu_1.SetActive(false);
			menu_2.SetActive(true);

			resultsTimer = 0;
			resultsIdx = 0;
			resultsPoints = 0;
			text.enabled = true;
			break;
		}
	}

	public void OnPianoKeyDown(PianoKey paramKey)
	{
		switch(state)
		{
		case State.Input:
			inputKeys[inputIdx] = paramKey;
			inputIdx++;
			if (inputIdx >= songKeys.Length)
				ChangeState(State.Results);
			break;
		}
	}

	public void OnReady()
	{
		ChangeState(State.Input);
	}
	
	public void OnListen()
	{
		ChangeState(State.Listen);
	}
	
	public void OnReplay()
	{
		ChangeState(State.Countdown);
	}
	
	public void OnNext()
	{
		ChangeState(State.Init);
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
			if (songIdx < NUM_OF_NOTES && songTimer <= 0)
			{
				source.Stop();
				int keyIdx = (int)songKeys[songIdx];
				source.clip = audioClips[keyIdx]; 
				source.Play();
				songTimer = NOTE_DURATION;
				songIdx++;
			}
			songTimer -= Time.deltaTime;
			if (songIdx >= NUM_OF_NOTES && songTimer <= -2)
				ChangeState(State.WaitReady);
			break;
		case State.WaitReady:
			break;
		case State.Input:
			break;
		case State.Results:
			if (resultsTimer >= NOTE_DURATION && resultsIdx < NUM_OF_NOTES)
			{
				if (songKeys[resultsIdx] == inputKeys[resultsIdx])
					resultsPoints++;
				resultsTimer = 0;
				resultsIdx++;
			}
			resultsTimer += Time.deltaTime;
			text.text = resultsPoints.ToString() + " correct!";
			break;
		}
	}
}
