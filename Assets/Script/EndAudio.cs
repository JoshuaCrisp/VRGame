using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAudio : MonoBehaviour {

	public AudioClip win, lose;
	public int counter = 0;
	private AudioSource source1, source2;



	// Use this for initialization
	void Start () {
		source1 = GetComponent<AudioSource> ();	
		source2 = GetComponent<AudioSource> ();	
	}

	public void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Villian") {
			counter = 1;
		}

		if (other.gameObject.tag == "hero" && counter == 1) {
			source1.PlayOneShot (lose);
			print ("you lose");
		} else if(other.gameObject.tag == "hero" && counter == 0) {
			source2.PlayOneShot (win);


		}

	}
	// Update is called once per frame
	void Update () {

}
}