using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
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
	
	public virtual void initTurn () {
		
	}
		
	public virtual void finishTurn () {
		
	}

	public void setReferences (MatchController match) {
		_matchController = match;
	}
}
