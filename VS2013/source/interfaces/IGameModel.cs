using System.Collections;
using System.Collections.Generic;

public interface IGameModel
{
	KeyState[] CurrKeyStates{ get; }
    KeyState[] PrevKeyStates { get; }
    AudioClip[] AudioClips { get; }
    AudioSource[] AudioSources{ get; }

	void InteractPianoKey(PianoKey paramKey, KeyState paramState);
	void AddObserver(IGameView paramView);
	void RemoveObserver(IGameView paramView);
	void NotifyObservers();
}
