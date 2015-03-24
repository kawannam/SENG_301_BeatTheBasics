using System.Collections;
using System.Collections.Generic;

namespace PianoGame
{
    public interface IKeyboardModel
    {
        KeyState[] CurrKeyStates { get; }
        KeyState[] PrevKeyStates { get; }
        AudioClip[] AudioClips { get; }
        AudioSource[] AudioSources { get; }

        void InteractPianoKey(PianoKey paramKey, KeyState paramState);
        void AddObserver(IKeyboardView paramView);
        void RemoveObserver(IKeyboardView paramView);
        void NotifyObservers();
    }
}