using UnityEngine;
using System.Collections;

public class KeyboardSound : MonoBehaviour { 

	public AudioSource source0;
	public AudioSource source1;
	public AudioSource source2;
	public AudioSource source3;
	public AudioSource source4;
	public AudioSource source5;
	public AudioSource source6;
	public AudioSource source7;

	void Update() {
		if (Input.GetKeyDown("a"))
			source0.Play();
		if (Input.GetKeyDown("s"))
			source1.Play();
		if (Input.GetKeyDown("d"))
			source2.Play();
		if (Input.GetKeyDown("f"))
			source3.Play();
		if (Input.GetKeyDown("g"))
			source4.Play();
		if (Input.GetKeyDown("h"))
			source5.Play();
		if (Input.GetKeyDown("j"))
			source6.Play();
		if (Input.GetKeyDown("k"))
			source7.Play();
		
	}
	// Use this for initialization
	void Start () {
	
	}

}
