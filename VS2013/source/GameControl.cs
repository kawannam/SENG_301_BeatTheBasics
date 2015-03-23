using System.Collections;

namespace PianoGame
{
    public class GameControl : IGameControl
    {
        private IGameModel model;
        private IGameView view;

        public GameControl()
        {
        }

        public GameControl(IGameModel paramModel, IGameView paramView)
        {
            model = paramModel;
            view = paramView;
        }

        public void InteractMenu(MenuAction paramAction)
        {
        }

        public void InteractPianoKey(PianoKey paramKey, KeyState paramState)
        {
            if (model != null)
                model.InteractPianoKey(paramKey, paramState);
        }

        public void SetModel(IGameModel paramModel)
        {
            model = paramModel;
        }

        public void SetView(IGameView paramView)
        {
            view = paramView;
        }
    }
}