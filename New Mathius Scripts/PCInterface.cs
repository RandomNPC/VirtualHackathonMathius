using UnityEngine;
using System.Collections;

public class PCInterface : MonoBehaviour {
	
	private PaulPlayer pp;
	private Gun g;
	private bool enable_control;
	
	// Use this for initialization
	void Start () {
		enable_control = false;
		g = null;
		pp = null;
		checkForControl();
	}
	
	// Update is called once per frame
	void Update () {
		checkForControl();
		if(enable_control) PCRoutine();
	}
	
	void checkForControl(){
		pp = GameObject.Find("Mathius").GetComponent("PaulPlayer") as PaulPlayer;
		g = GameObject.Find("Gun").GetComponent("Gun") as Gun;
		
		if(pp==null || g == null) enable_control = false;
		else enable_control = true;
	}
	
	void mathiusUP(){pp.moveUp();}
	void mathiusDOWN(){pp.moveDown();}
	void mathiusLEFT(){pp.moveLeft();}
	void mathiusRIGHT(){pp.moveRight();}
	void mathiusFIRE(string num){g.fireNum(num);}
	
	void PCRoutine(){
	
	}
}
