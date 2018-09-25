using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour {

	float i = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.rotation = Quaternion.Euler(0,0,i);
		i++;
	}
}
