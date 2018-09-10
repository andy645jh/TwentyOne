using System.Collections;
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
	}
	
	// Update is called once per frame
	void Update () {	
					
		Debug.DrawRay(_mainCamera.transform.position, (transform.position-_mainCamera.transform.position)*100, Color.yellow);	
		RaycastHit hit;   		     
        if(Physics.Raycast(_mainCamera.transform.position, (transform.position-_mainCamera.transform.position)*100, out hit))
		{
			if(hit.transform.CompareTag("Plane")){
				Debug.Log("Tranform: " + hit.transform);				
				_posInitArrow = hit.transform.position;
				sphereInit.transform.position = _posInitArrow;
				line.SetPosition(0,_posInitArrow);
			}			
		}        	
		
		Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);			
		if(Input.GetMouseButton(0) && _isDown){		
			Debug.Log("Origin: "+ray.origin);
			line.SetPosition(1,ray.origin);
			Vector3 dir = ray.origin-_posInitArrow;
			float angle = Vector3.Angle(_posInitArrow,dir);	
			//calculate rotation			
			Debug.Log("Angle: "+angle);
			sphereFinal.transform.position = ray.origin;
			flecha.transform.eulerAngles = new Vector3(flecha.transform.eulerAngles.x, angle, 0);
		}

		if(Input.GetMouseButtonDown(0)){								
			_isDown = true;						
			flecha.enabled = true;
			//sphere.position = new Vector3(ray.origin.x, transform.position.y, ray.origin.z);
			sphereInit.position = ray.origin;
		}
		
		if(Input.GetMouseButtonUp(0)){
			_isDown = false;
			_isMoving = false;			
			//flecha.enabled = false;			
		}
	}
}
