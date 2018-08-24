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

	//private float _timeEnd;
	void Start () {
		_rigi = GetComponent<Rigidbody>();
		_mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.F)){
			_rigi.AddForce(Vector3.forward*100);
		}

		Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
		if(Input.GetMouseButtonDown(0)){			
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
				var vel = finalTime / finalDist;
				_rigi.AddForce(dir.normalized / finalTime * 150);
				Debug.Log("Vel: "+finalTime);				
			}
			_isPressDisc = false;
		}

		if(_isPressDisc){
			Debug.DrawRay(ray.origin, ray.direction*100, Color.blue);				
			transform.position = new Vector3(ray.origin.x,transform.position.y,ray.origin.z);			
		}
	}

	void OnCollisionEnter (Collision col)
    {
        if(col.transform.CompareTag("Border")){
			_isPressDisc = false;
		}
    }
}
