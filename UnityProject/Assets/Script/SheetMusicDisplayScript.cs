using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

// Note Lengths
public enum NoteType
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

	// Gets the duration of note in seconds
	public float Duration
	{
		get 
		{ 
			return (float)(Math.Pow(2, -((int)type))); 
		}
	}

	//Sets the key and type of a note
	public SheetMusicNote(NoteType paramType, PianoKey paramKey)
	{
		type = paramType;
		key = paramKey;
	}
}

public class SheetMusicDisplayScript : MonoBehaviour {
	
	const float BAR_WIDTH = 300;
	const float LINE_HEIGHT = 16;	// ex- a D note is 16 y-offset from C

	private string[] prefabs = new string[]{	// prefabs for each note type
		"Prefabs/SheetMusic/wholeNote",
		"Prefabs/SheetMusic/halfNote",
		"Prefabs/SheetMusic/quarterNote",
		"Prefabs/SheetMusic/eighthNote",
		"Prefabs/SheetMusic/flatNote",
		"Prefabs/SheetMusic/lineNote"
	};
	
	public float[] y_offs = new float[]{	// the y offsets for each piano key note
		0,		// c
		8,		// db
		8,		// d
		16, 	// eb
		16, 	// e
		24,		// f
		32,		// gb		
		32,		// g		
		40,		// ab
		40,		// a
		48,		// bb
		48,		// b
		56,		// c
		56,		// db
		158,	// d
		166,	// eb
		166,	// e
		174,	// f
		182,	// gb
		182,	// g
		190,	// ab
		190,	// a
		198,	// bb
		198		// bb
	};

	const float INITIAL_XOFFS = BAR_WIDTH / 8;	// the position 
	public List<GameObject> noteObjects = new List<GameObject>();
	public List<SheetMusicNote> notes = new List<SheetMusicNote>();
	public float x_offset = INITIAL_XOFFS;
	public Transform noteGrp;	// the parent of all the note sprites that will be added
	private Vector3 startPosition;

	// reset the offset
	void Start()
	{
		startPosition = transform.localPosition;	
	}

	// clear all the notes we may have on screen
	public void Reset()
	{
		foreach(GameObject go in noteObjects)	  
			GameObject.Destroy(go);

		transform.localPosition = startPosition;
		x_offset = INITIAL_XOFFS;
		notes.Clear();
	}

	//Shifts where the note will be drawn
	public void ShiftDisplay(float paramXOffs)
	{
		Vector3 pos = transform.localPosition;
		pos.x += paramXOffs;
		transform.localPosition = pos;
	}

	//This draws the note on the screen
	public void AddNote(SheetMusicNote paramNote, Color paramColor)
	{
		notes.Add(paramNote);	// keep track of the notes we're adding

		GameObject g = null;
		Vector3 pos;
		
		g = Resources.Load<GameObject>(prefabs[(int)paramNote.type]);			
		g = (GameObject)GameObject.Instantiate(g);
		g.transform.parent = noteGrp;
		pos = Vector3.zero;
		pos.x = x_offset;
		pos.y = y_offs[(int)paramNote.key];
		g.transform.localPosition = pos;
		g.transform.localScale = Vector3.one;
		SpriteRenderer renderer = g.GetComponent<SpriteRenderer>();
		renderer.color = paramColor;
		noteObjects.Add(g);
		
		switch(paramNote.key)	// check for sharps
		{	
		case PianoKey.L_Cs:
		case PianoKey.L_Ds:
		case PianoKey.L_Fs:
		case PianoKey.L_Gs:
		case PianoKey.L_As:
		case PianoKey.H_As:
		case PianoKey.H_Cs:
		case PianoKey.H_Ds:
		case PianoKey.H_Fs:
		case PianoKey.H_Gs:
			g = Resources.Load<GameObject>(prefabs[4]);
			g = (GameObject)GameObject.Instantiate(g);
			g.transform.parent = noteGrp;
			pos = Vector3.zero;
			pos.x = x_offset;
			pos.y = y_offs[(int)paramNote.key];
			g.transform.localPosition = pos;
			g.transform.localScale = Vector3.one;
			noteObjects.Add(g);
			renderer = g.GetComponent<SpriteRenderer>();
			renderer.color = paramColor;
			break;
		}
		
		switch(paramNote.key)	// check for middle C, draw a line thru it
		{	
		case PianoKey.H_C:
		case PianoKey.H_Cs:
			g = Resources.Load<GameObject>(prefabs[5]);
			g = (GameObject)GameObject.Instantiate(g);
			g.transform.parent = noteGrp;
			pos = Vector3.zero;
			pos.x = x_offset;
			pos.y = y_offs[(int)paramNote.key];
			g.transform.localPosition = pos;
			g.transform.localScale = Vector3.one;
			noteObjects.Add(g);
			renderer = g.GetComponent<SpriteRenderer>();
			renderer.color = paramColor;
			break;
		}

		x_offset += BAR_WIDTH * paramNote.Duration;
	}
}
