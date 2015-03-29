using UnityEngine;
using System.Collections;

public interface IGameManagerScript
{
	PianoKeyboardScript GetKeyboard();
	void ChangeState(GameManagerState paramState);
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
	FreePlay,
	PlayByEar,
	ChooseDifficulty,
	DifficultyDone
}

public class GameManagerScript : MonoBehaviour, IGameManagerScript 
{
	private GameManagerState state;
	private GameManagerState nextState;
	private Difficulty difficulty;

	public GameObject pianoPrefab;
	public GameObject menuPrefab;
	public GameObject playByEarPrefab;
	public GameObject difficultyPrefab;

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
		difficulty = paramDiff;
		ChangeState(nextState);
	}

	public void ChangeState(GameManagerState paramState)
	{
		ExitState(state);
		switch(paramState)
		{
		case GameManagerState.Menu:
			currentObj = (GameObject)GameObject.Instantiate(menuPrefab);
			break;
		case GameManagerState.ChooseDifficulty:
			currentObj = (GameObject)GameObject.Instantiate(difficultyPrefab);
			break;
		case GameManagerState.DifficultyDone:			
			break;
		default:
			if (state != GameManagerState.DifficultyDone)
			{
				nextState = paramState;
				ChangeState(GameManagerState.ChooseDifficulty);
				return;
			}
			else
			{
			}
			break;
		}
		GameModeScript mode = currentObj.GetComponent<GameModeScript>();
		mode.SetManager(this);

		state = paramState;
	}
}
