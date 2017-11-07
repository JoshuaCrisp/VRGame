using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using System.Threading;


public class arduinoToUnity : MonoBehaviour {

	public string potVal;
	//public string buttonVal;
	 

	SerialPort sp = new SerialPort("/dev/cu.usbmodem1411", 9600);



	// Use this for initialization
	void Start () {
		
		OpenConnection ();
	
	
	}


	// Update is called once per frame
	void Update () {

		float n = 0;
		float heightHAB = transform.position.y;

		try{
			print (sp.ReadLine());
		}
		catch(System.Exception){
		}


		potVal = sp.ReadLine ();

		float z = float.Parse (potVal);
		print (potVal);
		//print (heightHAB);


		if (z > 2700f && z < 2900f) {
			n = 10f;
		} else if (z > 2900f) {
			n = 30f;
		} else if (heightHAB <= 5f) {
			n = 0f;
		}
		else if (heightHAB <= 5f){
			n = 0f;
		}

		else {
			n = - 100.81f;
		}


		//Move forward if reaches certain height 


		if (heightHAB < 30f) {
			transform.Translate (0, n * Time.deltaTime, 0, Space.World);
		}

			 else  {

				transform.Translate (60 * Time.deltaTime, n * 5 * Time.deltaTime, 60* Time.deltaTime, Space.World);

			}
		






	}

	//Checks for connection
	public void OpenConnection()
	{
		if (sp != null)
		{
			if (sp.IsOpen)
			{
				sp.Close ();
				print ("Closin Port");
			}
			else{
				sp.Open ();
				//sp.ReadTimeout = 1;
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
