using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMouseDown : MonoBehaviour {

	public Rigidbody rb;



	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void OnMouseDown(){




	}

	// Update is called once per frame
	void Update () {
		rb.AddForce(transform.up *100);
	}
}
