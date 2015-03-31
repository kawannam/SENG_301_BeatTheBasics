using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IPianoKeyboardObserver
{
	void OnPianoKeyDown(PianoKey paramKey);
}

public class PianoKeyboardScript : MonoBehaviour  
{
	const int NUM_KEYS = 24;
	private AudioClip[] clipList;
	private List<AudioSource> sourceList = new List<AudioSource>();
	private KeyState[] currKeyStates = new KeyState[(int)PianoKey.MAX];
	private KeyState[] prevKeyStates = new KeyState[(int)PianoKey.MAX];
	private KeyCode[] binding = new KeyCode[(int)PianoKey.MAX];
	public SpriteRenderer spriteRenderer;
	public PianoKeyScript[] keyScripts;
	public List<IPianoKeyboardObserver> observers = new List<IPianoKeyboardObserver>();
	// Use this for initialization
	void Start () 
	{
		keyScripts = new PianoKeyScript[Constants.PIANO_NUM_KEYS];

		Transform keysGrp = transform.FindChild("keysGrp");
		for (int i = 0; i < keysGrp.transform.childCount; i++)
		{
			Transform child = keysGrp.transform.GetChild(i);		
			PianoKeyScript key = child.gameObject.AddComponent<PianoKeyScript>();
			keyScripts[i] = key;
		}

		clipList = new AudioClip[Constants.PIANO_NUM_KEYS];
		for (int i = 0; i < Constants.PIANO_NUM_KEYS; i++)
		{
			clipList[i] = Resources.Load<AudioClip>(Constants.PIANO_SOUND_FILES[i]);
			binding[i] = Constants.PIANO_KEY_BINDING[i];
		}

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
			PianoKey currKey = (PianoKey)i;
			KeyCode key = binding[i];
			prevKeyStates[i] = currKeyStates[i];
			KeyState ks = KeyState.Released;
			if (Input.GetKey(key) || keyScripts[i].pressed) 
				ks = KeyState.Pressed;

			currKeyStates[i] = ks;

			if (ks == KeyState.Pressed)
			{
				if (prevKeyStates[i] == KeyState.Released)
				{
					foreach(IPianoKeyboardObserver observer in observers)
						observer.OnPianoKeyDown(currKey);
				}
				if (!sourceList[i].isPlaying)
					sourceList[i].Play();
			}
			if (ks == KeyState.Released && sourceList[i].isPlaying)
				sourceList[i].Stop();
		}
	}	
	
	public KeyState GetPianoKeyState(PianoKey paramKey)
	{
		return currKeyStates[(int)paramKey];
	}
}
