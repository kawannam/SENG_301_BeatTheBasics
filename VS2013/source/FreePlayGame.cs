using System.Collections;
using System.Collections.Generic;

namespace PianoGame
{
    public class Keyboard : IGameModel
    {
        private ArrayList aList = new ArrayList();
        private AudioSource[] audioSources;
        
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

        public AudioClip[] AudioClips { get { return audioClipList; } }
        public AudioSource[] AudioSources { get { return audioSources; } }

        public KeyState[] CurrKeyStates { get { return currKeyStates; } }
        public KeyState[] PrevKeyStates { get { return prevKeyStates; } }

        public Keyboard()
        {
            audioSources = new AudioSource[audioClipList.Length];
            for (int i = 0; i < audioClipList.Length; i++)
            {
                AudioClip ac = audioClipList[i];
                audioSources[i] = new AudioSource(ac);
            }
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
            foreach (IGameView view in aList)
                view.Update(this);
        }

        public void InteractPianoKey(PianoKey paramKey, KeyState paramState)
        {
            int keyIdx = (int)paramKey;
            prevKeyStates[keyIdx] = currKeyStates[keyIdx];
            currKeyStates[keyIdx] = paramState;
            audioSources[keyIdx].IsPlaying = (paramState == KeyState.Pressed) ? true : false;
            NotifyObservers();
        }
    }
}