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
	public double pumpValue;
	public double R_PedalValue;
	private Rigidbody rb;
	public float x;
	public float y;
	public float z;
	float heightHAB; 
	public float counter;
	public float _timer;
	public float r;

	public float minAngle;
	public float maxAngleR ;

	//SerialPort sp = new SerialPort("/dev/cu.usbmodem1411", 9600);
	SerialPort sp = new SerialPort("COM4", 9600);

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

		double pumpValue = double.Parse(potVal);
		R_PedalValue = double.Parse (potVal.Substring (3)); //Test for adding pedals
		sp.BaseStream.Flush();
		//print (pumpValue);
		print (R_PedalValue);



		if (heightHAB <= 100 ) {
				forward = 0;

			} else {
				forward = 120f;

			}
		

		if (pumpValue > lower && pumpValue < higher) {
			speedUp = 80f;
			//forward = 80f;

		} else if (pumpValue > higher) {
			speedUp = 120f;
			//forward = 120;

		} else if (pumpValue < lower && heightHAB > 20) {
			speedUp = -80.81f;

		} else {
			speedUp = 0f;

		}

		counter += Time.deltaTime;
		if (counter <= 11) {

			_timer = 0;
		} else {

			_timer = 1;
		}


		//Testing R L movement on Key
//		if (Input.GetKey (KeyCode.RightArrow)) {
//			r = 5;
//
//		} else if(Input.GetKey (KeyCode.LeftArrow)) {
//			r = -5;
//		} else{
//		r = 0;
//	}
//			
//
//		if (Input.GetKeyDown (KeyCode.RightArrow)) {
//			float angle = Mathf.LerpAngle (0f, 30f, 1);
//			transform.eulerAngles = new Vector3 (0,0,angle);
//
//		}
//		if (Input.GetKeyUp (KeyCode.RightArrow)) {
//			float angle = Mathf.LerpAngle (-15, 0, Time.time);
//			transform.eulerAngles = new Vector3 (0,0,angle);
//
//		}
	

		// Move HAB
		transform.Translate (r, speedUp * Time.deltaTime, _timer * forward * Time.deltaTime , Space.Self);

		//Move HAB with Adding force - not working properly
		//Vector3 movement = new Vector3 (0, speedUp* Time.deltaTime, _timer * forward*Time.deltaTime);


	//	rb.AddForce (movement, ForceMode.VelocityChange);
		//rb.AddForce (movement * 120);
	
		// _timer * 


	



	}

}
