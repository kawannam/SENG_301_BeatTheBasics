using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum KeyState
{
	Released,
	Pressed
}

public enum PianoKey
{
	L_C,
	L_Cs,
	L_D,
	L_Ds,
	L_E,
	L_F,
	L_Fs,
	L_G,
	L_Gs,
	L_A,
	L_As,
	L_B,
	H_C,
	H_Cs,
	H_D,
	H_Ds,
	H_E,
	H_F,
	H_Fs,
	H_G,
	H_Gs,
	H_A,
	H_As,
	H_B,
	MAX
}

public class PianoKeyboard : MonoBehaviour  
{
	public List<AudioClip> clipList = new List<AudioClip>();
	public List<AudioSource> sourceList = new List<AudioSource>();
	private KeyState[] currKeyStates = new KeyState[(int)PianoKey.MAX];
	private KeyState[] prevKeyStates = new KeyState[(int)PianoKey.MAX];
	private KeyCode[] binding = new KeyCode[(int)PianoKey.MAX];

	// Use this for initialization
	void Start () 
	{
		binding[(int)PianoKey.L_C]  = KeyCode.Q;
		binding[(int)PianoKey.L_Cs] = KeyCode.Alpha2;
		binding[(int)PianoKey.L_D]  = KeyCode.W;
		binding[(int)PianoKey.L_Ds] = KeyCode.Alpha3;
		binding[(int)PianoKey.L_E]  = KeyCode.E;
		binding[(int)PianoKey.L_F]  = KeyCode.R;
		binding[(int)PianoKey.L_Fs] = KeyCode.Alpha5;
		binding[(int)PianoKey.L_G]  = KeyCode.T;
		binding[(int)PianoKey.L_Gs] = KeyCode.Alpha6;
		binding[(int)PianoKey.L_A]  = KeyCode.Y;
		binding[(int)PianoKey.L_As] = KeyCode.Alpha7;
		binding[(int)PianoKey.L_B]  = KeyCode.U;
								    
		binding[(int)PianoKey.H_C]  = KeyCode.B;
		binding[(int)PianoKey.H_Cs] = KeyCode.H;
		binding[(int)PianoKey.H_D]  = KeyCode.N;
		binding[(int)PianoKey.H_Ds] = KeyCode.J;
		binding[(int)PianoKey.H_E]  = KeyCode.M;
		binding[(int)PianoKey.H_F]  = KeyCode.Comma;
		binding[(int)PianoKey.H_Fs] = KeyCode.L;
		binding[(int)PianoKey.H_G]  = KeyCode.Period;
		binding[(int)PianoKey.H_Gs] = KeyCode.Semicolon;
		binding[(int)PianoKey.H_A]  = KeyCode.Slash;
		binding[(int)PianoKey.H_As] = KeyCode.Quote;
		binding[(int)PianoKey.H_B]  = KeyCode.RightShift;

		sourceList = new List<AudioSource>();
		foreach (AudioClip ac in clipList)
		{	
			AudioSource source = gameObject.AddComponent<AudioSource>();
			source.clip = ac;
			sourceList.Add(source);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		for (int i = 0; i < (int)PianoKey.MAX; i++)
		{
			KeyCode key = binding[i];
			prevKeyStates[i] = currKeyStates[i];
			currKeyStates[i] = Input.GetKey(key) ? KeyState.Pressed : KeyState.Released;

			KeyState ks = currKeyStates[i];
			if (ks == KeyState.Pressed && !sourceList[i].isPlaying)
				sourceList[i].Play();
			if (ks == KeyState.Released && sourceList[i].isPlaying)
				sourceList[i].Stop();
		}
	}
}
