using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {


	public Text textTimer ;
	public float minutes, seconds;
	public float timeLeft;
	public float counter;

	// Use this for initialization
	void Start () {
		//textTimer = GetComponent<Text>() as Text;
	
		
	}


	void OnGUI () {
		GUI.Label (new Rect (0,0,100,50), "Time left:  " + counter.ToString("00"));
	}

	
	// Update is called once per frame
	void Update () {


		counter -= Time.deltaTime;
		if(counter <= 0){

			GameOver ();
		}




//		minutes = (int)(Time.time / 60f);
//		seconds = (int)(Time.time % 60f);
//		textTimer.text = minutes.ToString("00") + ":" + seconds.ToString("00");


//		timeLeft += Time.deltaTime;
//		if (timeLeft >= 120.0) {
//		
//			GameOver ();
//		}
		
	}



	void GameOver(){

		Time.timeScale = 0;

	}


}
