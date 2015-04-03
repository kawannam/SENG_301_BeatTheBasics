using UnityEngine;
using System.Collections;

//Difficulty settings
public enum Difficulty
{
	Easy,
	Medium,
	Hard
}

//Game features
public enum GameManagerState
{
	StartUp,		// game begins in this state
	Menu,
	TableOfContents,
	PlayByEar,
	ClapBack,
	SightReading,
	Metronome,
	StickerBook
}

/* GameManagerScript - handles the loading/switching of game modes, and holds a reference to the game keyboard */
public class GameManagerScript : MonoBehaviour, IGameManagerScript 
{
	private GameManagerState state;
	private DifficultyMenuScript difficultyMenu;

	public GameObject pianoPrefab;			// game keyboard prefab
	public GameObject menuPrefab;
	public GameObject difficultyPrefab;		// difficulty menu prefab
	public GameObject metronomePrefab;		

	// game mode prefabs
	public GameObject playByEarPrefab;
	public GameObject rhythmPrefab;
	public GameObject sightPrefab;
	public GameObject stickerPrefab;
	public GameObject tableOfContentsPrefab;
	
	private GameObject currentObj;
	private GameObject postDifficultyPrefab;	// which prefab to spawn after choosing a difficulty
	private GameModeType postDifficultyMode;	// what the difficulty of the game mode should be, after spawning
	private PianoKeyboardScript pianoKeyboard;	// the game keyboard the user interacts with

	public PianoKeyboardScript GetKeyboard()
	{ 
		return pianoKeyboard;
	}

	// Use this for initialization
	void Start () {
		ChangeState(GameManagerState.Menu);		// initialize the Menu
	}

	/* ExitState - Performs actions associated with leaving any particular state */
	void ExitState(GameManagerState paramState)
	{
		Destroy(currentObj);
		switch(paramState)
		{
		case GameManagerState.StartUp:		// if leaving the startup state, spawn the keyboard
			GameObject gameObj = (GameObject)GameObject.Instantiate(pianoPrefab);
			pianoKeyboard = gameObj.GetComponent<PianoKeyboardScript>();
			break;
		case GameManagerState.ClapBack:		// enable keyboard after clapback, since it would be disabled
			EnableKeyboard();
			break;
		}
	}

	/* OnDifficultySelect - After the user chooses a difficulty, loads the game mode, and sets the difficulty */
	public void OnDifficultySelect(Difficulty paramDiff)
	{
		Destroy(currentObj);
		currentObj = (GameObject)GameObject.Instantiate(postDifficultyPrefab);
		GameModeScript gms = currentObj.GetComponent<GameModeScript>();
		gms.SetModeType(postDifficultyMode);
		gms.SetDifficulty(paramDiff);
		gms.SetManager(this);
	}
	
	/* DisableKeyboard - Greys out the keyboard, and disables input */
	public void DisableKeyboard()
	{
		pianoKeyboard.spriteRenderer.color = Color.grey;
		pianoKeyboard.enabled = false;
	}

	public void HideKeyboard()
	{
		pianoKeyboard.spriteRenderer.color = new Color (0, 0, 0, 0);
		pianoKeyboard.enabled = false;
	}

	public void EnableKeyboard()
	{
		pianoKeyboard.spriteRenderer.color = Color.white;
		pianoKeyboard.enabled = true;
	}

	/* ChangeState - Performs any actions associated with changing the game state, 
	 * ie. instantiating a game object 
	 */
	public void ChangeState(GameManagerState paramState)
	{
		ExitState(state);	// first, do anything related to exiting the current state
		switch(paramState)
		{
		case GameManagerState.StickerBook:
			currentObj = (GameObject)GameObject.Instantiate(stickerPrefab);
			break;
		case GameManagerState.TableOfContents:
			currentObj = (GameObject)GameObject.Instantiate(tableOfContentsPrefab);
			break;
		case GameManagerState.Metronome:
			currentObj = (GameObject)GameObject.Instantiate(metronomePrefab);
			break;
		case GameManagerState.Menu:
			currentObj = (GameObject)GameObject.Instantiate(menuPrefab);
			break;
		case GameManagerState.SightReading:
			postDifficultyPrefab = sightPrefab;
			postDifficultyMode = GameModeType.SightReading;
			goto default;										// load difficulty choice menu
		case GameManagerState.ClapBack:
			postDifficultyPrefab = rhythmPrefab;
			postDifficultyMode = GameModeType.ClapBack;
			goto default;										// load difficulty choice menu
		case GameManagerState.PlayByEar:
			postDifficultyPrefab = playByEarPrefab;
			postDifficultyMode = GameModeType.PlayByEar;
			goto default;										// load difficulty choice menu
		default:
			currentObj = (GameObject)GameObject.Instantiate(difficultyPrefab);
			break;
		}
		GameModeScript mode = currentObj.GetComponent<GameModeScript>();	// every mode should inherit GameModeScript
		mode.SetManager(this);		// pass a reference to the game manager

		state = paramState;		// update the current state
	}
}
