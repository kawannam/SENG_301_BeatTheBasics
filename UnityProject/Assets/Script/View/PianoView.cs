using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PianoView : MonoBehaviour, IGameView  
{
	private IGameModel model;
	private IGameControl control;
	public List<AudioSource> audioList = new List<AudioSource>();
	private bool keyboardEnabled = true;

	public PianoView()
	{
	}

	void WireUp(IGameControl paramControl, IGameModel paramModel)
	{
		if (model != null)
		{
			model.RemoveObserver(this);
		}
		model = paramModel;
		control = paramControl;
		control.SetModel(model);
		control.SetView(this);
		model.AddObserver(this);
	}

	// Use this for initialization
	void Start () {
		model = new FreePlayGame();
		control = new PianoControl();
		WireUp(control, model);
		audioList = new List<AudioSource>();
		foreach (BBAudioClip ac in model.AudioClipList)
		{	
			AudioSource source = gameObject.AddComponent<AudioSource>();
			source.clip = Resources.Load<AudioClip>(ac.FilePath);
			source.pitch = ac.Pitch;
			audioList.Add(source);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!keyboardEnabled)
			return;
		control.InteractPianoKey(PianoKey.L_C, Input.GetKey(KeyCode.Q));
		control.InteractPianoKey(PianoKey.L_Cs,Input.GetKey(KeyCode.Alpha2));
		control.InteractPianoKey(PianoKey.L_D, Input.GetKey(KeyCode.W));
		control.InteractPianoKey(PianoKey.L_Ds,Input.GetKey(KeyCode.Alpha3));
		control.InteractPianoKey(PianoKey.L_E, Input.GetKey(KeyCode.E));
		control.InteractPianoKey(PianoKey.L_F, Input.GetKey(KeyCode.R));
		control.InteractPianoKey(PianoKey.L_Fs,Input.GetKey(KeyCode.Alpha5));
		control.InteractPianoKey(PianoKey.L_G, Input.GetKey(KeyCode.T));
		control.InteractPianoKey(PianoKey.L_Gs,Input.GetKey(KeyCode.Alpha6));
		control.InteractPianoKey(PianoKey.L_A, Input.GetKey(KeyCode.Y));
		control.InteractPianoKey(PianoKey.L_As,Input.GetKey(KeyCode.Alpha7));
		control.InteractPianoKey(PianoKey.L_B, Input.GetKey(KeyCode.U));
		
		control.InteractPianoKey(PianoKey.H_C, Input.GetKey(KeyCode.B));
		control.InteractPianoKey(PianoKey.H_Cs,Input.GetKey(KeyCode.H));
		control.InteractPianoKey(PianoKey.H_D, Input.GetKey(KeyCode.N));
		control.InteractPianoKey(PianoKey.H_Ds,Input.GetKey(KeyCode.J));
		control.InteractPianoKey(PianoKey.H_E, Input.GetKey(KeyCode.M));
		control.InteractPianoKey(PianoKey.H_F, Input.GetKey(KeyCode.Comma));
		control.InteractPianoKey(PianoKey.H_Fs,Input.GetKey(KeyCode.L));
		control.InteractPianoKey(PianoKey.H_G, Input.GetKey(KeyCode.Period));
		control.InteractPianoKey(PianoKey.H_Gs,Input.GetKey(KeyCode.Semicolon));
		control.InteractPianoKey(PianoKey.H_A, Input.GetKey(KeyCode.Slash));
		control.InteractPianoKey(PianoKey.H_As,Input.GetKey(KeyCode.Quote));
		control.InteractPianoKey(PianoKey.H_B, Input.GetKey(KeyCode.RightShift));
	}
	
	public void DisableKeyboard()
	{
		keyboardEnabled = false;
	}

	public void EnableKeyboard()
	{
		keyboardEnabled = true;
	}

	public void Update(IGameModel paramModel)
	{
		IGameModel m = paramModel;
		for(int i = 0; i < (int)PianoKey.MAX; i++)
		{
			KeyState ks = m.CurrKeyStates[i];
			if (ks == KeyState.Pressed && !audioList[i].isPlaying)
				audioList[i].Play();
			if (ks == KeyState.Released && audioList[i].isPlaying)
				audioList[i].Stop();
		}
	}
}
