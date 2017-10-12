using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatePropeler : MonoBehaviour {

	public float n = 1;
	float countdown;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		//countdown -= Time.deltaTime;

		transform.Rotate (0, Time.deltaTime * n, 0);

	}
}
