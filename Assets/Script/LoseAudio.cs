using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseAudio : MonoBehaviour {
	public AudioClip lose;
	private AudioSource source;
	public int counter = 0;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();		
	}

	public void OnTriggerEnter(Collider other) {
		
		if (other.gameObject.tag == "Villian") {
			counter = 1;
		}

		if(other.gameObject.tag == "hero") {
			source.PlayOneShot(lose);
			print("you lose");
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
