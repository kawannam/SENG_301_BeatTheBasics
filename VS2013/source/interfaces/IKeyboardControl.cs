using System.Collections;
using System.Collections.Generic;

namespace PianoGame
{
    public interface IKeyboardControl : IControl
    {
        void InteractPianoKey(PianoKey paramKey, KeyState paramState);
    }
}