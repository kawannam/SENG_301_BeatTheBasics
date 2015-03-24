using System.Collections;
using System.Collections.Generic;

namespace PianoGame
{
    public class KeyboardModel : IKeyboardModel
    {
        private ArrayList aList = new ArrayList();
        private SoundSource[] audioSources;
        
        private SoundFile[] audioClipList = new SoundFile[]{
			new SoundFile("Sounds/A-Note", 1),
			new SoundFile("Sounds/A#-Note",1),
			new SoundFile("Sounds/B-Note", 1),
			new SoundFile("Sounds/C-Note", 1),
			new SoundFile("Sounds/C#-Note",1),
			new SoundFile("Sounds/D-Note", 1),
			new SoundFile("Sounds/D#-Note",1),
			new SoundFile("Sounds/E-Note", 1),
			new SoundFile("Sounds/F-Note", 1),
			new SoundFile("Sounds/F#-Note",1),
			new SoundFile("Sounds/G-Note", 1),
			new SoundFile("Sounds/G#-Note",1),
			new SoundFile("Sounds/A-Note", 2),
			new SoundFile("Sounds/A#-Note",2),
			new SoundFile("Sounds/B-Note", 2),
			new SoundFile("Sounds/C-Note", 2),
			new SoundFile("Sounds/C#-Note",2),
			new SoundFile("Sounds/D-Note", 2),
			new SoundFile("Sounds/D#-Note",2),
			new SoundFile("Sounds/E-Note", 2),
			new SoundFile("Sounds/F-Note", 2),
			new SoundFile("Sounds/F#-Note",2),
			new SoundFile("Sounds/G-Note", 2),
			new SoundFile("Sounds/G#-Note",2)
	};

        private KeyState[] currKeyStates = new KeyState[(int)PianoKey.MAX];
        private KeyState[] prevKeyStates = new KeyState[(int)PianoKey.MAX];

        public SoundFile[] AudioClips { get { return audioClipList; } }
        public SoundSource[] AudioSources { get { return audioSources; } }

        public KeyState[] CurrKeyStates { get { return currKeyStates; } }
        public KeyState[] PrevKeyStates { get { return prevKeyStates; } }
        
        public void AddObserver(IKeyboardView paramView)
        {
            aList.Add(paramView);
        }

        public void RemoveObserver(IKeyboardView paramView)
        {
            aList.Remove(paramView);
        }

        public void NotifyObservers()
        {
            foreach (IKeyboardView view in aList)
                view.Update(this);
        }
        public KeyboardModel()
        {
            audioSources = new SoundSource[audioClipList.Length];
            for (int i = 0; i < audioClipList.Length; i++)
            {
                SoundFile ac = audioClipList[i];
                audioSources[i] = new SoundSource(ac);
            }
        }

        public void InteractPianoKey(PianoKey paramKey, bool paramState)
        {
            int keyIdx = (int)paramKey;
            prevKeyStates[keyIdx] = currKeyStates[keyIdx];
            currKeyStates[keyIdx] = paramState ? KeyState.Pressed : KeyState.Released;
            audioSources[keyIdx].IsPlaying = paramState ? true : false;
            NotifyObservers();
        }
    }
}