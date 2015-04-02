using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SightReadingTutorScript : GameModeScript, IPianoKeyboardObserver 
{
	public enum State
	{
		Play,
		Result,
		Next
	}
	const int X_STEP = -75;

	public PianoKeyboardScript piano;
	public int[] musicScore;
	public int[] playerInput;
	public int beatNumber;
	public State state;
	public SheetMusicDisplayScript musicDisplay;
	public SheetMusicDisplayScript inputDisplay;
	public int points;
	public Text text;	
	public GameObject menuObj;

	//Questions for the different levels in SheetReadingTutor
	//These numbers corrispond to the notes that are displayed
	private int[] musicScore_easy = new int[]{
		14, 12, 11, 9, 7, 11};
	private int[] musicScore_medium = new int[]{
		14, 12, 11, 9, 7, 11, 12, 9, 11, 14, 14};
	private int[] musicScore_hard = new int[]{
		14, 12, 11, 9, 7, 11, 12, 9, 11, 14, 14, 16, 17, 19, 21, 17, 19};
	//For Example the hard question correlates to:
	//MIDDLE D C B A G B C A B // TREBLE MIDDLE D D E F G A F G

/* Initializes SightReadingTutor
 * Checks difficulty and sets the question accordingly
 * Gets the keyboard
 * Gets input from the keyboard and changes the state to Play
 */
	void Start () 
	{
		switch(difficulty)
		{
		case Difficulty.Easy:
			musicScore = musicScore_easy;
			break;
		case Difficulty.Medium:			
			musicScore = musicScore_medium;
			break;
		case Difficulty.Hard:			
			musicScore = musicScore_hard;
			break;
		}

		piano = GameObject.FindGameObjectWithTag("PianoKeyBoard").GetComponent<PianoKeyboardScript>();
		piano.observers.Add(this);
		ChangeState(State.Play);
	}

/* Checks what state the game is in
 * If the state is in Play, clear screen of the things we don't want,
 * 		get player input and initalize values to 0, reset menuDisplay
 * 		displays notes (The Question), draws players input on screen
 * If he state is Next, do nothing
 * If the state is Result, get menu, display stars,
 * 		write a message to user, save score
 */
	void ChangeState(State paramState)
	{
		switch(paramState)
		{
		case State.Play:
			RemoveStarDisplay();
			menuObj.SetActive(false);
			text.enabled = false;
			playerInput = new int[musicScore.Length];
			beatNumber = 0;
			points = 0;
			musicDisplay.Reset();

			for (int i = 0; i < musicScore.Length; i++)
				musicDisplay.AddNote(new SheetMusicNote(NoteType.Quarter, (PianoKey)musicScore[i]), Color.black);

			inputDisplay.Reset();
			break;
		case State.Next:
			break;
		case State.Result:
			menuObj.SetActive(true);
			int numStars = (int)(((float)points / musicScore.Length) * Constants.MAX_STARS);
			text.enabled = true;
			text.text = string.Format("{0} Stars!", numStars);
			RegisterScore(numStars);
			break;
		}
		state = paramState;
	}

	//Updates the state
	public void OnNext()
	{
		ChangeState(State.Play);
	}
	//Updates the state
	public void OnReplay()
	{
		ChangeState(State.Play);
	}

	//Goes to main menu
	public void OnQuit()
	{
		gameManager.ChangeState(GameManagerState.Menu);
	}

/* Prints the inputted note on the screen 
 * Checks if player input is correct
 * Colours the note depending on the correctness
 * Draws Note
 * Updates points
 * Changes the states to Result
 */
	public void OnPianoKeyDown(PianoKey paramKey)
	{
		if (state == State.Play)
		{
			Color noteClr = Color.green;
			if (beatNumber < playerInput.Length)
			{
				playerInput[beatNumber] = (int)paramKey;	
				if (playerInput[beatNumber] == musicScore[beatNumber])
				{
					//print correct to screen
					points++;
				}
				else
				{
					noteClr = Color.red;
					//print player input + wrong
				}
			}
			inputDisplay.AddNote(new SheetMusicNote(NoteType.Quarter, paramKey), noteClr);
			beatNumber++;		
			if (beatNumber >= musicScore.Length)
				ChangeState(State.Result);
			else
			{
				inputDisplay.ShiftDisplay(X_STEP);
				musicDisplay.ShiftDisplay(X_STEP);
			}
		}
	}

	// Update is called once per frame
	void Update () 
	{	
		/*switch (state) 
		{
		case State.Play:
			{
				state = State.Result;
				beatNumber = 0;
				break;
			}
			break;
		case State.Result:
			//option to retry or exit
			break;
		}//switch*/
	}
}
