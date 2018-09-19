using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDisc : MonoBehaviour {

	private Player _currentDisc;	
	private float _max = 5.65f;
	private float _min = 0;

	void Start () {
		
	}
		
	void Update () {	
		if(_currentDisc==null) return;

		var posZ = _currentDisc.transform.position.z;
		posZ = Mathf.Clamp(posZ,_min, _max);		
		transform.position = new Vector3(transform.position.x, transform.position.y, posZ);
	}

    internal void setDisc(Player currentPlayer)
    {
        _currentDisc = currentPlayer;
    }
}
