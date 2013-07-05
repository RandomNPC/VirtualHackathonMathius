using UnityEngine;
using System.Collections;
using System.IO;

public class FileIO : MonoBehaviour {
	
	private ArrayList content;
	private static string FILENAME;
	private Mathius_UI ourScore;
	
	void Start(){
		FILENAME = Application.persistentDataPath + "/highscores.txt";
		content = new ArrayList();
		load ();
		ourScore = GameObject.Find("G1").GetComponent("Mathius_UI") as Mathius_UI;
	}
	
	void load(){
		content.Clear();
		
		if(!File.Exists(FILENAME)){
			using (StreamWriter sw = File.CreateText(FILENAME)){}
		}
		
		using(StreamReader sr = File.OpenText(FILENAME)){
			string text = "";
			while((text = sr.ReadLine())!=null){
				PlayerScore ps = new PlayerScore(int.Parse(text.Substring(0,text.IndexOf(' '))),text.Substring(text.IndexOf(' ')+1));
				content.Add(ps);
			}
		}
		
	}
	
	public void save(){
		PlayerScore p = new PlayerScore(ourScore.totalScore,"NPC");		
		content.Add (p);
		
		ArrayList temp = new ArrayList(content.Count);
		while(content.Count>0){
			PlayerScore highest = null;
			
			foreach(PlayerScore ps in content){
				if(highest==null) highest = ps;
				else{
					if(highest.score()<ps.score()) highest = ps;	
				}
			}
			content.Remove(highest);
			temp.Add(highest);
		}
		content = temp;
		
		using(StreamWriter sw = File.CreateText(FILENAME)){
			foreach(PlayerScore c in content){
				sw.WriteLine(c.score() + " " + c.player());
			}
		}
	}
	
	private class PlayerScore{
		private int _score;
		private string _player;
		
		public PlayerScore(int s, string p){
			_score = s;
			_player = p;
		}
		
		public int score(){return _score;}
		public string player(){return _player;}
	};

}