using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MetronomeMenuScript : GameModeScript {
	
	public Image toggleImg;
	public Sprite playSpr;
	public Sprite stopSpr;
	private Color playColor = new Color(0, 1, 0);
	private Color stopColor = new Color(1, 0, 0);
	public Text bpmText;
	public InputField inputField;
	public int bpm;
	public Metronome metronome;
	public bool isPlaying;

	public void OnToggle()
	{
		isPlaying = !isPlaying;
		toggleImg.color = !isPlaying ? playColor : stopColor;
		toggleImg.sprite = !isPlaying ? playSpr : stopSpr;
		metronome.ToggleActive();
	}

	void RestrictBPM()
	{	
		if (bpm > Constants.MAX_BPM)
			bpm = Constants.MAX_BPM;
		if (bpm < Constants.MIN_BPM)
			bpm = Constants.MIN_BPM;
	}

	public void OnInputEnd(string paramValue)
	{
		int.TryParse(paramValue, out bpm);		
		RestrictBPM();
		inputField.text = "";
		metronome.SetBPM(bpm);
	}
	
	public void OnChangeBPM(int paramAdd)
	{
		bpm += paramAdd;
		RestrictBPM();
		metronome.SetBPM(bpm);
	}

	public void OnQuit()
	{
		gameManager.ChangeState(GameManagerState.Menu);
	}

	void Update()
	{
		bpmText.text = bpm.ToString();
	}
}
