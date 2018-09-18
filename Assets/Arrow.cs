using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Player {

	private Vector3 _posInitArrow;
	private bool _moveArrow;
	private bool _isDown;
	public Transform sphereInit;
	public Transform sphereFinal;
	public LineRenderer line;
    void Awake()
	{
		_mainCamera = Camera.main;
		_rigi = GetComponent<Rigidbody>();
		/*sensi.text = _sensibility.ToString();
		_rigi = GetComponent<Rigidbody>();
		
		_restartPos = transform.position;
		_startPos = _mainCamera.transform.position;
		gameObject.SetActive(false);*/
	}
	
	public override void initTurn(){
		
		_initPos = transform.position;
		sphereInit.transform.position = _initPos;
		line.enabled = false;
		line.SetPosition(0,_initPos);		
		gameObject.SetActive(true);
		_isTurn= true;
	}
	
	void Update () {	
		
		if(!_isTurn) return;
		Debug.Log("Ray");
		RaycastHit hit;   	
		Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);		
		Debug.DrawRay(ray.origin, ray.direction*100, Color.yellow);			
		if (Physics.Raycast(ray.origin, ray.direction*100, out hit, 100) && hit.transform.name == "platform")
		{			
			//Debug.Log("Tranform Update: " + hit.transform);		

			if(Input.GetMouseButton(0) && _isDown){						
				var pos = hit.point;
				pos.y = _initPos.y;								
				Debug.Log("Pos: "+pos);
				float distance = Vector3.Distance(_initPos, pos);
				
				if(distance> 4.1f){
					Vector3 dir = Vector3.Normalize(pos-_initPos) * 4;	
					Debug.Log("Distance 1: "+Vector3.Distance(_initPos, dir));
					Debug.Log("Dir: "+dir);
					dir.x += _initPos.x;
					dir.y = _initPos.y;
					dir.z += _initPos.z;
					sphereFinal.position = dir;
					line.SetPosition(1,dir);
				}else{
					Debug.Log("Distance 2: "+distance);
					sphereFinal.position = pos;
					line.SetPosition(1,pos);
				}
				
				
				//flecha.transform.localEulerAngles = new Vector3(flecha.transform.localEulerAngles.x, angle, 0);
			}

			if(Input.GetMouseButtonDown(0)){								
				_isDown = true;						
				//flecha.enabled = true;
				line.enabled = true;
				//sphere.position = new Vector3(ray.origin.x, transform.position.y, ray.origin.z);
				sphereFinal.position = hit.point;
				line.SetPosition(1,hit.point);
			}
		}	
		
		if(Input.GetMouseButtonUp(0) && _isDown){
			Debug.Log("Update");
			_isDown = false;
			//_isMoving = true;			
			line.enabled = false;
			var dir = line.GetPosition(1)- line.GetPosition(0);
			var finalDist = Vector3.Distance(line.GetPosition(1), line.GetPosition(0));
			var vel = Vector3.ClampMagnitude(dir.normalized * finalDist * 10 * _sensibility, 1000);
			_rigi.AddForce(vel);					
		}

		//esto hay que revisarlo xq aun genera error en el reset
		if(Vector3.Magnitude(_rigi.velocity)>0) _isMoving = true;

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
