using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disc : MonoBehaviour {

	private Rigidbody _rigi;
	private RaycastHit _rayHit;
	private Camera _mainCamera;
	private bool _isPressDisc = false;
	private float _timeInit;
	private Vector3 _initPos;
	private Vector3 _restartPos;
	private float _magnitud =0;
	private float _vel = 0;

	public Vector3 startPos = Vector3.forward*-18;
	public Vector3 endPos = Vector3.forward*-10;
	public Hud hud;
    private bool _isMoving;

    //private float _timeEnd;
    void Start () {
		_rigi = GetComponent<Rigidbody>();
		_mainCamera = Camera.main;
		_restartPos = transform.position;
		startPos = _mainCamera.transform.position;
	}
	
	private void drawCenterLine(){
		/*
		Vector3 posStart = _mainCamera.transform.position;
		posStart.x = posStart.x -Screen.width/2;
		posStart.y = -5;
		Vector3 endPos = new Vector3(posStart.x+Screen.width/2, posStart.y, posStart.z);
		*/
		Debug.DrawLine(startPos, endPos, Color.green);
	}

	// Update is called once per frame
	void Update () {
		drawCenterLine();

		if(Input.GetKey(KeyCode.F)){
			_rigi.AddForce(Vector3.forward*100);
		}

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
				var vel = Vector3.ClampMagnitude(dir.normalized / finalTime * 150, 1200);				
				Debug.Log("Distance: "+finalDist);
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
		//Debug.Log("Vel: "+_magnitud);

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

	void reset(){
		_isPressDisc = false;
		transform.position = _restartPos;
		_rigi.velocity = Vector3.zero;
		transform.eulerAngles = Vector3.zero;	
	}

	void OnTriggerEnter (Collider col)
    {    
		Debug.Log("OnTriggerEnter: "+col.transform);	
		if(col.transform.name == "point_3"){
			hud.setPoint3();
		}
		else if(col.transform.name == "point_6"){
			hud.setPoint6();
		}
		else if(col.transform.name == "point_9"){
			hud.setPoint9();
		}
    }
}
