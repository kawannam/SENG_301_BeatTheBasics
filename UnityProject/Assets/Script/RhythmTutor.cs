/*
Last Updated: April 1, 2015
Description: Clap back/Rhythm tutor game. The game has 3 states or scenes: Listen, Playback, and Result.
-Listen plays the user a rhythm then allows the user to repeat (re-hear) the rhythm or play back the rhythm
-Playback is where the user plays back the rhythm to the best of their abilities
-Result displays the player's score (correct and incorrect beats), stars, and gives the player the option
to return to the menu, try the next difficulty, or replay the same rhythm again
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RhythmTutor : GameModeScript {

	//VARIABLES

	const float MARGIN_OF_ERROR = 0.10f;//0.1 second margin of error (before and after beat)
	const int row1_y = 65;
	const int y_offset = 100;
	private Vector3 starPosition = new Vector3(0, 160, 0);//(x,y,z): x,z = origin; y = upper part of the screen
	public bool played;//has a note been played in this time interval
	public bool isActive;//start recording the player's input	
	public float timeLine;//keep track of when to play beats and display text/buttons
	public float changeBeat;//What time to change the beat
	public int beatNumber;
	public int wrong;
	public int notes_y;//y position of the notes
	public float[] rhythmMap;
	public float[] rhythmMapHard;
	public float[] rhythmMapEasy;
	public float[] rhythmMapMed;
	public int[] mapScore;

	//Game states
	public enum State
	{
		Listen,
		Playback,
		Result
	}
	public State state;

	//GAME OBJECTS, SOUNDS, AND TEXT

	public GameObject quarterNotePrefab;
	public GameObject listenObject;
	public GameObject playObject;
	public GameObject scoreObject;
	public GameObject buttons1;
	public Text countdownText;
	public Transform noteGroup1;
	public AudioSource source;

	//BUTTONS

	//Ready button
	public void OnReady ()
	{
		ChangeState(State.Playback);
	}

	//Repeat button
	public void OnRepeat()
	{
		ChangeState (State.Listen);
	}

	//Replay button
	public void OnReplay()
	{
		ChangeState (State.Listen);
	}

	//Next button
	public void OnNext()
	{
		int diff = (int)difficulty;
		diff++;
		diff = diff % Constants.NUM_OF_DIFFICULTY;
		SetDifficulty ((Difficulty)diff);
		ChangeState (State.Listen);
	}

	//FUNCTIONS

	//Calculates the number of wrong beats played
	public int NumWrong()
	{
		int wrong = 0;
		for (int i = 0; i < mapScore.Length; i++) 
		{
			if (mapScore[i] == 0)
				wrong++;
		}
		return wrong;
	}

	//Calculates and displays the number of stars earned
	public void NumStars()
	{
		wrong = NumWrong();
		if(wrong > 2)
			RegisterScore(0, starPosition);
		else if(wrong > 1)
			RegisterScore(1, starPosition);
		else if(wrong > 0)
			RegisterScore(2, starPosition);
		else
			RegisterScore(3, starPosition);
	}

	//Displays the player's score: green = correct, red = wrong
	public void DisplayNotes()
	{
		//Initialize variables
		notes_y = row1_y;
		beatNumber = 0;

		//Loop once per row of notes displayed
		for(int i = 0; i < 2; i++)
		{
			int count = 1;

			//Exit condition
			if(beatNumber >= mapScore.Length)
				count = 9;

			//Print 8 notes per row
			while(count < 9)
			{
				GameObject note = (GameObject)GameObject.Instantiate(quarterNotePrefab);
				note.transform.SetParent(noteGroup1);
				Vector3 pos = note.transform.localPosition;
				pos.x += (100 * count);
				pos.y = notes_y;
				note.transform.localPosition = pos;
				Image noteImg = note.GetComponent<Image>();

				//Print a red note for an incorrect input, and a green note for a correct input
				if(mapScore[beatNumber] == 0)
					noteImg.color = Color.red;
				else
					noteImg.color = Color.green;
				count++;
				beatNumber++;
				if(beatNumber >= mapScore.Length)
					count = 9;//quit loop
			}
			//Move down a row
			notes_y -= y_offset;
		}
	}

	//Changes the game state and initializes the settings/variables for each state
	public void ChangeState(State paramState)
	{
		switch (paramState) 
		{
			//Listen state initial settings
			case State.Listen:

			//Set the proper scene and temporarily hide the buttons
			listenObject.SetActive(true);
			playObject.SetActive (false);
			scoreObject.SetActive (false);
			buttons1.SetActive(false);

			//Clear the keyboard, stars, and notes from the screen
			gameManager.HideKeyboard();
			RemoveStarDisplay();
			List<GameObject> children = new List<GameObject>();
			foreach (Transform child in noteGroup1.transform) 
				children.Add(child.gameObject);
			children.ForEach(child => Destroy(child));

			//Set the correct rhythm map to be played
			if (difficulty == Difficulty.Easy)
				rhythmMap = rhythmMapEasy;
			else if (difficulty == Difficulty.Medium)
				rhythmMap = rhythmMapMed;
			else if (difficulty == Difficulty.Hard)
				rhythmMap = rhythmMapHard;
			mapScore = new int[rhythmMap.Length];

			//Initialize the player's score to 0, and initialize the variables
			beatNumber = 0;
			isActive = false;
			while(beatNumber < rhythmMap.Length)
			{
				mapScore[beatNumber] = 0;
				beatNumber++;
			}
			beatNumber = 0;
			timeLine = -3;
			countdownText.text = "3";
			break;
		
		//Playback state initial settings
		case State.Playback:

			//Set the proper scene
			listenObject.SetActive(false);
			playObject.SetActive (true);
			scoreObject.SetActive (false);

			//Initialize the variables
			timeLine = 0;
			beatNumber = 0;
			played = false;
			break;
		
		//Result state initial settings
		case State.Result:

			//Set the proper scene, display the stars, and display the player's results
			listenObject.SetActive(false);
			playObject.SetActive (false);
			scoreObject.SetActive (true);
			NumStars ();
			DisplayNotes();
			break;
		}
		//Change the state
		state = paramState;
	}

	// Use this for initialization
	void Start () 
	{
		played = false;//The player has not played yet

		//Initialize the rhythm maps for each difficulty
		//Rhythm maps hold the time in seconds when a beat should be played
		rhythmMapHard = new float[]{
			0f, 0.25f, 0.5f, 1f, 1.5f, 1.75f, 2f, 2.25f, 2.5f, 3.5f, 4f, 4.5f};//12 notes
		//Eighth eighth quarter quarter eighth eighth eighth eighth half quarter quarter whole
		rhythmMapEasy = new float[]{
		0f, 0.5f, 1f, 2f, 2.5f, 3f};//6 notes
		//Quarter quarter half quarter quarter half
		rhythmMapMed = new float[]{
		0f, 0.25f, 0.5f, 1f, 1.25f, 2.75f, 3f};//7 notes
		//Eighth eighth quarter eighth 3/4 note eighth whole

		//Start the game by changing to the listen state and playing the beat to the player
		ChangeState (State.Listen);
	}

	// Update is called once per frame
	void Update () 
	{
		//What to do on each screen after initialization
		switch(state)
		{
		//What to do on the Listen state
		case State.Listen:
			//Display the countdown before the rhythm is played to the user
			if(timeLine >= -2 && timeLine < -1)
				countdownText.text = "2";
			else if(timeLine >= -1 && timeLine < 0)
				countdownText.text = "1";
			else if(timeLine >= 0)
				countdownText.text = "Listen to the Beat!";

			//After the rhythm is finished playing display the buttons and wait for user button selection
			if(beatNumber >= rhythmMap.Length)
			{
				buttons1.SetActive(true);
				break;
			}

			//Play the rhythm to be repeated to the user
			if (timeLine >= rhythmMap[beatNumber])
			{
				source.Play();
				beatNumber++;
			}
			timeLine += Time.deltaTime;
			break;

		//What to do in the Playback state
		case State.Playback:
			bool click = Input.GetMouseButtonDown(0); //Mouse button input

			//Start recording user input once they start clicking
			if(click)
				isActive = true;

			//What to do if the player clicked within the margin of error
			if(timeLine < (rhythmMap[beatNumber] + MARGIN_OF_ERROR) && timeLine > (rhythmMap[beatNumber] - MARGIN_OF_ERROR))
			{
				if(click)
				{
					//If the player already clicked once before during the margin of error
					//for a note then change their score to wrong for the current note
					//(This is to prevent spam clicking)
					if(played)
					{
						mapScore[beatNumber] = 0;
					}
					else
					{
						played = true;
						mapScore[beatNumber] = 1;
					}
				}
			}

			//If the player clicked outside the margin of error mark their score as incorrect for the current note
			else
			{
				if(click)
				{
					played = true;
					mapScore[beatNumber] = 0;
				}
			}

			//Check if it's time to change the beat number
			//If it is one second past the final beat, go to the result screen
			if(beatNumber == (rhythmMap.Length - 1))
			{
				if(timeLine >= (rhythmMap[rhythmMap.Length-1] + 1))
				{
					ChangeState(State.Result);
					break;
				}
			}
			//If its not the last beat, switch to the next beat if its past the designated time
			else
			{
				changeBeat = rhythmMap[beatNumber] + ((rhythmMap[beatNumber + 1] - rhythmMap[beatNumber])/2);
				if(timeLine >= changeBeat)
				{
					played = false;
					beatNumber++;
				}
			}

			//Once the user started playing, start running the time to check if the user's input matches the beat time
			if(isActive == true)
				timeLine += Time.deltaTime;
			break;

		//Wait for the user to press a button
		case State.Result:
			break;
		}//End of switch
	}//End of update
}//End of rhythm tutor/clap-back
