using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using System.Threading;


public class arduinoToUnity : MonoBehaviour {

	public string potVal;


	float y = 0;


	SerialPort sp = new SerialPort("/dev/cu.usbmodem1411", 9600);

	//public float moveValue = 0;
	public float speed = 2000f;
	int moveValue = 0;

	// Use this for initialization
	void Start () {
		OpenConnection ();

	
	}

	// Update is called once per frame
	void Update () {
		




		try{
			print (sp.ReadLine());
		}
		catch(System.Exception){
		}

		potVal = sp.ReadLine ();

		float z = float.Parse (potVal);
		print (potVal);

//		int moveValue = int.Parse(potVal.Text);



		if (z > 2800) {
			y = 5;
		} else {
			y = - 3.81f;
		}



		transform.Translate(0, y * Time.deltaTime,0);

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
