﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	private Vector3 _posInitArrow;
	private bool _moveArrow;
	private bool _isDown;
	private bool _isMoving;
	private Vector3 _initPos;
	public SpriteRenderer flecha;
    public Camera _mainCamera { get; private set; }
	public Transform sphereInit;
	public Transform sphereFinal;
	public LineRenderer line;
	
    void Awake()
	{
		_mainCamera = Camera.main;
		/*sensi.text = _sensibility.ToString();
		_rigi = GetComponent<Rigidbody>();
		
		_restartPos = transform.position;
		_startPos = _mainCamera.transform.position;
		gameObject.SetActive(false);*/
	}
	void Start () {
		_initPos = transform.position;
		sphereInit.transform.position = _initPos;
		line.SetPosition(0,_initPos);
	}
	
	private bool _first;
	void drawSphere(){

		if(_first) return;

		Debug.DrawRay(_mainCamera.transform.position, (transform.position-_mainCamera.transform.position)*100, Color.yellow);	
		RaycastHit hit;   		     
        if(Physics.Raycast(_mainCamera.transform.position, (transform.position-_mainCamera.transform.position)*100, out hit))
		{
			if(hit.transform.CompareTag("Disc")){
				_first = true;
				Debug.Log("Tranform: " + hit.transform);				
				_posInitArrow = hit.transform.position;
				_posInitArrow.y = _initPos.y;
				sphereInit.transform.position = _posInitArrow;
				line.SetPosition(0,_posInitArrow);
			}			
		}     
	}

	// Update is called once per frame
	void Update () {	
		//drawSphere();
		RaycastHit hit;   	
		Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);		
		Debug.DrawRay(ray.origin, ray.direction*100, Color.yellow);			
		if (Physics.Raycast(ray.origin, ray.direction*100, out hit, 100) && hit.transform.name == "platform")
		{			
			Debug.Log("Tranform Update: " + hit.transform);		

			if(Input.GetMouseButton(0) && _isDown){		
				Debug.Log("Origin: "+ray);
				var pos = hit.point;
				pos.y = _initPos.y;
				line.SetPosition(1,pos);
				Vector3 dir = ray.origin-_posInitArrow;
				float angle = Vector3.Angle(_posInitArrow,dir);	
				//calculate rotation			
				Debug.Log("Angle: "+angle);
				sphereFinal.position = pos;
				//flecha.transform.localEulerAngles = new Vector3(flecha.transform.localEulerAngles.x, angle, 0);
			}

			if(Input.GetMouseButtonDown(0)){								
				_isDown = true;						
				flecha.enabled = true;
				//sphere.position = new Vector3(ray.origin.x, transform.position.y, ray.origin.z);
				sphereFinal.position = hit.point;
				line.SetPosition(1,hit.point);
			}
		}

		
		
		if(Input.GetMouseButtonUp(0)){
			_isDown = false;
			_isMoving = false;			
			//flecha.enabled = false;			
		}
	}
}