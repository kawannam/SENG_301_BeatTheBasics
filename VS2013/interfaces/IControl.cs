using System.Collections;
using System.Collections.Generic;

namespace PianoGame
{
    public interface IControl
    {
        void SetModel(IKeyboardModel paramModel);
        void SetView(IKeyboardView paramView);
    }
}