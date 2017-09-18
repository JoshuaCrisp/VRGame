using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour {

	public float current = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			current += 2f;
			transform.Translate (0, current, 0);
		}
	}
	
}

