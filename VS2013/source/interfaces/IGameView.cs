using System.Collections;
using System.Collections.Generic;

namespace PianoGame
{
    public interface IGameView
    {
        void DisableKeyboard();
        void EnableKeyboard();
        void Update(IGameModel paramModel);
    }
}