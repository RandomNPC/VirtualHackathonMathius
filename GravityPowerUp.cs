using UnityEngine;
using System.Collections;

public class GravityPowerUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Rigidbody body = gameObject.GetComponent(typeof(Rigidbody)) as Rigidbody;
		body.useGravity = true;	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
