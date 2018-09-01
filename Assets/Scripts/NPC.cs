using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Player {

	void Awake()
	{
		_rigi = GetComponent<Rigidbody>();
		_mainCamera = Camera.main;
		_restartPos = transform.position;
		_startPos = _mainCamera.transform.position;
		gameObject.SetActive(false);
	}

	public override void initTurn(){
		_isTurn= true;
		Debug.Log("Init NPC");
		gameObject.SetActive(true);
	}

	void Update () 
	{		
		if(Vector3.Magnitude(_rigi.velocity)==0 && _isMoving){			
			_isMoving = false;
			reset();
		}
	}

	void FixedUpdate () 
	{		
		if(!_isTurn) return;
		if(!_isMoving){
			Debug.Log("NPC Move");
			var dir = Vector3.forward * 1000;
			_rigi.AddForce(dir);
			_isMoving = true;
		}		
	}

	void OnTriggerEnter (Collider col)
    {    
		Debug.Log("OnTriggerEnter: "+col.transform);	
		if(col.transform.name == "point_3"){
			hud.setPointNpc(3);
		}
		else if(col.transform.name == "point_6"){
			hud.setPointNpc(6);
		}
		else if(col.transform.name == "point_9"){
			hud.setPointNpc(9);
		}
    }
}
