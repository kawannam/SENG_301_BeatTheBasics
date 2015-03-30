using UnityEngine;
using System.Collections;

public interface IGameManagerScript
{
	PianoKeyboardScript GetKeyboard();
	void ChangeState(GameManagerState paramState);
	void OnDifficultySelect(Difficulty paramDiff);
}

public enum Difficulty
{
	Easy,
	Medium,
	Hard
}

public enum GameManagerState
{
	StartUp,
	Menu,
	TableOfContents,
	PlayByEar,
	RhythmTutor,
	SightReading,
	Metronome,
	StickerBook
}

public class GameManagerScript : MonoBehaviour, IGameManagerScript 
{
	private GameManagerState state;
	private DifficultyMenuScript difficultyMenu;

	public GameObject pianoPrefab;
	public GameObject menuPrefab;
	public GameObject difficultyPrefab;
	public GameObject metronomePrefab;

	// game mode prefabs
	public GameObject playByEarPrefab;
	public GameObject rhythmPrefab;
	public GameObject sightPrefab;
	public GameObject stickerPrefab;

	private GameObject currentObj;
	private PianoKeyboardScript pianoKeyboard;

	public PianoKeyboardScript GetKeyboard()
	{ 
		return pianoKeyboard;
	}

	// Use this for initialization
	void Start () {
		ChangeState(GameManagerState.Menu);
	}

	void ExitState(GameManagerState paramState)
	{
		Destroy(currentObj);
		switch(paramState)
		{
		case GameManagerState.StartUp:
			GameObject gameObj = (GameObject)GameObject.Instantiate(pianoPrefab);
			pianoKeyboard = gameObj.GetComponent<PianoKeyboardScript>();
			break;
		}
	}

	public void OnDifficultySelect(Difficulty paramDiff)
	{
		Destroy(currentObj);
		currentObj = (GameObject)GameObject.Instantiate(playByEarPrefab);
		GameModeScript gms = currentObj.GetComponent<GameModeScript>();
		gms.SetDifficulty(paramDiff);
		gms.SetManager(this);
	}

	public void ChangeState(GameManagerState paramState)
	{
		ExitState(state);
		switch(paramState)
		{
		case GameManagerState.StickerBook:
			currentObj = (GameObject)GameObject.Instantiate(stickerPrefab);
			break;
		case GameManagerState.Metronome:
			currentObj = (GameObject)GameObject.Instantiate(metronomePrefab);
			break;
		case GameManagerState.Menu:
			currentObj = (GameObject)GameObject.Instantiate(menuPrefab);
			break;
		case GameManagerState.SightReading:
		case GameManagerState.RhythmTutor:
		case GameManagerState.PlayByEar:
		default:
			currentObj = (GameObject)GameObject.Instantiate(difficultyPrefab);
			break;
		}
		GameModeScript mode = currentObj.GetComponent<GameModeScript>();
		mode.SetManager(this);

		state = paramState;
	}
}
