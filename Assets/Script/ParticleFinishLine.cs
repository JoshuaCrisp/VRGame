using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFinishLine : MonoBehaviour {

	private  ParticleEmitter source;

	// Use this for initialization
	void Start () {
		
		source = GetComponent<ParticleEmitter> ();

}

void OnTriggerEnter(Collider other) {

	if (other.gameObject.tag == "Hero") {

	source.enabled = true;

	}
}
}
