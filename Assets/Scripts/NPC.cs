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
}
