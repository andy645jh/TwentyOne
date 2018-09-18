using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchController : MonoBehaviour {
	public GameObject canvas;
	public Player discPlayer;
	public Player discNPC;
	public FollowDisc follower;

	private Player _currentPlayer;

	void Awake () {
		canvas.SetActive(true);
	}
	
	void Start()
	{
		discPlayer.setReferences(this);	
		discNPC.setReferences(this);	
	}

	public void initGame () {
		selectFirstPlayer();
		Debug.Log("Current Player: "+_currentPlayer);
		_currentPlayer.initTurn();
	}
	
	public void changeTurn(){
		_currentPlayer.finishTurn();
		/*if(_currentPlayer == discPlayer){			
			_currentPlayer = discNPC;
		}else{
			_currentPlayer = discPlayer;
		}*/
		follower.setDisc(_currentPlayer);
		
		_currentPlayer.initTurn();
	}

	private void selectFirstPlayer(){
		_currentPlayer = discPlayer;
		follower.setDisc(_currentPlayer);
	}	
}
