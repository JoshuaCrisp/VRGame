using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class onCollision : MonoBehaviour {


	public void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Peak") {
			Debug.Log ("it's colliding");
		
			//Time.timeScale = 0;


		} 
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
