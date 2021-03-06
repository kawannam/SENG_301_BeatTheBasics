﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayByEarScript : GameModeScript, IPianoKeyboardObserver {

	public enum State	// internal states of the PlayByEarScript
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

	//Sets the number of note based on difficulty
	//Displays the piano on screen
	public void Start () 
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

		piano = GameObject.FindGameObjectWithTag("PianoKeyBoard").GetComponent<PianoKeyboardScript>();	// locate the piano keyboard object
		piano.observers.Add(this);										// get notified when a piano key is pressed
		audioClips = new AudioClip[Constants.PIANO_NUM_KEYS];			// load the piano sound clips
		for (int i = 0; i < Constants.PIANO_NUM_KEYS; i++)
			audioClips[i] = Resources.Load<AudioClip>(Constants.PIANO_SOUND_FILES[i]);
	
		ChangeState(State.Init);
	}

	//This changes the state based on what the current state is
	//Displays the correct screen
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
			ChangeState(State.Countdown);
			break;
		case State.Countdown:
			if (gameManager != null) 
				gameManager.DisableKeyboard();
			RemoveStarDisplay();
			sheetMusic.Reset();
			lowerText.enabled = true;
			upperText.enabled = true;
			menu_1.SetActive(false);
			menu_2.SetActive(false);
			upperText.text = "Get Ready";
			countdown = 3;
			break;
		case State.Listen:
			if (gameManager != null) 
				gameManager.DisableKeyboard();
			upperText.text = "Listen to the notes";
			upperText.enabled = true;
			lowerText.enabled = false;
			menu_1.SetActive(false);
			menu_2.SetActive(false);
			songIdx = 0;
			songTimer = 0;
			break;
		case State.Input:
			if (gameManager != null) 
				gameManager.EnableKeyboard();
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
			lowerText.enabled = false;
			RegisterScore((int)((float)resultsPoints / NUM_OF_NOTES * Constants.MAX_STARS));
			break;
		}
	}

	/* OnPianoKeyDown - Will check if the user input is correct, invoked by the keyboard object when a keypress is made
	 * Will add a red note if input is wrong or green note if input is correct
	*/
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
			sheetMusic.AddNote(new SheetMusicNote(NoteType.Whole, paramKey), noteClr);
			inputIdx++;
			break;
		}
	}

	public void OnListen()
	{
		ChangeState(State.Listen);		// listen to the notes again
	}

	//The button to reattempt the last level
	public void OnReplay()
	{
		ChangeState(State.Countdown);	// play same note again, go the start
	}

	//Resets the game to the next level/group of notes
	public void OnNext()
	{
		ChangeState(State.Init);	// pick a new note, then play 
	}

	//Takes the user back to the main menu
	public new void OnMenu()
	{
		piano.observers.Remove(this);
		gameManager.ChangeState(GameManagerState.Menu);
	}

	/* Update - Game logic loop, gets called every frame 
	 * This is called to actually run the countdown
	 * And to actually play the notes to the user
	 * And to actually collect input
	 * One at a time in the above order
	 */
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
			if (songIdx < NUM_OF_NOTES && songTimer <= 0)		// if we have not played all the notes yet
			{
				source.Stop();
				int keyIdx = (int)songKeys[songIdx];
				source.clip = audioClips[keyIdx]; 
				source.Play();
				songTimer = NOTE_DURATION;
				songIdx++;
			}
			songTimer -= Time.deltaTime;
			if (songIdx >= NUM_OF_NOTES && songTimer <= -2)		// all notes played, go to input state
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
