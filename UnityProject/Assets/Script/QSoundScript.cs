using UnityEngine;
using System.Collections;

public class QSoundScript : MonoBehaviour {

	public AudioSource source1;
	
	void Update() {
		if (Input.GetKeyDown("q"))
			source1.Play();
		
	}
	// Use this for initialization
	void Start () {
		
	}
}	

