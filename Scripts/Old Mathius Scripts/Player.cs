using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	GameObject ent_camera, ent_player;
	Camera c_camera;

	public int life = 5;
	public string equation = "THIS IS A TEST!";
	public string variable = "5";

	void generateEquation() {
		int answer = (int)Mathf.Floor(Random.Range(0, 10));
		variable = "" + answer;

		string eqn = "x";

		int multiple = (int)Mathf.Floor(Random.Range(1, 13));
		if(multiple != 1) {
			eqn = multiple + eqn;
			answer = answer * multiple;
		}

		for(int i = 0; i < 1; i++) {
			int addition = (int)Mathf.Floor(Random.Range(-100, 100));
			if(addition > 0) {
				eqn = eqn + "+" + addition;
				answer += addition;
			} else if(addition < 0) {
				eqn = eqn + addition;
				answer += addition;
			}
		}

		equation = eqn + " = " + answer;
	}

	void Start() {
		generateEquation();

		ent_player = GameObject.FindGameObjectWithTag("Ship");
		ent_camera = GameObject.FindGameObjectWithTag("MainCamera");
		c_camera = (Camera)ent_camera.GetComponent("Camera");
	}

	void Update() {
		position();
	}



	void position() {
		float x, y, scale = 2;

		x = rigidbody.position.x;
		y = rigidbody.position.y;


		float s, c;
		s = Mathf.Sin(transform.localRotation.z);
		c = Mathf.Cos(transform.localRotation.z);
		if(Input.GetKey("w")) { transform.Translate(scale * s, scale * c, 0); transform.Rotate(0, 0, 8 * (.4f - transform.localRotation.z)); }
		if(Input.GetKey("a")) { transform.Translate(-scale * c, scale * s, 0); }
		if(Input.GetKey("s")) { transform.Translate(-scale * s, -scale * c, 0); transform.Rotate(0, 0, 8 * (-.4f - transform.localRotation.z)); }
		if(Input.GetKey("d")) { transform.Translate(scale * c, -scale * s, 0); }

		transform.Rotate(0, 0, -8 * transform.localRotation.z); // Stableize angles

		if(c_camera.isOrthoGraphic) { // Keep in camera bounds
			float offset_x, offset_y;

			offset_y = c_camera.orthographicSize - 10;
			offset_x = offset_y * c_camera.GetScreenWidth() / c_camera.GetScreenHeight();

			if(offset_x < x) transform.Translate(offset_x - x, 0, 0);
			else if(x < -offset_x) transform.Translate(-offset_x - x, 0, 0);
			if(offset_y < y) transform.Translate(0, offset_y - y, 0);
			else if(y < -offset_y) transform.Translate(0, -offset_y - y, 0);
		} else { // Camera FOV/Aspect crap
			float dist, offset_x, offset_y;

			dist = Mathf.Abs(ent_camera.transform.position.z - ent_player.transform.position.z);
			offset_y = dist * Mathf.Tan(rad(c_camera.fov / 2 - 5)); // the -5 is to create padding along the borders
			offset_x = offset_y * c_camera.aspect;

			if(offset_x < x) transform.Translate(offset_x - x, 0, 0);
			else if(x < -offset_x) transform.Translate(-offset_x - x, 0, 0);
			if(offset_y < y) transform.Translate(0, offset_y - y, 0);
			else if(y < -offset_y) transform.Translate(0, -offset_y - y, 0);
		}
	}

	void OnCollisionEnter(Collision data) {
		string name = data.gameObject.name;
		switch(name) {
			case "Alian(Clone)":
				if(data.gameObject.GetComponent<Alian>().variable == variable) {
					life += 1;
					generateEquation();
				} else {
					life -= 1;
				}
				break;
			default:
				break;
		}
	}

	void OnGUI() {
		GUI.Box(new Rect(10, 10, 200, 20), "x = " + variable);
		GUI.Box(new Rect(10, 30, 200, 20), "Eq = " + equation);
		GUI.Box(new Rect(10, 50, 200, 20), "Life = " + life);
	}

	//void setText(int id, string str) { ((TextMesh)debugs[id].GetComponent("TextMesh")).text = str; }
	string n2s(int num) { return "" + num; }
	string n2s(float num) { return "" + num; }
	float rad(float deg) { return Mathf.PI * deg / 180; }
}
