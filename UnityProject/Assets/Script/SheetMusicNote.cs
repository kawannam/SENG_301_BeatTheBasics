using UnityEngine;
using System.Collections;
using System;

public enum NoteType	// Note Lengths
{
	Whole,
	Half,
	Quarter,
	Eighth
}

[System.Serializable]
public class SheetMusicNote
{
	public NoteType type;
	public PianoKey key;

	public float Duration
	{
		get 
		{ 
			return (float)(Math.Pow(2, -((int)type))); 	// return the duration of note in seconds
		}
	}

	public SheetMusicNote(NoteType paramType, PianoKey paramKey)
	{
		type = paramType;
		key = paramKey;
	}
}
