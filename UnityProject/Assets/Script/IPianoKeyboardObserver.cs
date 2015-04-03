using UnityEngine;
using System.Collections;

public interface IPianoKeyboardObserver
{
	void OnPianoKeyDown(PianoKey paramKey);
}
