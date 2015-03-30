using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SheetMusicModeScript : GameModeScript, IPianoKeyboardObserver {

	public SheetMusicDisplayScript display;
	public List<SheetMusicNote> notes;

	public float noteIndex;
	public float time;

	// Use this for initialization
	void Start () {
		display.AddNote(new SheetMusicNote(NoteType.Half, PianoKey.H_C), Color.black);
	}

	public void OnPianoKeyDown(PianoKey paramKey)
	{
		//if (paramKey == notes[noteIndex].key)
		//	notes[noteIndex].
		noteIndex++;
	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
	}
}
