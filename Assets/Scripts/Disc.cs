using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disc : Player {

	public Text sensi; 
	public void adjustSensibility(float val){
		if(_sensibility<100) _sensibility += val;
		sensi.text = _sensibility.ToString();
	}
    void Awake()
	{
		sensi.text = _sensibility.ToString();
		_rigi = GetComponent<Rigidbody>();
		_mainCamera = Camera.main;
		_restartPos = transform.position;
		_startPos = _mainCamera.transform.position;
		gameObject.SetActive(false);
	}
	
	public override void initTurn(){
		_isTurn= true;
		Debug.Log("Init Disc");
		gameObject.SetActive(true);
	}

	private Vector3 _posInitArrow;
	private bool _moveArrow;
	void Update () {			
		if(!_isTurn) return;

		Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);	

		if(Input.GetMouseButtonDown(0) && !_isMoving){			
			if (Physics.Raycast(ray.origin, ray.direction*100, out _rayHit, 100) && _rayHit.transform.CompareTag("Disc"))
			{
				_isPressDisc = true;
				_timeInit = Time.time;
				_initPos = transform.position;					
				//Debug.Log("Update: "+_rayHit.point);			
			}
		}
		
		if(Input.GetMouseButtonUp(0)){
			if(_isPressDisc){
				var finalTime = Time.time-_timeInit;
				var finalDist = Vector3.Distance(transform.position, _initPos);
				var dir = transform.position-_initPos;
				var vel = Vector3.ClampMagnitude(dir.normalized * finalDist * 10 * _sensibility, 1000);				
				Debug.Log("Final Dist: "+finalDist);
				Debug.Log("Velocidad: "+vel);
				if(finalDist>0.2f){						
					_rigi.AddForce(vel);
					_isMoving = true;								
				}				
			}			
			_isPressDisc = false;
		}

		if(_isPressDisc){
			Debug.DrawRay(ray.origin, ray.direction*100, Color.blue);				
			transform.position = new Vector3(ray.origin.x,transform.position.y,ray.origin.z);			
		}

		var tempMag = Vector3.Magnitude(_rigi.velocity);
		if(tempMag>_magnitud){
			_magnitud = tempMag;			
		}
		//Debug.Log("Magnitud: "+tempMag);

		if(Vector3.Magnitude(_rigi.velocity)==0 && _isMoving){			
			_isMoving = false;
			reset();
		}
	}

	void OnCollisionEnter (Collision col)
    {
        if(col.transform.CompareTag("Border")){
			_isPressDisc = false;
		}

		if(col.transform.CompareTag("Death")){			
			reset();		
		}
		
    }
	void OnTriggerEnter (Collider col)
    {    
		Debug.Log("OnTriggerEnter: "+col.transform);	
		if(col.transform.name == "point_3"){
			hud.setPointPlayer(3);
		}
		else if(col.transform.name == "point_6"){
			hud.setPointPlayer(6);
		}
		else if(col.transform.name == "point_9"){
			hud.setPointPlayer(9);
		}
    }
}
