using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoGame
{
    public class Game : IGameModel
    {        
        private ArrayList aList = new ArrayList();
        private KeyboardModel keyboard;        

        public Game ()
        {
            keyboard = new KeyboardModel();
        }

        public void Update(float elapsedTime)
        {

        }
    }
}
