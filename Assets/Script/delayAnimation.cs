using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delayAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(delayAnim());
	}
	IEnumerator delayAnim()
	{
		
		yield return new WaitForSeconds(5);
		GetComponent<Animation>().Play("shuffleToDeck");

	}
}
