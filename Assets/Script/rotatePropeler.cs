using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatePropeler : MonoBehaviour {

	public float x = 0;
	public float y = 0;
	public float z = 0;
	float countdown;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		//countdown -= Time.deltaTime;

		transform.Rotate (Time.deltaTime * x, Time.deltaTime * y, Time.deltaTime * z);

	}
}
