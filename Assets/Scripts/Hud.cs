using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour {

	public Text txtPointsPlayer;
	public Text txtPointsNpc;
	public MenuController menu;
	public SelectorController selectorLevel;
	public MatchController matchController;	
	public HudIngame hudIngame;
	private float _pointPlayer = 0;
	private float _pointVal6 = 0;
	private float _pointNpc = 0;

	private float _total;

	void Start () {
		txtPointsPlayer.text = "0";		
		txtPointsNpc.text = "0";
	}
	
	public void clicStart(){
		menu.gameObject.SetActive(false);
		selectorLevel.gameObject.SetActive(true);
	}	

	public void closeSelector(){
		selectorLevel.gameObject.SetActive(false);
		hudIngame.gameObject.SetActive(true);
		matchController.initGame();
	}

	public void setPointPlayer(float amount){
		_pointPlayer += amount;
		txtPointsPlayer.text = _pointPlayer.ToString();
	}

	public void setPointNpc(float amount){
		_pointNpc += amount;
		txtPointsNpc.text = _pointNpc.ToString();
	}
}
