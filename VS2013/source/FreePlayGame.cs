using System.Collections;
using System.Collections.Generic;

public class FreePlayGame : IGameModel
{	
	private ArrayList aList = new ArrayList();

	private AudioClip[] audioClipList = new AudioClip[]{
			new AudioClip("Sounds/A-Note", 1),
			new AudioClip("Sounds/A#-Note",1),
			new AudioClip("Sounds/B-Note", 1),
			new AudioClip("Sounds/C-Note", 1),
			new AudioClip("Sounds/C#-Note",1),
			new AudioClip("Sounds/D-Note", 1),
			new AudioClip("Sounds/D#-Note",1),
			new AudioClip("Sounds/E-Note", 1),
			new AudioClip("Sounds/F-Note", 1),
			new AudioClip("Sounds/F#-Note",1),
			new AudioClip("Sounds/G-Note", 1),
			new AudioClip("Sounds/G#-Note",1),
			new AudioClip("Sounds/A-Note", 2),
			new AudioClip("Sounds/A#-Note",2),
			new AudioClip("Sounds/B-Note", 2),
			new AudioClip("Sounds/C-Note", 2),
			new AudioClip("Sounds/C#-Note",2),
			new AudioClip("Sounds/D-Note", 2),
			new AudioClip("Sounds/D#-Note",2),
			new AudioClip("Sounds/E-Note", 2),
			new AudioClip("Sounds/F-Note", 2),
			new AudioClip("Sounds/F#-Note",2),
			new AudioClip("Sounds/G-Note", 2),
			new AudioClip("Sounds/G#-Note",2)
	};
	
	private KeyState[] currKeyStates = new KeyState[(int)PianoKey.MAX];
	private KeyState[] prevKeyStates = new KeyState[(int)PianoKey.MAX];
	
	public AudioClip[] AudioClipList{ get{ return audioClipList; } }
	public KeyState[] KeyAudioStates{ get{ return currKeyStates; } }

	public KeyState[] CurrKeyStates{ get{ return currKeyStates; } }
	public KeyState[] PrevKeyStates{ get{ return currKeyStates; } }

	public FreePlayGame()
	{	
	}

	public void AddObserver(IGameView paramView)
	{
		aList.Add(paramView);
	}

	public void RemoveObserver(IGameView paramView)
	{
		aList.Remove(paramView);
	}

	public void NotifyObservers()
	{
		foreach(IGameView view in aList)
			view.Update(this);
	}
	
	public void Press(PianoKey paramKey)
	{
		int keyIdx = (int)paramKey;
		prevKeyStates[keyIdx] = currKeyStates[keyIdx];
		currKeyStates[keyIdx] = KeyState.Pressed;
		NotifyObservers();
	}

	public void Release(PianoKey paramKey)
	{
		int keyIdx = (int)paramKey;
		prevKeyStates[keyIdx] = currKeyStates[keyIdx];
		currKeyStates[keyIdx] = KeyState.Released;
		NotifyObservers();
	}
}
