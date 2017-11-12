using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delaySound : MonoBehaviour {


	public AudioClip thunder;
	private AudioSource source;
	public float n;

	// Use this for initialization
	void Start () {


		source = GetComponent<AudioSource> ();
		source.PlayDelayed( n );
	
	}
		

		




	// Update is called once per frame
	void Update () {
		


	}
}
