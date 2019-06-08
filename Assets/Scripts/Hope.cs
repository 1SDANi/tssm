using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hope : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			if(transform.rotation.z<0.0f){transform.Rotate(Vector3.forward*Time.deltaTime);}
	if(transform.rotation.z>0.0f){transform.Rotate(Vector3.forward*-Time.deltaTime);}
	}
}
