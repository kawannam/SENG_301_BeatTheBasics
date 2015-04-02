using UnityEngine;
using System.Collections;

public class DifficultyMenuScript : GameModeScript {

	public void OnSelect(int paramDiff)
	{
		gameManager.OnDifficultySelect((Difficulty)paramDiff);		// will spawn the game mode, and set the difficulty
	}
}
