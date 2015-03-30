using UnityEngine;
using System.Collections;

public class DifficultyMenuScript : GameModeScript {

	public void OnSelect(int paramDiff)
	{
		gameManager.OnDifficultySelect((Difficulty)paramDiff);
	}
}
