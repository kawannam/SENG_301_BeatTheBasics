using System.Collections;
using System.Collections.Generic;

namespace PianoGame
{
    public interface IKeyboardView
    {
        void DisableKeyboard();
        void EnableKeyboard();
        void Update(IKeyboardModel paramModel);
    }
}