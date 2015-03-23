using System.Collections;
using System.Collections.Generic;

namespace PianoGame
{
    public enum MenuAction
    {
        FreePlay,
        RhythmTutor,
        SheetMusic,
        PlayByEar,
        ProgressTracker,

        Ready,
        ListenAgain,
        Replay,
        Prev,
        Next,
        Menu,
    }

    public interface IGameControl
    {
        void InteractMenu(MenuAction paramAction);
        void InteractPianoKey(PianoKey paramKey, KeyState paramState);
        void SetModel(IGameModel paramModel);
        void SetView(IGameView paramView);
    }
}