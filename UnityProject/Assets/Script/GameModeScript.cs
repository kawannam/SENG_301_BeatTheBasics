using UnityEngine;
using System.Collections;

public class GameModeScript : MonoBehaviour {

	protected IGameManagerScript gameManager;
	protected Difficulty difficulty;

	public void SetManager(IGameManagerScript paramGame)
	{
		gameManager = paramGame;
	}

	public void SetDifficulty(Difficulty paramDiff)
	{
		difficulty = paramDiff;
	}
}
