using UnityEngine;
using System.Collections;

public class LevelEditorUI : MonoBehaviour {
	public GUISkin thisMetalGUISkin;
	private int terrainNum;
	private bool toggleTxt1;
	private bool toggleTxt2;
	private bool toggleTxt3;
	private bool toggleTxt4;
	private bool toggleTxt5;
	private bool toggleTxt6;
	private bool toggleTxt7;
	private bool toggleTxt8;
	private bool opToggleTxt1;
	private bool opToggleTxt2;
	private bool opToggleTxt3;
	private bool opToggleTxt4;
	private int formatInt;
	private string[] formatArray;
	private string[] terrainNames;

	// Use this for initialization
	void Start () {
		terrainNum = 1;
		terrainNames = new string[]{"Terrain1","Terrain2","Terrain3","Terrain4","Terrain5","Terrain6","Terrain7","Terrain8"};
		formatArray =new string [3];
		formatArray[0] ="Algebra";
		formatArray[1] ="Arithmetic";
		formatArray[2] ="Mixed";
		formatInt = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		float intDivider = Screen.height/100;
		float widthDivider = Screen.width/100;
		Rect titleRect = new Rect((Screen.width/5)/2,(3*intDivider),(4*(Screen.width/5)),(18*intDivider));
		GUI.skin = thisMetalGUISkin;
		//Title
		GUI.Label(titleRect, ("Mathius: Defender of Earth!"),GUI.skin.GetStyle("label"));
		//First Label
		GUI.Label(new Rect(widthDivider*20, intDivider*25,widthDivider*50, intDivider*5), ("Number of Terrains : "),GUI.skin.GetStyle("button"));
		//Terrain Decrementer
		if(GUI.Button(new Rect(widthDivider*50, intDivider*25,widthDivider*5, intDivider*5),("-"),GUI.skin.GetStyle("button"))){
			if(terrainNum>1){
				terrainNum --;
			}
		}
		//Terrain int
		GUI.Label(new Rect(widthDivider*55, intDivider*26,widthDivider*50, intDivider*5), ("" +terrainNum),GUI.skin.GetStyle("toggle"));
		//Terrain Incrementer
		if(GUI.Button(new Rect(widthDivider*60, intDivider*25,widthDivider*5, intDivider*5),("+"),GUI.skin.GetStyle("button"))){
			if(terrainNum>=1){
				terrainNum ++;
			}
		}
		//Terrain Toggle
		GUI.Label(new Rect(widthDivider*20, intDivider*30,widthDivider*50, intDivider*5), ("Terrain Selection"),GUI.skin.GetStyle("button"));
		toggleTxt1 = GUI.Toggle(new Rect(widthDivider*20, intDivider*35, 100, 30), toggleTxt1, terrainNames[0]);
		toggleTxt2 = GUI.Toggle(new Rect(widthDivider*60, intDivider*35, 100, 30), toggleTxt2, terrainNames[1]);
		toggleTxt3 = GUI.Toggle(new Rect(widthDivider*20, intDivider*40, 100, 30), toggleTxt3, terrainNames[2]);
		toggleTxt4 = GUI.Toggle(new Rect(widthDivider*60, intDivider*40, 100, 30), toggleTxt4, terrainNames[3]);
		toggleTxt5 = GUI.Toggle(new Rect(widthDivider*20, intDivider*45, 100, 30), toggleTxt5, terrainNames[4]);
		toggleTxt6 = GUI.Toggle(new Rect(widthDivider*60, intDivider*45, 100, 30), toggleTxt6, terrainNames[5]);
		toggleTxt7 = GUI.Toggle(new Rect(widthDivider*20, intDivider*50, 100, 30), toggleTxt7, terrainNames[6]);
		toggleTxt8 = GUI.Toggle(new Rect(widthDivider*60, intDivider*50, 100, 30), toggleTxt8, terrainNames[7]);
		//Opperations Toggle
		GUI.Label(new Rect(widthDivider*20, intDivider*55,widthDivider*50, intDivider*5), ("Math Operations"),GUI.skin.GetStyle("button"));
		opToggleTxt1 = GUI.Toggle(new Rect(widthDivider*20, intDivider*60, 100, 30), opToggleTxt1, "+");
		opToggleTxt2 = GUI.Toggle(new Rect(widthDivider*60, intDivider*60, 100, 30), opToggleTxt2, "-");
		opToggleTxt3 = GUI.Toggle(new Rect(widthDivider*20, intDivider*65, 100, 30), opToggleTxt3, "X");
		opToggleTxt4 = GUI.Toggle(new Rect(widthDivider*60, intDivider*65, 100, 30), opToggleTxt4, "%");
		//Eqaution Format
		GUI.Label(new Rect(widthDivider*20, intDivider*70,widthDivider*50, intDivider*5), ("Equation Format: "),GUI.skin.GetStyle("button"));
		//Equation Decrementer
		if(GUI.Button(new Rect(widthDivider*40, intDivider*70,widthDivider*5, intDivider*5),("-"),GUI.skin.GetStyle("button"))){
			if(formatInt>0){
				formatInt --;
			}
		}
		//Equation int
		GUI.Label(new Rect(widthDivider*45, intDivider*71,widthDivider*50, intDivider*5), ("" +formatArray[formatInt]),GUI.skin.GetStyle("toggle"));
		//Equation Incrementer
		if(GUI.Button(new Rect(widthDivider*60, intDivider*70,widthDivider*5, intDivider*5),("+"),GUI.skin.GetStyle("button"))){
			if( formatInt<2){
				formatInt ++;
			}
		}
	}
}
