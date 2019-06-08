using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialOffset : MonoBehaviour {
	public float Speed;
	public bool HasBump;
	public enum Direction{X,Y}
	public Direction direction;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(direction == Direction.Y){
		GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0, 0.001f * Speed);
		if(GetComponent<Renderer>().material.mainTextureOffset.y >= 1f){GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0,-1);}
	}
	if(direction == Direction.X){
		GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0.001f * Speed, 0);
		if(GetComponent<Renderer>().material.mainTextureOffset.x >= 1f){GetComponent<Renderer>().material.mainTextureOffset = new Vector2(-1,0);}
	}
	}
}
