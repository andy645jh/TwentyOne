using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public SpriteRenderer flecha;
	protected Rigidbody _rigi;
	protected RaycastHit _rayHit;
	protected Camera _mainCamera;
	protected bool _isPressDisc = false;
	protected float _timeInit;
	protected Vector3 _initPos;
	protected Vector3 _restartPos;
	protected float _magnitud =0;
	protected float _vel = 0;
	protected Vector3 _startPos = Vector3.forward*-18;	
	protected MatchController _matchController;
	protected Vector3 _endPos = Vector3.forward*-10;
	public Hud hud;
    protected bool _isMoving;
	protected bool _isTurn;
	
	protected float _sensibility = 45;
	public virtual void initTurn () {
		
	}
		
	public virtual void finishTurn () {
		
	}

	public void setReferences (MatchController match) {
		_matchController = match;
	}

	
	protected void reset(){
		gameObject.SetActive(false);
		_isPressDisc = false;
		_isMoving = false;
		transform.position = _restartPos;
		_rigi.velocity = Vector3.zero;
		transform.eulerAngles = Vector3.zero;	
		//transform.eulerAngles = Vector3.right * 90;	
		_matchController.changeTurn();
	}
	
	
}
