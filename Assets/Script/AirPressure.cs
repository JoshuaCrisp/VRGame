using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPressure : MonoBehaviour {


	public GameObject ap_Handle;
	public float pressure;

	// Use this for initialization
	void Start () {

		//GameObject.Find("HAB_03").GetComponent<ArduinoToUnity_02>().z = 10.0f;
		GameObject pump = GameObject.Find("HAB_03");
		ArduinoToUnity_02 pressureValue = pump.GetComponent<ArduinoToUnity_02> ();
		pressureValue.z = pressure;
		print (pressure);

	}
	
	// Update is called once per frame
	void Update () {

		//if statment goes here


		transform.Rotate (0, 0, Time.deltaTime * pressure);
	}

}
