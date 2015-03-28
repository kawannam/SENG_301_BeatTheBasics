using UnityEngine;
using System.Collections;

public interface IGameManagerScript
{
	PianoKeyboardScript GetKeyboard();
	void ChangeState(GameManagerState paramState);
}

public enum GameManagerState
{
	StartUp,
	Menu,
	FreePlay,
	PlayByEar
}

public class GameManagerScript : MonoBehaviour, IGameManagerScript 
{
	GameManagerState state;

	public GameObject pianoPrefab;
	public GameObject menuPrefab;
	public GameObject playByEarPrefab;

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

	public void ChangeState(GameManagerState paramState)
	{
		ExitState(state);
		switch(paramState)
		{
		case GameManagerState.Menu:
			currentObj = (GameObject)GameObject.Instantiate(menuPrefab);
			break;
		case GameManagerState.PlayByEar:
			currentObj = (GameObject)GameObject.Instantiate(playByEarPrefab);
			break;
		}
		GameModeScript mode = currentObj.GetComponent<GameModeScript>();
		mode.SetManager(this);

		state = paramState;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
