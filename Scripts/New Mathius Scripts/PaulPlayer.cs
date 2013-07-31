using UnityEngine;
using System.Collections;

public class PaulPlayer : MonoBehaviour {
	
	private GameObject camera;	
	private GameObject mathius;
	private Camera mathius_cam;
	public Vector3 delta;
	public Vector3 anchor;
	
	
	private MoveCamera mc;
	private PaulScore ps; 
	
	// Use this for initialization
	void Start () {
		mc = GameObject.Find("MathiusEarthCam").GetComponent("MoveCamera")as MoveCamera;
		ps = GameObject.Find("MathiusEarthCam").GetComponent("PaulScore") as PaulScore;
		camera = GameObject.Find("MathiusEarthCam") as GameObject;
		mathius_cam = camera.GetComponent(typeof(Camera)) as Camera;
		delta = new Vector3(0.0f,0.0f,0.0f);
		anchor = new Vector3(0.0f,0.0f,0.0f);
		mathius = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		playerControl();
		Vector3 mpos = mathius.transform.position;
		Vector3 cpos = camera.transform.position;
		
		delta.z = mpos.z-cpos.z;
		delta.y = delta.z*Mathf.Tan(rad(mathius_cam.fov/2));
		delta.x = delta.y*mathius_cam.aspect;
		
		anchor.x = cpos.x - delta.x;
		anchor.y = cpos.y - delta.y;
		anchor.z = mpos.z;
		
		if(mpos.y>cpos.y+delta.y)mathius.transform.Translate(0,-1,0);
		else if(mpos.y < cpos.y-delta.y)mathius.transform.Translate(0,1,0);
		
		if(mpos.x>cpos.x+delta.x)mathius.transform.Translate(-1,0,0);
		else if(mpos.x < cpos.x-delta.x) mathius.transform.Translate(1,0,0);
	}
	
	void playerControl(){
		float scale = 1;
		float s, c;
		s = Mathf.Sin(0);
		c = Mathf.Cos(0);
		
		if(Input.GetKey("w")) { moveUp(); }
		if(Input.GetKey("a")) { moveLeft(); }
		if(Input.GetKey("s")) { moveDown(); }
		if(Input.GetKey("d")) { moveRight(); }

		transform.Rotate(0, 0, -8 * transform.localRotation.z); // Stableize angles
	}
	
	float rad(float deg) { return Mathf.PI * deg / 180; }
	
	void OnCollisionEnter(Collision data) {
		string name = data.gameObject.name;
		
		switch(name) {
			case "Alian(Clone)":
				PaulAlien obj = data.gameObject.GetComponent("PaulAlien") as PaulAlien;
				BoxCollider alianBox =  data.gameObject.GetComponent(typeof(BoxCollider)) as BoxCollider;
				Destroy(alianBox);
				ps.mathius_crashes(obj.answer,data.gameObject);
				break;
			default:
				GameObject explosionPrefab = Resources.Load("Detonator-Chunks")as GameObject;
				Instantiate(explosionPrefab,new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z),Quaternion.identity);
				mc.kill_mathius();
				//Application.LoadLevel("GameOver");
				break;
		}
	}
	
	public void moveLeft(){mathius.transform.Translate(-1.0f,0.0f,0.0f);}
	public void moveRight(){mathius.transform.Translate(1.0f,0.0f,0.0f);}
	public void moveUp(){mathius.transform.Translate(0.0f,1.0f,0.0f);}
	public void moveDown(){mathius.transform.Translate(0.0f,-1.0f,0.0f);}
	
}
