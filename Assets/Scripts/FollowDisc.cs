using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDisc : MonoBehaviour {

	public Disc disc;
	private float _max = -10;
	private float _min = -18;

	void Start () {
		
	}
		
	void Update () {	
		var posZ = disc.transform.position.z;
		posZ = Mathf.Clamp(posZ,_min, _max);
		//Debug.Log("PosZ: "+posZ);
		transform.position = new Vector3(transform.position.x, transform.position.y, posZ);
	}
}
