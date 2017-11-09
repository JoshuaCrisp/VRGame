using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using System.Threading;
using System.Linq;

public class ArduinoToUnity_03 : MonoBehaviour {

	private string potVal;
	private string buttonVal;
	public float forward=0;
	public float speedUp = 0f;
	public float lower;
	public float higher;
	public float pumpValue;
	private Rigidbody rb;
	public float x;
	public float y;
	public float z;
	float heightHAB; 

	SerialPort sp = new SerialPort("/dev/cu.usbmodem1411", 9600);
	//SerialPort sp = new SerialPort("COM3", 9600);

	// Use this for initialization
	void Start () {
		sp.Open ();
		sp.ReadTimeout = 10;
		rb = GetComponent<Rigidbody>();


		//print ("port opened");
		
	}


	
	// Update is called once per frame
	void Update () {
		
		try{
			potVal = sp.ReadLine ();
			//print (sp.ReadLine());


		}
		catch(System.Exception){
		}

		float heightHAB = transform.position.y;

		float pumpValue = float.Parse (potVal);
		sp.BaseStream.Flush();
		print (pumpValue);

		if (heightHAB <= 80) {
			forward = 0;

		} else {
			forward = 120f;

		}

		if (pumpValue > lower && pumpValue < higher) {
			speedUp = 60f;
			//forward = 80f;

		} else if (pumpValue > higher) {
			speedUp = 100f;
			//forward = 120;

		} else if (pumpValue < lower && heightHAB > 20) {
			speedUp = -70.81f;

		} else {
			speedUp = 0f;

		}



		//Vector3 movement = new Vector3 (0, speedUp* Time.deltaTime, forward*Time.deltaTime);

		//rb.AddForce (movement, ForceMode.Acceleration);

		transform.Translate (0, speedUp * Time.deltaTime, forward * Time.deltaTime , Space.Self);

	}
}
