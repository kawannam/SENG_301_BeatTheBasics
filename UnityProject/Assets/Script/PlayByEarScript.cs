using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayByEarScript : GameModeScript, IPianoKeyboardObserver {

	public enum State
	{
		Init,
		Countdown,
		Listen,		
		Input,
		Results
	}
	
	private const float NOTE_DURATION = 1f;

	public int NUM_OF_NOTES = 3;
	public AudioClip[] audioClips;
	public AudioSource source;
	public State state;
	public float countdown;

	public SheetMusicDisplayScript sheetMusic;

	// tune playing
	public PianoKey[] songKeys;
	public int songIdx;
	public float songTimer;

	// user input
	public PianoKey[] inputKeys;
	public int inputIdx;

	// results 
	public int resultsPoints;

	// related scene objects
	public Text upperText;
	public Text lowerText;
	public GameObject menu_1; 
	public GameObject menu_2; 
	private PianoKeyboardScript piano;

	// Use this for initialization
	void Start () 
	{		
		switch (difficulty)
		{
		case Difficulty.Easy:
			NUM_OF_NOTES = 1;
			break;
		case Difficulty.Medium:
			NUM_OF_NOTES = 2;
			break;
		case Difficulty.Hard:
			NUM_OF_NOTES = 3;
			break;
		}

		piano = GameObject.FindGameObjectWithTag("PianoKeyBoard").GetComponent<PianoKeyboardScript>();
		piano.observers.Add(this);
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
			/*songKeys[0] = PianoKey.H_A;
			songKeys[1] = PianoKey.H_As;
			songKeys[2] = PianoKey.H_B;*/
			ChangeState(State.Countdown);
			break;
		case State.Countdown:
			sheetMusic.Reset();
			lowerText.enabled = true;
			upperText.enabled = true;
			menu_1.SetActive(false);
			menu_2.SetActive(false);
			upperText.text = "Get Ready";
			countdown = 3;
			break;
		case State.Listen:
			upperText.text = "Listen to the notes";
			upperText.enabled = true;
			lowerText.enabled = false;
			menu_1.SetActive(false);
			menu_2.SetActive(false);
			songIdx = 0;
			songTimer = 0;
			break;
		case State.Input:
			upperText.text = "Which notes did you hear?";
			lowerText.enabled = false;
			upperText.enabled = true;
			menu_1.SetActive(true);
			menu_2.SetActive(false);
			inputKeys = new PianoKey[songKeys.Length];
			inputIdx = 0;
			resultsPoints = 0;
			break;
		case State.Results:
			menu_1.SetActive(false);
			menu_2.SetActive(true);

			upperText.enabled = false;
			lowerText.enabled = true;
			break;
		}
	}

	public void OnPianoKeyDown(PianoKey paramKey)
	{
		switch(state)
		{
		case State.Input:
			Color noteClr = Color.red;

			inputKeys[inputIdx] = paramKey;
			if (inputKeys[inputIdx] == songKeys[inputIdx])
			{
				noteClr = Color.green;
				resultsPoints++;
			}
			lowerText.text = resultsPoints.ToString() + " correct!";
			sheetMusic.AddNote(new SheetMusicNote(NoteType.Whole, paramKey), noteClr);
			inputIdx++;
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
		piano.observers.Remove(this);
		gameManager.ChangeState(GameManagerState.Menu);
	}
	
	void Update () 
	{
		switch(state)
		{
		case State.Countdown:
			countdown -= Time.deltaTime;
			lowerText.text = ((int)countdown + 1).ToString();
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
				ChangeState(State.Input);
			break;
		case State.Input:
			if (inputIdx >= songKeys.Length)
				ChangeState(State.Results);
			break;
		case State.Results:
			break;
		}
	}
}
