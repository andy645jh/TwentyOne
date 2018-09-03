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
			var angleGrades = Random.Range(-20,20);
			//angleGrades =0;
			if(angleGrades<0){
				angleGrades = 360 + angleGrades;
			}
			Debug.Log("Angle: "+angleGrades);
			var angle = Mathf.Deg2Rad * angleGrades;			
			
			var x = Vector3.forward.x * Mathf.Cos(angle) + Vector3.forward.z * Mathf.Sin(angle);
			var z = -Vector3.forward.x * Mathf.Sin(angle) + Vector3.forward.z * Mathf.Cos(angle);
			var dir = Vector3.Normalize(new Vector3(x,0,z));
			
			var force = dir * 1000;
			_rigi.AddForce(force);
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
