using System.Collections;
using System.Collections.Generic;

namespace PianoGame
{
    public class KeyboardControl : IKeyboardControl
    {
        IKeyboardView view;
        IKeyboardModel model;

        public void SetView(IKeyboardView paramView)
        {
            view = paramView;
        }

        public void SetModel(IKeyboardModel paramModel)
        {
            model = paramModel;
        }

        public void InteractPianoKey(PianoKey paramKey, bool paramState)
        {
            model.InteractPianoKey(paramKey, paramState);
        }
    }
}