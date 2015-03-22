using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IGameModel
{
	KeyState[] CurrKeyStates{ get; }
	KeyState[] PrevKeyStates{ get; }
	BBAudioClip[] AudioClipList{ get; }

	void Press(PianoKey paramKey);
 	void Release(PianoKey paramKey);
	void AddObserver(IGameView paramView);
	void RemoveObserver(IGameView paramView);
	void NotifyObservers();
}
