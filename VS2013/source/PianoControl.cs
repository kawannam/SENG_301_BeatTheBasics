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
