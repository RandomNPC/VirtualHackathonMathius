using UnityEngine;
using System.Collections;

public class MapProperties : MonoBehaviour {

	public float z_axis;
	public bool use_buildings;
	
	void Start(){
		z_axis = 300.0f;
		use_buildings = true;
	}
	
}