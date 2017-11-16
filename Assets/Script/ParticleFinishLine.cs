using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFinishLine : MonoBehaviour {

	private  ParticleSystem confeti;

	// Use this for initialization
	void Start () {
		
		confeti =GameObject.FindGameObjectWithTag("Confeti").GetComponent<ParticleSystem> ();
		//
}

	public void OnTriggerEnter(Collider other) {

		if (other.gameObject.tag == "hero" || other.gameObject.tag == "Villan") {
			
			confeti.Play() ;

	}
}
}
