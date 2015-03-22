using UnityEngine;
using System.Collections;

public class PianoControl : IGameControl
{
	private IGameModel model;
	private IGameView view;

	public PianoControl()
	{
	}

	public PianoControl(IGameModel paramModel, IGameView paramView)
	{
		model = paramModel;
		view = paramView;
	}
	
	public void InteractPianoKey(PianoKey paramKey, bool paramPlay)
	{
		if (paramPlay && model != null)
			model.Press(paramKey);
		if (!paramPlay && model != null)
			model.Release(paramKey);
		view.DisableKeyboard();
	}

	public void SetModel(IGameModel paramModel)
	{
		model = paramModel;
	}
	
	public void SetView(IGameView paramView)
	{
		view = paramView;
		view.EnableKeyboard();
	}
}
