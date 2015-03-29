using UnityEngine;
using System.Collections;

public class DifficultyMenuScript : GameModeScript {

	public void OnSelect(Difficulty paramDiff)
	{
		gameManager.ChangeState(GameManagerState.DifficultyDone);
	}
}
