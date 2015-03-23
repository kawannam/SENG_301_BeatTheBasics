using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoGame
{
    public class Game : IGameModel
    {
        enum GameMode
        {
            SheetMusicTutor,
            PlayByEar,
            RhythmTutor,
            FreePlayMode,
            ProgressTracker
        }

        /*currentMode
          
        SheetMusicTutor
        PlayByEar
        RhythmTutor
        FreePlayMode
        ProgressTracker*/
        
        // public Menu menu;
        // dont want all every control action...... 
        // every control action
        /* 
         * send to current mode, ANY input.
         * have deal with it by.. switch? there would be alot..    keyboardkey. on/off + which key
         * can we reuse the keyboard?
         * 
         * control -> InteractKeys
         * currentMode.InteractKeys
         * currentMode.InteractMenu
         * 
         * this would send play by ear keyboard strokes.
         * and keyboard keybard strokes..
         * book navigations only go to free play mode.
         * 
         * it'd be nice if. organized by mode so free play only had control functions for keyboard and the menu.
         * 
         * keyboard piano keys.   recieved by modes.
         * change mode action.
         * book menu navigation [left right accept]   recieved by modes.
         * metronome adjustments
         */

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

    }
}
