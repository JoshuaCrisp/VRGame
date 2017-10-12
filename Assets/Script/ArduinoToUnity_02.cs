using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using System.Threading;
using System.Linq;

public class ArduinoToUnity_02 : MonoBehaviour {

	private string potVal;
	private string buttonVal;
	public float forward = 0;
	public float speedUp = 0f;
	public float lower;
	public float higher;
	public float z;

	//SerialPort sp = new SerialPort("/dev/cu.usbmodem1411", 9600);
	SerialPort sp = new SerialPort("COM3", 9600);

	// Use this for initialization
	void Start () {
		sp.Open ();
		sp.ReadTimeout = 10;


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

		float z = float.Parse (potVal);
		sp.BaseStream.Flush();
		print (z);

		if (heightHAB <= 20) {
			forward = 0;

		} else {
			forward = 60f;

		}

		if (z > lower && z < higher) {
			speedUp = 80f;


		} else if (z > higher) {
			speedUp = 130f;


		} else if (z < lower && heightHAB > 20) {
			speedUp = -250.81f;


		} else {
			speedUp = 0f;

		}





		transform.Translate (0, speedUp * Time.deltaTime, forward * Time.deltaTime , Space.Self);
	}
}
