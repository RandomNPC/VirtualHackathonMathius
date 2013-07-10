using UnityEngine;
using UnityEditor;
using System.Collections;

public class PowerUpManager : MonoBehaviour {

	public MonoScript powerUpScript;
	
	// Use this for initialization
	void Start () {
	}
	
	void OnTriggerEnter(Collider obj){
		if(!obj.name.Contains("Mathius")) return;	
		//attach script to Mathius
		if(powerUpScript!=null){
			GameObject ship = GameObject.Find("Mathius") as GameObject;
			ship.AddComponent(powerUpScript.GetClass());
		}
		Destroy(gameObject);
	}
}
