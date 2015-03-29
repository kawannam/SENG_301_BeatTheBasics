using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Note
{
	public NoteType type;
	public PianoKey key;
}

public class SheetMusicModeScript : MonoBehaviour {

	public SheetMusicDisplayScript display;
	public List<Note> notes;
	
	public PianoKey key;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
