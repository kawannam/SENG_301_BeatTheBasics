using UnityEngine;
using System.Collections;

public class DifficultyMenuScript : GameModeScript {

/* Logic for difficulty setting screen
 * Allows players to press a button to choose difficulty
 */
	public void OnSelect(int paramDiff)
	{
		gameManager.OnDifficultySelect((Difficulty)paramDiff);
	}
}
