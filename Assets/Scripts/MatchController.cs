using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchController : MonoBehaviour {

	public Player discPlayer;
	public Player discNPC;
	private Player _currentPlayer;

	void Start()
	{
		discPlayer.setReferences(this);	
	}

	public void initGame () {
		selectFirstPlayer();
		_currentPlayer.initTurn();
	}
	
	public void changeTurn(){
		_currentPlayer.finishTurn();
		if(_currentPlayer == discPlayer){			
			_currentPlayer = discNPC;
		}else{
			_currentPlayer = discPlayer;
		}
		_currentPlayer.initTurn();
	}

	private void selectFirstPlayer(){
		_currentPlayer = discPlayer;
	}
	
	void Update () {
		
	}
}
