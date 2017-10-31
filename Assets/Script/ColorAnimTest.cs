using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAnimTest : MonoBehaviour {

	public Color lerpedColor = Color.white;
	void Update() {
		lerpedColor = Color.Lerp(Color.blue, Color.white, Mathf.PingPong(Time.time, 1));
//		renderer.material.color = Color.Lerp(Color.blue, Color.white, 2);
	}
}
