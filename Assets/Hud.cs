using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour {

	public Text point3;
	public Text point6;
	public Text point9;

	private float _pointVal3 = 0;
	private float _pointVal6 = 0;
	private float _pointVal9 = 0;

	private float _total;
	void Start () {
		point3.text = "0";
		point6.text = "0";
		point9.text = "0";
	}
	
	public void setPoint3(){
		_pointVal3 += 3;
		point3.text = _pointVal3.ToString();
	}

	public void setPoint6(){
		_pointVal6 += 6;
		point6.text = _pointVal6.ToString();
	}

	public void setPoint9(){
		_pointVal9 += 9;
		point9.text = _pointVal9.ToString();
	}
}
