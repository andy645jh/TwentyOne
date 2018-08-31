using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorController : MonoBehaviour {
	
	void Start () {
		
	}

	public void clicLevel(int val){
		switch(val){
			case 1:
			Debug.Log("Level Easy");
			break;

			case 2:
			Debug.Log("Level Medium");
			break;

			case 3:
			Debug.Log("Level Hard");
			break;
		}
	}	
	// Update is called once per frame
	void Update () {
		
	}
}
