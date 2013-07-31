using UnityEngine;
using System.Collections;

public class Mathius_UI : MonoBehaviour {
	
public PaulScore gameData;
public GUISkin thisMetalGUISkin;
	void Start(){
	gameData = gameObject.transform.parent.GetComponent("PaulScore") as PaulScore;
	}
	void OnGUI(){ 
		int streak = gameData.streak_score;
		int mathiusNum = gameData.mathius_variable;
		string equation = gameData.equation; 
		int lives = gameData.lives; 
		int score = (gameData.num_correct*100)-(gameData.num_wrong*10);
		float intDivider = Screen.height/100;
		GUI.skin = thisMetalGUISkin;
		GUI.Label(new Rect((Screen.width/5)/3,(3*intDivider),((Screen.width/5)),(18*intDivider)), ("Lives: "+lives),GUI.skin.GetStyle("button"));
		GUI.Label(new Rect((Screen.width/5)/3,(6*intDivider),((Screen.width/5)),(18*intDivider)), ("Score: "+score),GUI.skin.GetStyle("button"));
		GUI.Label(new Rect((Screen.width/5)/3,(9*intDivider),((Screen.width/5)),(18*intDivider)), ("Streak: "+streak),GUI.skin.GetStyle("button"));
		GUI.Label (new Rect((Screen.width/25) ,(70*intDivider) ,(4*(Screen.width/10)) ,(15*intDivider) ) ,("Mathius Number: "+ mathiusNum) ,GUI.skin.GetStyle("window"));
		GUI.Label (new Rect((Screen.width/25) ,(90*intDivider) ,(4*(Screen.width/10)) ,(15*intDivider) ) ,("Next: "+ equation) ,GUI.skin.GetStyle("window"));
		if(GUI.Button (new Rect(6*(Screen.width/10) ,(90*intDivider) ,(4*(Screen.width/10)) ,(15*intDivider) ) ,("Main Menu") ,GUI.skin.GetStyle("box") ) ){
				Debug.Log("Mathius Clicked");
				Application.LoadLevel("MainMenu");}
	}
}

