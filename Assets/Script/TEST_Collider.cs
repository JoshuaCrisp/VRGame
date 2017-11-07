using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_Collider : MonoBehaviour {



	void OnTriggerEnter(Collider other) {

		if (other.gameObject.tag == "hero") {
		
			Time.timeScale = 0;
			print ("collided");
		
		}


	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
