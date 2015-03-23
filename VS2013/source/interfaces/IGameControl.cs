using System.Collections;
using System.Collections.Generic;

public interface IGameControl
{
	void InteractMenu(MenuAction paramAction);
	void InteractPianoKey(PianoKey paramKey, KeyState paramState);
	void SetModel(IGameModel paramModel);
	void SetView(IGameView paramView);
}
