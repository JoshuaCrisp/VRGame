using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

	public AudioClip thunder;
	private AudioSource source;



	// Use this for initialization
	void Start () {

		source = GetComponent<AudioSource> ();

	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.tag == "hero") {

			source.PlayOneShot (thunder);
			print ("collided");

		}


	}



	// Update is called once per frame
	void Update () {

	}
}
