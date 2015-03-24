using System.Collections;
using System.Collections.Generic;

namespace PianoGame
{
    public interface IKeyboardModel
    {
        KeyState[] CurrKeyStates { get; }
        KeyState[] PrevKeyStates { get; }
        SoundFile[] AudioClips { get; }
        SoundSource[] AudioSources { get; }

        void InteractPianoKey(PianoKey paramKey, bool paramState);
        void AddObserver(IKeyboardView paramView);
        void RemoveObserver(IKeyboardView paramView);
        void NotifyObservers();
    }
}