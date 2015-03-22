using System.Collections;
using System.Collections.Generic;

public interface IGameView
{
	void DisableKeyboard();
	void EnableKeyboard();
	void Update(IGameModel paramModel);
}


