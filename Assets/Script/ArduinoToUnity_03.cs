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
	//public int pumpValue;
	public int R_PedalValue;
	public int L_PedalValue;
	private Rigidbody rb;
	public float x;
	public float y;
	public float z;
	public float heightHAB; 
	public float counter;
	public float _timer;
	public float r = 0;
	public string myString;
	float minAngle;
	float maxAngleR ;
	private int hab;
	private string pedal_R;
	private string pedal_L;
	private float angleTimer;
	private float max_angleTimer = 2.0f;
	private float stillTimer = 0.0f;

//Select serial port
	//SerialPort sp = new SerialPort("/dev/cu.usbmodem1411", 9600);
	SerialPort sp = new SerialPort("COM3", 9600);

// Use this for initialization
	void Start () {
		sp.Open ();
		sp.ReadTimeout = 10;
		rb = GetComponent<Rigidbody>();
		//print ("port opened");	
	}

// Timer for delay animations
	public void timer(){
		counter += Time.deltaTime;
		if (counter <= 11) {
			_timer = 0;
		} else {
			_timer = 1;
		}
	}


// Update is called once per frame
	void Update () {
		
		try{
			potVal = sp.ReadLine ();

		}
		catch(System.Exception){
		}



//Convert string readings from arduino to values
		double pumpValue = double.Parse(potVal);
		//int pumpValue = int.Parse(potVal);
		string pedal_R = potVal.Substring(4,1);
		string pedal_L = potVal.Substring (6,1);
		//int R_PedalValue = int.Parse (pedal_R);
		//int L_PedalValue = int.Parse (pedal_L);

	//	print (R_PedalValue);
		//print (L_PedalValue);

//		string myString_R = potVal.Substring (3,1);
//		double R_PedalValue = double.Parse (potVal.Substring (3,1)); //Test for adding pedals
//		double L_PedalValue = double.Parse (potVal.Substring (4,1));

//Flush port reading			
		sp.BaseStream.Flush();
		//print (pumpValue);
		//print (myString);
		//print(potVal);
		//print (hab);

//Get HAB height for triggering forward movement
		heightHAB = transform.position.y;

		if (heightHAB <= 100 ) {
				forward = 0;

			} else {
				forward = 120f;
		}

//Set min and max for UP movement
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



//Move HAB sideways

		// 

		//Using string
		if (pedal_R == "1" && pedal_L == "1") {
			r = 0;
			angleTimer = 0;
			stillTimer += Time.deltaTime;
			float angle = Mathf.LerpAngle (transform.eulerAngles.z, 0, Mathf.Clamp(stillTimer/max_angleTimer, 0.0f, 1.0f));
			transform.eulerAngles = new Vector3 (0, 90, angle);
			//float angle = Mathf.LerpAngle (0f, 0f, Time.deltaTime);
			//transform.eulerAngles = new Vector3 (0, 90,angle);
		}else if(pedal_R == "1" && pedal_L == "0"){
				r = -3;
			stillTimer = 0;
			angleTimer += Time.deltaTime;
			print (angleTimer/max_angleTimer);
			float angle = Mathf.LerpAngle (0f, 30f, Mathf.Clamp(angleTimer/max_angleTimer, 0.0f, 1.0f));
			transform.eulerAngles = new Vector3 (0, 90, angle);

		}else if (pedal_R == "0" && pedal_L == "1") {
			r = 3;
			stillTimer = 0;
			angleTimer += Time.deltaTime;
			float angle = Mathf.LerpAngle (0f, -30f, angleTimer/max_angleTimer);
			transform.eulerAngles = new Vector3 (0, 90, angle);
		}else{
			r = 0;


		}



		//Using int
//		if (R_PedalValue != 1) {
//			r = 7;
//
//		}else{
//				r = 0;
//		}
//
//		if (L_PedalValue != 1) {
//			r = -7;

//		}else{
//			r = 0;
//		}

		//Testing R L movement on Key
//		if (Input.GetKey (KeyCode.RightArrow)) {
//			r = 5;
//
//		} else if(Input.GetKey (KeyCode.LeftArrow)) {
//			r = -5;
//		} else{
//			r = 0;
//		}
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
	

		timer ();

// Move HAB
		transform.Translate (r, speedUp * Time.deltaTime, _timer * forward * Time.deltaTime , Space.Self);

		//Move HAB with Adding force - not working properly
		//Vector3 movement = new Vector3 (0, speedUp* Time.deltaTime, _timer * forward*Time.deltaTime);


	//	rb.AddForce (movement, ForceMode.VelocityChange);
		//rb.AddForce (movement * 120);
	
		// _timer * 

	

	}

}
