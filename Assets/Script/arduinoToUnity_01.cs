using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using System.Threading;
using System.Linq;


public class arduinoToUnity_01
	: MonoBehaviour {

	public string potVal;
	public string buttonVal;
	 

	SerialPort sp = new SerialPort("/dev/cu.usbmodem1411", 9600);



	// Use this for initialization
	void Start () {
		
		OpenConnection ();

	
	}

	float n = 0;
	float lr = 0;
	float forward = 60f;



	// Update is called once per frame
	void Update () {
		
		try{
			print (sp.ReadLine());
//			pumpAction();
		}
		catch(System.Exception){
		}

//		float n = 0;
		float heightHAB = transform.position.y;

		float back = 1;//This is for collision with clouds (test inside collider), when hit change value to - or physics

	
		//buttonVal = sp.ReadLine ();
		potVal = sp.ReadLine ();
		float z = float.Parse (potVal);
		sp.BaseStream.Flush();
		print (z);


		float val_Button = float.Parse (potVal.Substring (3));
		print (val_Button);



		if (z > 2700f && z < 2900f) {
			n = 30f;

		} else if (z > 2900f) {
			n = 60f;
		} else if (heightHAB < 5f) {
			n = 0f;
		}


		else {
			n = - 50.81f;
		}


		//Move forward if reaches certain height 

		if (heightHAB < 30f) {
			transform.Translate (0, n * Time.deltaTime, 0, Space.World);
		}

		else {

			transform.Translate (forward  * Time.deltaTime, n * Time.deltaTime, lr * Time.deltaTime, Space.World);


		}

		if (val_Button == 0) {
			lr = -30f;

		} else {
		
			lr = 0;
		}




	}


//	void pumpAction(){
//
//		float heightHAB = transform.position.y;
//
//		if (z > 2700f && z < 2900f) {
//			n = 30f;
//
//		} else if (z > 2900f) {
//			n = 60f;
//		} else if (heightHAB < 5f) {
//			n = 0f;
//		}
//
//
//		else {
//			n = - 10.81f;
//		}
//
//
//		//Move forward if reaches certain height 
//
//		if (heightHAB < 30f) {
//			transform.Translate (0, n * Time.deltaTime, 0, Space.World);
//		}
//
//		else {
//
//			transform.Translate (forward  * Time.deltaTime, n * Time.deltaTime, lr * Time.deltaTime, Space.World);
//
//
//		}
//
//	}









	//Checks for connection
	public void OpenConnection()
	{
		if (sp != null)
		{
			if (sp.IsOpen)
			{

				sp.Close ();
				print ("Closing Port");
			}
			else{
				sp.Open ();
				sp.ReadTimeout = 10;
				print ("port opened");
			}
		}
		else
		{
			if (sp.IsOpen)
			{
				print("Port is already open");
			}
			else
			{
				print("port == null");
			}
		}
	}



}
