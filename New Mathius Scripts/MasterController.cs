using UnityEngine;
using System.Collections;

public class MasterController : MonoBehaviour {
	
	private static int num_of_landModules;
	private GameObject[] landModules;
	private byte math_operations;
	private int math_format;
	
	private LevelEditorUI le;
	
	// Use this for initialization
	void Start () {
		//load prefances first
		DontDestroyOnLoad(gameObject);
	}
	
	public void saveSettings(){
		num_of_landModules = le.num_of_terrains();
		TerrainManager tm = gameObject.GetComponent("TerrainManager") as TerrainManager;
		landModules = tm.selected_terrains(le.using_terrains());
		math_operations = le.using_operations();
		math_format = le.using_eqFormat();
	}
	
	public void loadSettings(){
		le = (GameObject.Find ("Main Camera")).GetComponent("LevelEditorUI") as LevelEditorUI;
	}
}
