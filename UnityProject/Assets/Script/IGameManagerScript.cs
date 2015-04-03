using UnityEngine;
using System.Collections;

public interface IGameManagerScript		// an interface that GameModeScript's can use to access game manager functions
{
	PianoKeyboardScript GetKeyboard();
	void ChangeState(GameManagerState paramState);
	void OnDifficultySelect(Difficulty paramDiff);
	void EnableKeyboard();
	void DisableKeyboard();
	void HideKeyboard ();
}
