using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectTimer : MonoBehaviour {

	public float n = 1;
	public float countdown;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		countdown -= Time.deltaTime;
		//print (countdown);
		if(countdown <= 0){
			
			GameOver ();
		}

		transform.Rotate (0, 0, Time.deltaTime * (-n));
		
	}
	void GameOver(){

		Time.timeScale = 0;

	}



}
