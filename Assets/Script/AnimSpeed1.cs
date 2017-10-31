using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSpeed1 : MonoBehaviour {

	public Animation anim;
	public float s;

	void Start()
	{
		// Walk backwards
//		anim["Walk"].speed = -1.0f;

		// Walk at double speed
		anim["VillanAnim"].speed  = 0.0f;
	}
}
