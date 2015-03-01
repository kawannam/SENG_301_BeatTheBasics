using UnityEngine;
using System.Collections;

public class KeyboardSound : MonoBehaviour { 

	public AudioSource source;

	void Update() {
		if (Input.GetKeyDown("q"))
			source.Play();
		
	}
	// Use this for initialization
	void Start () {
	
	}

}
